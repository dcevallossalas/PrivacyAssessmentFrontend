using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentLogic
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Class FileValidator
    /// Validates if a file path is valid in order to avoid storage problems
    /// </summary>
    public static class FileValidator
    {
        // Determines if a file name is well formated for being used as part of a path
        public static bool IsValidFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            fileName = fileName.Trim();

            // File must not end in point
            if (fileName.Contains("."))
                return false;

            // Verifies valid characters
            char[] invalidChars = Path.GetInvalidFileNameChars();
            if (fileName.IndexOfAny(invalidChars) >= 0)
                return false;

            // Verifies valid names (Windows)
            string[] reservedNames = new string[]
            {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
            };

            string nameOnly = Path.GetFileNameWithoutExtension(fileName).ToUpperInvariant();
            if (reservedNames.Contains(nameOnly))
                return false;

            return true;
        }
    }
}