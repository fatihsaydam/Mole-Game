using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kostebek
{
    public partial class frmKostebekOyunu : Form
    {
        public frmKostebekOyunu()
        {
            InitializeComponent();
        }

        int _skor = 0;

        Random rd = new Random();



        private void frmKostebekOyunu_Load(object sender, EventArgs e)
        {
            //tmrKostebekBul.Stop();
        }



        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackColor == Color.Red)
            {
                _skor++;
                Text = "SKORUNUZ " + _skor.ToString();
            }

            else if(btn.BackColor==Color.White)
            {
                _skor--;
                Text = "SKORUNUZ " + _skor.ToString();
            }

            //Text = "SKORUNUZ " + _skor.ToString();

        }

        private void tmrKostebekBul_Tick(object sender, EventArgs e)
        {
            int butonSayisi = int.Parse(txtButonSayisi.Text);

            flpOyun.Controls.Clear();

            for (int i = 0; i < butonSayisi; i++)
            {
                Button btn = new Button();
                btn.Top = 0;
                btn.Left = 0;

                btn.Width = 50;
                btn.Height = 50;
                //btn.Name = "Köstebeği " + (i + 1) + ".butonda yakaladınız";
                btn.Text = (i + 1).ToString();

                flpOyun.Controls.Add(btn);
            }

            int eslesme = rd.Next(1, butonSayisi);

            foreach (var item in flpOyun.Controls)
            {
                Button btn = item as Button;
                if (btn.Text == eslesme.ToString())
                {
                    btn.BackColor = Color.Red;
                    //btn.BackgroundImage = Application.StartupPath + @"\..\..\kostebekk\kostebek1.png";
                    btn.Click += Btn_Click;
                }

                else
                {
                    btn.BackColor = Color.White;
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            tmrKostebekBul.Start();
        }
    }
}



