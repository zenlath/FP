using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MenuUtama : Form
    {
      
        public MenuUtama()
        {
            InitializeComponent();
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            userControl21.BringToFront();
            userControl31.Hide();
            userControl11.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            userControl31.Hide();
            userControl21.Show();
            userControl31.BringToFront();

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            userControl31.Show();
            userControl31.BringToFront();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl21.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl11.Show();
            userControl21.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
