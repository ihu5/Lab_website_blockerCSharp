using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LABwebBlocker2
{
        public partial class Form1 : Form
    {
        string entries = "127.0.0.1 youtube.com www.youtube.com" + "\n" +
                            "127.0.0.1 twitch.tv www.twitch.com" + "\n" +
                            "127.0.0.1 movs4u.tv www.movs4u.tv" + "\n" +
                            "127.0.0.1 twitter.com www.twitter.com" + "\n" +
                            "127.0.0.1 aflam.io www.aflam.io" + "\n" +
                            "127.0.0.1 dailymotion.com www.dailymotion.com" + "\n" +
                            "127.0.0.1 vimeo.com www.vimeo.com" + "\n" +
                            "127.0.0.1 metacafe.com www.metacafe.com" + "\n" +
                            "127.0.0.1 d.tube www.d.tube" + "\n" +
                            "127.0.0.1 whatsapp.com www.whatsapp.com web.whatsapp.com" + "\n" +
                            "127.0.0.1 facebook.com www.facebook.com" + "\n" +
                            "127.0.0.1 instagram.com www.instagram.com" + "\n" +
                            "127.0.0.1 ask.fm www.ask.fm" + "\n" +
                            "127.0.0.1 myspace.com www.myspace.com" + "\n" +
                            "127.0.0.1 veoh.com www.veoh.com" + "\n" +
                            "127.0.0.1 fushaar.com www.fushaar.com" + "\n" +
                            "127.0.0.1 te3b.com www.te3b.com" + "\n" +
                            "127.0.0.1 9gag.com www.9gag.com";

        public Form1()
        {
            InitializeComponent();
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
           
            if (ModifyHostsFile(entries))
            {
                Console.WriteLine("Successfully blocked websites....");
                label1.ForeColor = System.Drawing.Color.Green;
                label1.Text = "Successfully blocked websites";
                //Console.ReadLine();
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "Error! failed to block websites";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
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
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "Error! failed to unblock websites";
            }

        }
    }
}


