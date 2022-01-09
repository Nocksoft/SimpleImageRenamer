/* SimpleImageRenamer
 * Copyright (C) 2022 Rafael Nockmann @ Nocksoft
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * Dieses Programm ist Freie Software: Sie können es unter den Bedingungen
 * der GNU General Public License, wie von der Free Software Foundation,
 * Version 3 der Lizenz oder (nach Ihrer Wahl) jeder neueren
 * veröffentlichten Version, weiter verteilen und/oder modifizieren.
 * 
 * Dieses Programm wird in der Hoffnung bereitgestellt, dass es nützlich sein wird, jedoch
 * OHNE JEDE GEWÄHR,; sogar ohne die implizite
 * Gewähr der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK.
 * Siehe die GNU General Public License für weitere Einzelheiten.
 * 
 * Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
 * Programm erhalten haben. Wenn nicht, siehe <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SimpleImageRenamer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Text = $"{ProjectProperties.GetTitle()} - Version: {ProjectProperties.GetVersion()}";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ExifTool.ExtractExifTool();
            Images.Imagelist = new List<Image>();
        }

        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            var images = new OpenFileDialog();
            images.Filter = Images.GetOpenFileDialogFilter();
            images.Multiselect = true;
            if (images.ShowDialog() != DialogResult.OK) return;

            foreach (var item in images.FileNames)
            {
                Images.Imagelist.Add(new Image(item));
            }
            UpdateListViewImages();
        }

        private void buttonAddDirectory_Click(object sender, EventArgs e)
        {
            var directory = new FolderBrowserDialog();
            directory.Description = "Select a folder that contains the photos and videos you want to rename.";
            directory.ShowNewFolderButton = false;
            if (directory.ShowDialog() != DialogResult.OK) return;

            string[] images = Directory.GetFiles(directory.SelectedPath);
            foreach (var item in images)
            {
                string extension = Path.GetExtension(item);
                if (!Images.SupportedExtensions.Any(ext => ext[0].ToLower() == extension.ToLower())) continue;

                Images.Imagelist.Add(new Image(item));
            }
            UpdateListViewImages();
        }

        private void radioButtonFormat_CheckedChanged(object sender, EventArgs e)
        {
            Images.ResetNewFilenames();
            if (((RadioButton)sender).Checked) UpdateListViewImages();
        }

        private void textBoxFormatCustom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            if (!radioButtonFormatCustom.Checked)
                radioButtonFormatCustom.Checked = true;
            else
                UpdateListViewImages();
        }

        private void UpdateListViewImages()
        {
            LockGui();
            Cursor = Cursors.WaitCursor;
            if (listViewImages.Items.Count > 0) listViewImages.Items.Clear();
            backgroundWorkerImportImages.RunWorkerAsync();
        }

        private void backgroundWorkerImportImages_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string format = radioButtonFormatDefault.Checked ? radioButtonFormatDefault.Text : textBoxFormatCustom.Text;

            for (int i = 0; i < Images.Imagelist.Count; i++)
            {
                Image.SetNewFilename(i, format);
                Invoke(new MethodInvoker(delegate
                {
                    int percent = Convert.ToInt32(((decimal)i + 1) / Images.Imagelist.Count * 100);
                    statusStripProgressBar.Value = percent;
                    statusStripStatusLabelStatus.Text = $"Imported {i + 1}/{Images.Imagelist.Count} Files";
                }));
            }
        }

        private void backgroundWorkerImportImages_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            foreach (var item in Images.Imagelist)
            {
                var lvItem = new ListViewItem(new string[] {
                    item.AbsPath,
                    Path.GetFileName(item.AbsPath),
                    item.NewFilename,
                });
                listViewImages.Items.Add(lvItem);
            }

            buttonStartRenaming.Text = $"Rename {Images.Imagelist.Count} Files";
            Cursor = Cursors.Default;
            UnlockGui();
        }

        private void buttonStartRenaming_Click(object sender, EventArgs e)
        {
            LockGui();
            Cursor = Cursors.WaitCursor;
            backgroundWorkerRenameImages.RunWorkerAsync();
        }

        private void backgroundWorkerRenameImages_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < Images.Imagelist.Count; i++)
            {
                Image.RenameImage(Images.Imagelist[i].AbsPath, Images.Imagelist[i].NewFilename);
                Invoke(new MethodInvoker(delegate
                {
                    int percent = Convert.ToInt32(((decimal)i + 1) / Images.Imagelist.Count * 100);
                    statusStripProgressBar.Value = percent;
                    statusStripStatusLabelStatus.Text = $"Renamed {i + 1}/{Images.Imagelist.Count} Files";
                }));
            }
        }

        private void backgroundWorkerRenameImages_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            UnlockGui();
        }

        private void LockGui()
        {
            buttonAddFiles.Enabled = false;
            buttonAddDirectory.Enabled = false;
            radioButtonFormatDefault.Enabled = false;
            radioButtonFormatCustom.Enabled = false;
            textBoxFormatCustom.Enabled = false;
            buttonStartRenaming.Enabled = false;
        }

        private void UnlockGui()
        {
            buttonAddFiles.Enabled = true;
            buttonAddDirectory.Enabled = true;
            radioButtonFormatDefault.Enabled = true;
            radioButtonFormatCustom.Enabled = true;
            textBoxFormatCustom.Enabled = true;
            buttonStartRenaming.Enabled = true;
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }
    }
}
