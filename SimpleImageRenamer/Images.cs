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

        internal static void ResetNewFilenames()
        {
            Imagelist.ForEach(image => { image.NewFilename = string.Empty; });
        }
    }

    internal sealed class Image
    {
        internal string AbsPath { get; private set; }
        internal string NewFilename { get; set; }

        internal Image() { }

        internal Image(string abspath, string newFilename)
        {
            AbsPath = abspath;
            NewFilename = newFilename;
        }

        internal static void SetNewFilename(int index, string format)
        {
            string extension = Path.GetExtension(Images.Imagelist[index].AbsPath);
            string imagetype = (from ext in Images.SupportedExtensions where ext[0].ToLower() == extension.ToLower() select ext[1]).First();

            string exifToolOutput = null;
            if (imagetype == "photo")
            {
                exifToolOutput = ExifTool.GetTimestampFromPhoto(Images.Imagelist[index].AbsPath);
            }
            else if (imagetype == "video")
            {
                exifToolOutput = ExifTool.GetTimestampFromVideo(Images.Imagelist[index].AbsPath);
            }
            Images.Imagelist[index].NewFilename = GetNewFilename(exifToolOutput, format, extension);
        }

        private static string GetNewFilename(string exifToolOutput, string format, string extension)
        {
            if (exifToolOutput == null) return null;
            exifToolOutput = exifToolOutput.Replace(Environment.NewLine, string.Empty);
            int index = exifToolOutput.IndexOf("+");
            if (index >= 0)
                exifToolOutput = exifToolOutput.Substring(0, index);

            string filename = format;
            string regex = @"(?<={)(.+?)(?=})";
            var matches = Regex.Matches(format, regex).Cast<Match>();

            if (matches.Count() == 0)
            {
                filename = DateTime.ParseExact(exifToolOutput, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture).ToString(format);
            }

            foreach (var item in matches)
            {
                string timestring = DateTime.ParseExact(exifToolOutput, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture).ToString(item.Value);
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
            if (!File.Exists(newname))
            {
                File.Move(oldname, newname);
            }
        }
    }
}
