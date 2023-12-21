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
    public partial class FormReg : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi konn = new Koneksi();
        public FormReg()
        {
            InitializeComponent();
        }

        private void FormReg_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Female");
            comboBox1.Items.Add("Male");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!this.textBox4.Text.Contains('@') || !this.textBox4.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            else
            {
                SqlConnection conn = konn.GetConn();
                conn.Open();

                cmd = new SqlCommand("SELECT * FROM TB_user WHERE Nama_user = @UserName", conn);
                cmd = new SqlCommand("SELECT * FROM TB_user WHERE Email_user = @UserEmail", conn);


                cmd.Parameters.AddWithValue("@UserName", textBox2.Text);
                cmd.Parameters.AddWithValue("@UserEmail", textBox4.Text);

                bool userExists = false, mailExists = false;

                using (var dr1 = cmd.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Username not available!");

                using (var dr2 = cmd.ExecuteReader())
                    if (mailExists = dr2.HasRows) MessageBox.Show("Email not available!");


                if (!(userExists || mailExists))
                {

                    string iquery = "INSERT INTO TB_user(Kode_user,Nama_user,NamaLengkap_user,Pass_user,Gender_user,Email_user) values ('" + textBox5.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "')";
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

                    MessageBox.Show("Account Successfully Created!");

                }

                conn.Close();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 formlogin = new Form3();
            formlogin.Show();
        }
    }
}
