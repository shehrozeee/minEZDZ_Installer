using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;


namespace mintu_Installer
{
    public partial class Form1 : Form
    {
        Form2 splash = new Form2();
        public Form1()
        {
            InitializeComponent();
            splash.ShowDialog();
            
        }
        private const string MenuName = "*\\shell\\Send via IRC dcc";
        private const string Command = "*\\shell\\Send via IRC dcc\\command";
        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mini_Ninja"))
            { }
            else
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mini_Ninja");
                    
            FileStream mintu = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Mini_Ninja\\minDU.exe", FileMode.Create);
            mintu.Write(global::mintu_Installer.Properties.Resources.Mini_Ninja_IRC_DCC_utility, 0, global::mintu_Installer.Properties.Resources.Mini_Ninja_IRC_DCC_utility.Length);
            mintu.Close();
            RegistryKey regmenu = null;
            RegistryKey regcmd = null;
            try
            {
                regmenu = Registry.ClassesRoot.CreateSubKey(MenuName);
                if (regmenu != null)
                    regmenu.SetValue("", "Send via IRC dcc !");
                regcmd = Registry.ClassesRoot.CreateSubKey(Command);
                if (regcmd != null)
                    regcmd.SetValue("",Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\Mini_Ninja\\minDU.exe %1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Its embarasing but an error occoured\nRun the installer in admin mode\nRight-Click on installer exe and select\n'Run as Administrator'\nIf problem persists Contact Mini_Ninja on IRC", "OOooppppssss.Its Embarasing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (regmenu != null)
                    regmenu.Close();
                if (regcmd != null)
                    regcmd.Close();
                return;
            }
            finally
            {
                if (regmenu != null)
                    regmenu.Close();
                if (regcmd != null)
                    regcmd.Close();
            }
            MessageBox.Show("MinDU Installed succesfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Thankyou for installing mintDU (Mini_Ninja IRC Easy DCC Utility)\nRight-Click on wanted file and select 'Send via IRC dcc !'\nDrop a thanks msg @ Mini_Ninja on IRC if this app\nhelps you out", "Thanks", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    RegistryKey reg = Registry.ClassesRoot.OpenSubKey(Command);
                    if (reg != null)
                    {
                        reg.Close();
                        Registry.ClassesRoot.DeleteSubKey(Command);
                    }
                    reg = Registry.ClassesRoot.OpenSubKey(MenuName);
                    if (reg != null)
                    {
                        reg.Close();
                        Registry.ClassesRoot.DeleteSubKey(MenuName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString());
                }
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mini_Ninja\\minDU.exe");
            }
            catch 
            {

            }
            MessageBox.Show("Mintu Uninstalled succesfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("minDU (Mini_Ninja IRC Easy DCC)\nRight-Click on wanted file and select 'Send via IRC dcc !'\nDrop a thanks msg @ Mini_Ninja on IRC if this app\nhelps you out", "What is minDU ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
