using System;
using System.IO;

namespace SetupCreator
{
    public static class Global
    {
        //________________________________________VARIABLES________________________________________
        public const string setupExtension = ".SCSetup";

        //________________________________________FUNCTIONS________________________________________

        public static string ImgToString(string path)
        {
            if (!File.Exists(path))
                throw new IOException("Le fichier suivant est introuvable :" + Environment.NewLine + path);

            byte[] b = File.ReadAllBytes(path);
            return Convert.ToBase64String(b);
        }

    }
}
