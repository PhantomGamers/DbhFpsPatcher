using PatternFinder;

using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DbhFpsPatcher
{
    internal static class Program
    {
        public static bool PatchFile(byte[] exe, long offset, string path)
        {
            using (MemoryStream memStream = new MemoryStream(exe))
            {
                float fps = Form1.GetFPSLimit();
                byte[] fpsLimit = fps > 0 ? BitConverter.GetBytes(1000.0f / Form1.GetFPSLimit()) : BitConverter.GetBytes(0);

                memStream.Seek(offset, SeekOrigin.Begin);
                memStream.Write(fpsLimit, 0, fpsLimit.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                Form1.IncrementProgress(1);

                DateTime then = DateTime.Now;
                while (IsFileLocked(path) && DateTime.Now - then < TimeSpan.FromSeconds(30))
                {
                    Form1.SetStatus("Waiting for file access...", System.Drawing.Color.YellowGreen);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (IsFileLocked(path))
                {
                    Form1.SetStatus("Error: Could not write to file.", System.Drawing.Color.Red);
                    return false;
                }
                Form1.SetStatus("Writing to disk...", System.Drawing.Color.YellowGreen);
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    memStream.CopyTo(fs);
                    fs.Flush();
                }
                Form1.SetStatus("Address patched!", System.Drawing.Color.Green);
                return true;
            }
        }

        public static void PatchFunction(string path)
        {
            if (IsFileLocked(path))
            {
                Form1.SetStatus("Error: Executable is locked. Can't patch.", System.Drawing.Color.Red);
                Form1.SetProgress(100, System.Drawing.Color.Red);
                return;
            }
            CheckBackup(path);
            byte[] exe = File.ReadAllBytes(path);
            var patterns = new Pattern.Byte[][] { Pattern.Transform("56 55 05 42 B0"),
                                                  Pattern.Transform("56 55 85 41 B0")};
            bool isPatched = true;
            foreach (Pattern.Byte[] pb in patterns)
            {
                if (!Pattern.Find(exe, pb, out long offsetFound))
                {
                    Form1.SetStatus("Error: FPS Limit could not be found. Already patched or unsupported version.", System.Drawing.Color.Red);
                    Form1.SetProgress(100, System.Drawing.Color.Red);
                    return;
                }
                if (!PatchFile(exe, offsetFound, path))
                {
                    Form1.SetStatus("Error: Executable file could not be patched.", System.Drawing.Color.Red);
                    isPatched = false;
                    break;
                }
            }
            if (isPatched)
                Form1.SetStatus("Game patched!", System.Drawing.Color.Green);
        }

        private static void CheckBackup(string path)
        {
            if (!File.Exists(path + ".bak"))
            {
                File.Copy(path, path + ".bak");
            }
            else
            {
                File.Delete(path);
                File.Copy(path + ".bak", path);
            }
        }

        private static bool IsFileLocked(string path)
        {
            FileInfo file = new FileInfo(path);
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Write, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            //file is not locked
            return false;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}