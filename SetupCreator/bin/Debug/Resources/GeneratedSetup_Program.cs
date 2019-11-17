using System;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;

namespace GeneratedSetupL
{

    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Hide
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            try
            {
            Assembly a;
            var name ="GeneratedSetup" + ".dll";
            using (var assemblyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                byte[] assemblyBuffer = new byte[assemblyStream.Length];
                assemblyStream.Read(assemblyBuffer, 0, assemblyBuffer.Length);
                a = Assembly.Load(assemblyBuffer);
            }

            Dictionary<string, Stream> setupFiles = new Dictionary<string, Stream>();
            foreach (string i in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
             // System.Windows.Forms.MessageBox.Show(i);
                if (i != "GeneratedSetup.dll")
                {
                    setupFiles.Add(i, Assembly.GetExecutingAssembly().GetManifestResourceStream(i));
                }

            }

            Type mainWindowType = a.GetTypes()[0];
            foreach (Type t in a.GetTypes())
            {
                if(t.Name == "SetupWindow")
                {
                    mainWindowType = t;
                    break;
                }
            }

            System.Windows.Window w = (System.Windows.Window) mainWindowType.GetConstructor(new Type[]{typeof(Dictionary<string, Stream>)}).Invoke(new object[]{setupFiles});
            w.ShowDialog();
            }
            catch(Exception e)
            {
                ShowWindow(handle, SW_SHOW);

                Console.Write(e);
                Console.Read();
            }
        }

    }
}