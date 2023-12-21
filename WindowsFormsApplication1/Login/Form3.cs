using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form

    {
        private SqlCommand cmd;
        private SqlDataReader dr;

        Koneksi Konn = new Koneksi();
        public Form3()
        {
            InitializeComponent();
          
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "adminuwu")
            {
                this.Hide();
                Admin FrmUtama = new Admin();
                FrmUtama.Show();
                MessageBox.Show("Selamat Datang Admin");
            }

            SqlConnection conn = Konn.GetConn();
            conn.Open();


            cmd = new SqlCommand("SELECT * from TB_user where Nama_user = '" + textBox1.Text + "' and Pass_user = '" + textBox2.Text + "'", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                MenuUtama frmUtama = new MenuUtama();
                frmUtama.Show();
                this.Hide();
                conn.Close();

                conn.Open();
                string iquery = "INSERT INTO tb_filmtampil(user_film) values ('" + textBox1.Text + "')";
                SqlCommand commandDatabase = new SqlCommand(iquery, conn);
                commandDatabase.CommandTimeout = 60;
                
                try
                {
                    SqlDataReader myReader = commandDatabase.ExecuteReader();
                }

                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }
                conn.Close();


            }
           
            else
            {
                label2.Visible = true;
            }
            


        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormReg regForm = new FormReg();
            regForm.Show();
            this.Hide(); 
        }
    }
}
