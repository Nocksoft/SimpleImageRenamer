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
using System.Windows.Forms;

namespace SimpleImageRenamer
{
    public partial class FormRenameSettings : Form
    {
        internal RenameSettings.ExtensionStyles ExtensionStyle { get; private set; }

        internal FormRenameSettings(RenameSettings.ExtensionStyles extStyle)
        {
            InitializeComponent();

            ExtensionStyle = extStyle;
            switch (ExtensionStyle)
            {
                case RenameSettings.ExtensionStyles.Original:
                    comboBoxExtensionStyle.SelectedIndex = 0;
                    break;
                case RenameSettings.ExtensionStyles.Lowercase:
                    comboBoxExtensionStyle.SelectedIndex = 1;
                    break;
                case RenameSettings.ExtensionStyles.Uppercase:
                    comboBoxExtensionStyle.SelectedIndex = 2;
                    break;
                default:
                    break;
            }

            Text = $"Adjust rename settings...";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            switch (comboBoxExtensionStyle.SelectedIndex)
            {
                case 0:
                    ExtensionStyle = RenameSettings.ExtensionStyles.Original;
                    break;
                case 1:
                    ExtensionStyle = RenameSettings.ExtensionStyles.Lowercase;
                    break;
                case 2:
                    ExtensionStyle = RenameSettings.ExtensionStyles.Uppercase;
                    break;
                default:
                    break;
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
