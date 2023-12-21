using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void GenerateDynamic()
        {
            flowLayoutPanel1.Controls.Clear();
            list[] listFilm = new list[6];

            string[] title = new string[6] { "Star Wars", "Fast And Furious", "The Counjuring", "Star Wars", "Fast And Furious", "The Counjuring" };
            string[] sub = new string[6] { "Bintang, seorang pemuda yang merasa lelah dengan rutinitas perkotaan, memutuskan untuk pulang ke desanya untuk merenggangkan diri. Selama kunjungannya, Bintang berharap untuk bertemu kembali dengan sahabat lamanya, Ferry, yang sangat dirindukannya sejak kecil.Namun, selain Ferry, Bintang juga memiliki sosok lain yang sangat ia cintai di desa, yaitu Devi. Devi, tanpa pengetahuannya, pernah menerima donor kornea mata dari Bintang. Ketika Bintang bertemu kembali dengan Devi di desa, ia merasa senang. Namun, ia terkejut ketika Devi bersikap sangat dingin dan tidak seperti dulu.", "Fast And Furious", "The Counjuring","Star Wars", "Fast And Furious", "The Counjuring" };
            string[] harga = new string[6] { "Star Wars", "Fast And Furious", "The Counjuring", "Star Wars", "Fast And Furious", "The Counjuring" };
            Image[] icon = new Image[6] { Properties.Resources.Rectangle_17, Properties.Resources.Rectangle_124, Properties.Resources.Rectangle_125, Properties.Resources.Rectangle_17, Properties.Resources.Rectangle_124, Properties.Resources.Rectangle_125 };

            for (int i = 0; i < listFilm.Length; i++)
            {
                listFilm[i] = new list();


                listFilm[i].Title = title[i];
                listFilm[i].Subs = sub[i];
                listFilm[i].Harga = harga[i];
                listFilm[i].Icon = icon[i];

                flowLayoutPanel1.Controls.Add(listFilm[i]);

                listFilm[i].Click += new System.EventHandler(this.UserControl1_Click);

            }
        }

            
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        void UserControl1_Click(object sender, EventArgs e)
        {
            list obj = (list)sender;
            label1.Text = obj.Title;
            richTextBox1.Text = obj.Subs;
            label3.Text = obj.Harga;
            pictureBox1.Image = obj.Icon;

            showpanel();

        }
        private void showpanel()
        {
            panel1.Visible = true;
        }
        private void hidepanel()
        {
            panel1.Visible = false;
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
            GenerateDynamic();
            hidepanel();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 regForm = new Form2();
            regForm.Show();
            this.Hide();
        }
    }
}
