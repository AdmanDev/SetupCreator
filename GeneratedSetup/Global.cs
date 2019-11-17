using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GeneratedSetup
{
    public static class Global
    {
        //Variables
        private static ImageSource setupIcon;
        private static ImageSource appImage;

        //Properties
        public static ImageSource SetupIcon
        {
            get
            {
                if (setupIcon == null)
                    setupIcon = GetAppIcon();

                return setupIcon;
            }
        }

        public static ImageSource AppImage
        {
            get
            {
                return appImage;
            }

            set
            {
                appImage = value;
            }
        }

        //Functions

        public static Process RunProcess(string file, ProcessWindowStyle mode, string arguments, bool waitForExit)
        {
            string result = null;
            Process proc = null;

            if (System.IO.File.Exists(file))
            {
                proc = new Process();
                proc.StartInfo.FileName = file;
                proc.StartInfo.ErrorDialog = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                if (mode == ProcessWindowStyle.Hidden)
                    proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = mode;
                proc.StartInfo.Arguments = arguments;

                proc.Start();

                if (waitForExit)
                {
                    result = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();
                }
            }
            else
            {
                Process.Start(file);
            }

            return proc;
        }

        public static void CreateShortcut(string target, string output)
        {
            if (!System.IO.File.Exists(target))
                throw new Exception("Impossible de créer le raccourci, le fichier suivant est introuvable :" + Environment.NewLine + target);

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(output);
            shortcut.TargetPath = target;
            shortcut.Save();

        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public static ImageSource XmlToImageSource(string xmlimg)
        {
            if (string.IsNullOrEmpty(xmlimg))
                return null;

            byte[] b = Convert.FromBase64String(xmlimg);

            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(b);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private static ImageSource GetAppIcon()
        {
            Icon i = Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);

            Bitmap bitmap = i.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();

            return
                 Imaging.CreateBitmapSourceFromHBitmap(
                      hBitmap, IntPtr.Zero, Int32Rect.Empty,
                      BitmapSizeOptions.FromEmptyOptions());
        }

        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            if (bitmap == null)
                return null;

            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }


    }
}
