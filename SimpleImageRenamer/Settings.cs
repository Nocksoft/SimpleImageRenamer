﻿/* SimpleImageRenamer
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
using System.IO;

namespace SimpleImageRenamer
{
    internal static class Settings
    {
        internal static string AppDataDir { get; private set; }
        internal static string SettingsFile { get; private set; }
        internal static string ExifToolPath { get; private set; }

        private static void SetAppDateDir()
        {
            string appdate = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            AppDataDir = Path.Combine(appdate, "Nocksoft", ProjectProperties.GetTitle());
        }

        internal static void SetDefaults()
        {
            SetAppDateDir();
            SettingsFile = Path.Combine(AppDataDir, "settings.ini");
            ExifToolPath = Path.Combine(AppDataDir, "exiftool.exe");
        }

        internal static void CreateAppDataDir()
        {
            if (!Directory.Exists(AppDataDir))
            {
                Directory.CreateDirectory(AppDataDir);
            }
        }
    }
}
