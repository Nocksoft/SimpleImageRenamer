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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SimpleImageRenamer
{
    internal static class Images
    {
        internal static readonly string[][] SupportedExtensions = {
            new string[] { ".jpg", "photo" },
            new string[] { ".jpeg", "photo" },
            new string[] { ".heic", "photo" },
            new string[] { ".mp4", "video" },
            new string[] { ".mov", "video" }
        };

        internal static List<Image> Imagelist;

        internal static string GetOpenFileDialogFilter()
        {
            string filter = string.Empty;
            for (int i = 0; i < SupportedExtensions.GetLength(0); i++)
            {
                filter += $"*{SupportedExtensions[i][0]}";
                if (i < (SupportedExtensions.Length - 1)) filter += ";";
            }
            return $"Photos and Videos ({filter})|{filter}";
        }

        internal static void ResetImagelist()
        {
            Imagelist.Clear();
        }

        internal static void ResetNewFilenames()
        {
            Imagelist.ForEach(image => { image.NewFilename = null; });
        }
    }

    internal sealed class Image
    {
        internal string AbsPath { get; private set; }
        internal string NewFilename { get; set; }
        private string ExifDate { get; set; }

        internal Image() { }

        internal Image(string abspath)
        {
            AbsPath = abspath;
            NewFilename = null;
            ExifDate = null;
        }

        internal static bool SetNewFilename(int index, string format)
        {
            string extension = Path.GetExtension(Images.Imagelist[index].AbsPath);
            string imagetype = (from ext in Images.SupportedExtensions where ext[0].ToLower() == extension.ToLower() select ext[1]).First();

            if (imagetype == "photo" && Images.Imagelist[index].ExifDate == null)
            {
                Images.Imagelist[index].ExifDate = ExifTool.GetTimestampFromPhoto(Images.Imagelist[index].AbsPath);
            }
            else if (imagetype == "video" && Images.Imagelist[index].ExifDate == null)
            {
                Images.Imagelist[index].ExifDate = ExifTool.GetTimestampFromVideo(Images.Imagelist[index].AbsPath);
            }

            try
            {
                Images.Imagelist[index].NewFilename = GetNewFilename(Images.Imagelist[index].ExifDate, format, extension);
                return true;
            }
            catch (Exception)
            {
                Images.Imagelist[index].NewFilename = Path.GetFileName(Images.Imagelist[index].AbsPath);
                return false;
            }
        }

        private static string GetNewFilename(string exifDate, string format, string extension)
        {
            if (exifDate == null) return null;

            string filename = format;
            string regex = @"(?<={)(.+?)(?=})";
            var matches = Regex.Matches(format, regex).Cast<Match>();

            if (matches.Count() == 0 && format == "yyyyMMdd_HHmmss")
            {
                filename = DateTime.ParseExact(exifDate, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture).ToString(format);
            }
            else if (matches.Count() == 0)
            {
                filename = format;
            }

            foreach (var item in matches)
            {
                if (!new Regex(@"^[yMdHms]+$").Match(item.Value).Success) continue;

                string timestring = DateTime.ParseExact(exifDate, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture).ToString(item.Value);
                filename = filename.Replace($"{{{item.Value}}}", timestring);
            }

            int number = 0;
            string filenameTmp = filename;
            while (Images.Imagelist.Any(item => item.NewFilename == $"{filenameTmp}{extension}"))
            {
                number++;
                filenameTmp = $"{filename}-{number}";
            }
            filename = filenameTmp;

            return $"{filename}{extension}";
        }

        internal static void RenameImage(string oldname, string newname)
        {
            newname = Path.Combine(Path.GetDirectoryName(oldname), newname);
            if (File.Exists(oldname) && !File.Exists(newname))
            {
                File.Move(oldname, newname);
            }
        }
    }
}
