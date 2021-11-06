using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace bahbah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
			//hide in sys tray
            InitializeComponent();
            reduce();


            //create right click menu
            this.components = new System.ComponentModel.Container();
            this.ContextMenu = new System.Windows.Forms.ContextMenu();
			
			//create menu item "exit"
            MenuItem menuItem1 = new System.Windows.Forms.MenuItem();
            menuItem1.Index = 0;
            menuItem1.Text = "E&xit";
            menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Notify Icon Example";
            ContextMenu.MenuItems.Add(menuItem1);
            BahBah_ico.ContextMenu = this.ContextMenu;

            //When startup is finished, play sound
            BahBah_ico_MouseDoubleClick(this, new MouseEventArgs(MouseButtons.Left,2,0,0,100));
        }

		//handle exit menu click
        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BahBah_ico_MouseDoubleClick(object sender, MouseEventArgs e)
        {
			//play sound on double click
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.bahbah);
            player.Play();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reduce();
        }

        private void reduce()
        {
            Hide();
            BahBah_ico.Visible = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }
    }

    
}
