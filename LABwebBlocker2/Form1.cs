using System;
using System.IO;
using System.Text;
using System.Windows.Forms;



namespace LABwebBlocker2
{
        public partial class Form1 : Form
    {
        private bool useFile, fileFound;
        private string file_entries;
        private string entries = "0.0.0.0 youtube.com www.youtube.com\n"+
                            "0.0.0.0 twitch.tv www.twitch.com\n"+
                            "0.0.0.0 movs4u.tv www.movs4u.tv\n"+
                            "0.0.0.0 twitter.com www.twitter.com\n"+
                            "0.0.0.0 aflam.io www.aflam.io\n"+
                            "0.0.0.0 dailymotion.com www.dailymotion.com\n"+
                            "0.0.0.0 vimeo.com www.vimeo.com\n"+
                            "0.0.0.0 metacafe.com www.metacafe.com\n"+
                            "0.0.0.0 d.tube www.d.tube\n"+
                            "0.0.0.0 whatsapp.com www.whatsapp.com web.whatsapp.com\n"+
                            "0.0.0.0 facebook.com www.facebook.com m.facebook.com\n" +
                            "0.0.0.0 instagram.com www.instagram.com\n"+
                            "0.0.0.0 ask.fm www.ask.fm\n"+
                            "0.0.0.0 myspace.com www.myspace.com\n"+
                            "0.0.0.0 veoh.com www.veoh.com\n"+
                            "0.0.0.0 fushaar.com www.fushaar.com\n"+
                            "0.0.0.0 te3b.com www.te3b.com\n"+
                            "0.0.0.0 9gag.com www.9gag.com\n"+
                            "0.0.0.0 tiktok.com www.tiktok.com\n"+
                            "0.0.0.0 netflix.com www.netflix.com\n"+
                            "0.0.0.0 flickr.com www.flickr.com\n"+
                            "0.0.0.0 hulu.com www.hulu.com\n"+
                            "0.0.0.0 cimaclub.com www.cimaclub.com\n"+
                            "0.0.0.0 mycima.me www.mycima.me\n"+
                            "0.0.0.0 cima4u.tv www.cima4u.tv\n"+
                            "0.0.0.0 movizland.com on.movizland.com www.movizland.com\n"+
                            "0.0.0.0 egbest2.com w.egbest2.com www.egbest2.com\n"+
                            "0.0.0.0 e3rfezai.com www.e3rfezai.com\n"
                            ;

        public Form1()
        {
            InitializeComponent();

        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            string blockContent = "";
            if (useFile && fileFound)
                blockContent = file_entries;
            else if (useFile && !fileFound)
            {
                MessageBox.Show("Please open file to use", "Error");
                return;
            }else
                blockContent = entries;


            if (ModifyHostsFile(blockContent))
            {
                string msg;
                msg = useFile? "Successfully blocked websites from text file" :"Successfully blocked websites";
                label1.ForeColor = System.Drawing.Color.Black;
                label1.Text = msg;
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.Orange;
                label1.Text = "Error! failed to block websites";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            string filePath = Path.Combine(Path.GetTempPath(), "blockList_websites.txt");
            //System.Diagnostics.Process.Start(filePath);
            //NotepadHelper.ShowMessage("My message...", "My Title");
        }


        public static bool ModifyHostsFile(string entry)
        {
            try
            {
                String hostPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
                System.IO.File.WriteAllText(hostPath, string.Empty);

                using (System.IO.StreamWriter w = System.IO.File.AppendText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts")))
                {
                    // clear hosts content
                    w.WriteLine(entry);
                    return true;
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool UnblockHostsFile()
        {
            try
            {
                String hostPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
                System.IO.File.WriteAllText(hostPath, string.Empty);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UnblockHostsFile())
            {
                Console.WriteLine("Successfully unblocked websites....");
                label1.ForeColor = System.Drawing.Color.Green;
                label1.Text = "Successfully unblocked websites";
                //Console.ReadLine();
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.Orange;
                label1.Text = "Error! failed to unblock websites";
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";

            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = openFileButton.Enabled = useFile = true;
                
            }
            else
            {
                textBox1.Enabled = openFileButton.Enabled = useFile = false;
                fileFound = false;
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            
   
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                string file = openFileDialog1.FileName;
                try
                {
                    if (file != null && file.Length != 0)
                    {
                        
                        string[] lines = File.ReadAllLines(file, Encoding.UTF8);
                        foreach (var line in lines)
                            file_entries += "\n0.0.0.0 "+line;
                        fileFound = true;
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error reading the file\n\n");
                }

                
                


            }



        }


    }
}


