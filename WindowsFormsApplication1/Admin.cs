using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Admin : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi konn = new Koneksi();
        public Admin()
        {
            InitializeComponent();
           
        }

       
        void TampilkanData()
        {
            SqlConnection con = konn.GetConn();
            try
            {
                con.Open();
                cmd = new SqlCommand("Select user_film, film, jam, bulan, tanggal, kursi from tb_filmtampil", con);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tb_filmtampil");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tb_filmtampil";
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                con.Close();
            }
        }
       

      

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = konn.GetConn();

                {
                    cmd = new SqlCommand("DELETE tb_filmtampil where user_film = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("HAPUS DATA BERHASIL");
                    TampilkanData();
                   
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["user_film"].Value.ToString();
                textBox2.Text = row.Cells["film"].Value.ToString();
                textBox3.Text = row.Cells["jam"].Value.ToString();
                textBox4.Text = row.Cells["bulan"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 FrmUtama = new Form3();
            FrmUtama.Show();
        }
    }
}