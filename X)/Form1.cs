using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool turn_player; // player 1= false, player 2= true

        public Image S1 = Properties.Resources.x1; //image player 1
        public Image S2 = Properties.Resources.o; //image player 2

        public Panel selected_panel;
        public List<String> panel_images = new List<String>();

        string result; // result string <- goh

        private void Form1_Load(object sender, EventArgs e)
        {
            turn_player = false;
            panel_images.Clear();
        }

        private void check_win()
        {
            get_all_info();

            // player 1
            if (panel1.BackgroundImage == S1 &&
                panel2.BackgroundImage == S1 &&
                panel3.BackgroundImage == S1 ||

                panel4.BackgroundImage == S1 &&
                panel5.BackgroundImage == S1 &&
                panel6.BackgroundImage == S1 ||

                panel7.BackgroundImage == S1 &&
                panel8.BackgroundImage == S1 &&
                panel9.BackgroundImage == S1 ||

                panel1.BackgroundImage == S1 &&
                panel5.BackgroundImage == S1 &&
                panel9.BackgroundImage == S1 ||

                panel3.BackgroundImage == S1 &&
                panel5.BackgroundImage == S1 &&
                panel7.BackgroundImage == S1 ||

                panel1.BackgroundImage == S1 &&
                panel4.BackgroundImage == S1 &&
                panel7.BackgroundImage == S1 ||

                panel2.BackgroundImage == S1 &&
                panel5.BackgroundImage == S1 &&
                panel8.BackgroundImage == S1 ||

                panel3.BackgroundImage == S1 &&
                panel6.BackgroundImage == S1 &&
                panel9.BackgroundImage == S1)
            {
                MessageBox.Show("WIN player 1");
                start_new();
            }

            // player 2
            if (panel1.BackgroundImage == S2 &&
                panel2.BackgroundImage == S2 &&
                panel3.BackgroundImage == S2 ||

                panel4.BackgroundImage == S2 &&
                panel5.BackgroundImage == S2 &&
                panel6.BackgroundImage == S2 ||

                panel7.BackgroundImage == S2 &&
                panel8.BackgroundImage == S2 &&
                panel9.BackgroundImage == S2 ||

                panel1.BackgroundImage == S2 &&
                panel5.BackgroundImage == S2 &&
                panel9.BackgroundImage == S2 ||

                panel3.BackgroundImage == S2 &&
                panel5.BackgroundImage == S2 &&
                panel7.BackgroundImage == S2 ||

                panel1.BackgroundImage == S2 &&
                panel4.BackgroundImage == S2 &&
                panel7.BackgroundImage == S2 ||

                panel2.BackgroundImage == S2 &&
                panel5.BackgroundImage == S2 &&
                panel8.BackgroundImage == S2 ||

                panel3.BackgroundImage == S2 &&
                panel6.BackgroundImage == S2 &&
                panel9.BackgroundImage == S2)
            {
                MessageBox.Show("WIN player 2");
                start_new();
            }

        }

        private void start_new()
        {
            foreach (Panel p in this.Controls.OfType<Panel>())
            {
                p.BackgroundImage = null;
            }
            turn_player = false;
            panel_images.Clear();


        }

        private void get_all_info()
        {
            panel_images.Clear();

            foreach (Panel p in this.Controls.OfType<Panel>())
            {
                if (p.BackgroundImage != null)
                {
                    if (p.BackgroundImage == S1)
                    {
                        panel_images.Add(p.Name.ToString() + " - S1");
                    }
                    if (p.BackgroundImage == S2)
                    {
                        panel_images.Add(p.Name.ToString() + " - S2");
                    }
                }
            }
        }
        private void PANEL_Click(object sender, EventArgs e)
        {
            if (turn_player==false) // player 1
            {
                selected_panel = sender as Panel;

                if (selected_panel.BackgroundImage == null)
                {
                    selected_panel.BackgroundImage = S1;
                    check_win();
                    turn_player = true;
                }
                else
                {
                    return;
                }
            }
            else // player 2
            {
                selected_panel = sender as Panel;

                if (selected_panel.BackgroundImage == null)
                {
                    selected_panel.BackgroundImage = S2;
                    check_win();
                    turn_player = false;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
