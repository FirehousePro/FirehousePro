using System;
using System.IO;
using System.Linq;

namespace FAS.FirehousePro.Web
{
    /// <summary>
    /// This class is used to find root path of the web project in;
    /// unit tests (to find views) and entity framework core command line commands (to find conn string).
    /// </summary>
    public static class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            var coreAssemblyDirectoryPath = Path.GetDirectoryName(typeof(FirehouseProCoreModule).Assembly.Location);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new ApplicationException("Could not find location of FAS.FirehousePro.Core assembly!");
            }

            var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);

            var rootFolder = "";

            if(DirectoryContains(directoryInfo.FullName, "appsettings.json"))
            {
                rootFolder = directoryInfo.FullName;
            }
            else
            {
                while (!DirectoryContains(directoryInfo.FullName, "FAS.FirehousePro.sln"))
                {
                    if (directoryInfo.Parent == null)
                    {
                        throw new ApplicationException("Could not find content root folder!");
                    }

                    directoryInfo = directoryInfo.Parent;
                }
                rootFolder = Path.Combine(directoryInfo.FullName, @"src\FAS.FirehousePro.Web");
            }

            return rootFolder;
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
        }
    }
}
