using System;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace FTP
{
   
    public partial class Form1 : Form
    {
        
        string f1 = "D:\\", f2 = "D:\\c", f3 = "E:\\d", f4 = "E:\\";

        string fileDown="";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                label1.Text = OFD.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(textBox2.Text, textBox3.Text);
                Byte[] b = client.UploadFile(textBox1.Text, label1.Text);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error of loading data" + label1.Text + "is occurred","Error");
            }

        }

        public void button3_Click(object sender, EventArgs e)
        {
                string Folder = textBox1.Text; //Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                WebClient client = new WebClient();

                DriveInfo d1 = new DriveInfo(@f1), d2 = new DriveInfo(@f2), d3 = new DriveInfo(@f3), d4 = new DriveInfo(@f4);
                double F1free = (d1.AvailableFreeSpace / 1024) / 1024;
                double F2free = (d2.AvailableFreeSpace / 1024) / 1024;
                double F3free = (d3.AvailableFreeSpace / 1024) / 1024;
                double F4free = (d4.AvailableFreeSpace / 1024) / 1024;

                if ((F1free >= F2free) && (F1free >= F3free) && (F1free >= F4free))
                {
                    try
                    {
                        
                        using (WebClient webClient = new WebClient())
                        {
                            //Set the banner variable
                            int i = label1.Text.LastIndexOf("\\");
                            fileDown = label1.Text.Substring(label1.Text.LastIndexOf("\\") + 1, label1.Text.Length - label1.Text.LastIndexOf("\\")-1);
                            webClient.DownloadFile(Folder, label1.Text);
                            File.Copy(label1.Text,@"d:\downloaded\"+fileDown);
                        }
                       
                        label4.Text = "Downloaded to " + f1;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error of downloading data " + f1 + " is occurred", "Error");
                    }
                }
                else if ((F2free >= F1free) && (F2free >= F3free) && (F2free >= F4free))
                {
                    try
                    {
                        client.DownloadFile(Folder, label1.Text);
                        int i = label1.Text.LastIndexOf("\\");
                        fileDown = label1.Text.Substring(label1.Text.LastIndexOf("\\") + 1, label1.Text.Length - label1.Text.LastIndexOf("\\") - 1);
                        client.DownloadFile(Folder, label1.Text);
                        File.Copy(label1.Text, @"d:\downloaded\" + fileDown);
                        label4.Text = "Downloaded to " + f2;
                    }
                    catch
                    {
                        MessageBox.Show("Error of downloading data " + f2 + " is occurred", "Error");
                    }
                }
                else if ((F3free >= F1free) && (F3free >= F2free) && (F3free >= F4free))
                {
                    try
                    {
                        client.DownloadFile(Folder, label1.Text);
                        int i = label1.Text.LastIndexOf("\\");
                        fileDown = label1.Text.Substring(label1.Text.LastIndexOf("\\") + 1, label1.Text.Length - label1.Text.LastIndexOf("\\") - 1);
                        client.DownloadFile(Folder, label1.Text);
                        File.Copy(label1.Text, @"d:\downloaded\" + fileDown);
                        label4.Text = "Downloaded to " + f2;
                    }
                    catch
                    {
                        MessageBox.Show("Error of downloading data " + f2 + " is occurred", "Error");
                    }
                }
                else if ((F4free >= F1free) && (F4free >= F2free) && (F4free >= F3free))
                {
                    try
                    {
                        client.DownloadFile(Folder, label1.Text);
                        int i = label1.Text.LastIndexOf("\\");
                        fileDown = label1.Text.Substring(label1.Text.LastIndexOf("\\") + 1, label1.Text.Length - label1.Text.LastIndexOf("\\") - 1);
                        client.DownloadFile(Folder, label1.Text);
                        File.Copy(label1.Text, @"d:\downloaded\" + fileDown);
                        label4.Text = "Downloaded to " + f2;
                    }
                    catch
                    {
                        MessageBox.Show("Error of downloading data " + f2 + " is occurred", "Error");
                    }                 
                }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void getXML_Click(object sender, EventArgs e)
        {
            
                   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
