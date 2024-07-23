using System;
using System.IO;

namespace final.Helper
{
    public static class PathHelper
    {
        public static string GetProjectRelativePath(string relativePath)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(projectDirectory, relativePath);
        }
    }
}
