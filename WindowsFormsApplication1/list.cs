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
    public partial class list : UserControl
    {
        public list()
        {
            InitializeComponent();
        }

        private Image _icon;
        private string _title;
        private string _subs;
        private string _harga;

        public string Title
        {
            get { return _title; }
            set { _title = value; label1.Text = value; }
       
        }
        public string Subs
        {
            get { return _subs; }
            set { _subs = value; label2.Text = value; }
        
        }
        public string Harga
        {
            get { return _harga; }
            set { _harga = value; label3.Text = value; }

        }
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }

        }

        private void list_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        private void list_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.LightYellow;
        }

        private void list_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Gold;
        }

        private void list_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
