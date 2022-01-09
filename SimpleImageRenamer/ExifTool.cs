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
using System.Diagnostics;
using System.IO;

namespace SimpleImageRenamer
{
    internal static class ExifTool
    {
        internal static void ExtractExifTool()
        {
            if (!File.Exists(Settings.ExifToolPath))
            {
                File.WriteAllBytes(Settings.ExifToolPath, Properties.Resources.exiftool);
            }
        }

        internal static string GetTimestampFromPhoto(string file)
        {
            return GetOutputFromExifTool("DateTimeOriginal", file);
        }

        internal static string GetTimestampFromVideo(string file)
        {
            return GetOutputFromExifTool("MediaCreateDate", file, "-api quicktimeutc");
        }

        private static string GetOutputFromExifTool(string meta, string file, string arguments = null)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = Settings.ExifToolPath;
            process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Settings.ExifToolPath);
            process.StartInfo.Arguments = $"-{meta} -T {arguments} \"{file}\"";
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return NormalizeExifToolDate(output);
        }

        private static string NormalizeExifToolDate(string exifToolOutput)
        {
            exifToolOutput = exifToolOutput.Replace(Environment.NewLine, string.Empty);
            int index = exifToolOutput.IndexOf("+");
            if (index >= 0)
                exifToolOutput = exifToolOutput.Substring(0, index);
            return exifToolOutput;
        }
    }
}
