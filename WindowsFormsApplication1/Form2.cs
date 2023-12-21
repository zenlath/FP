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
    public partial class Form2 : Form
    {
        private SqlCommand cmd;
        private SqlDataReader dr;

        Koneksi Konn = new Koneksi();
        public Form2()
        {
            InitializeComponent();
            LoadDataToComboBox1();
            LoadDataToComboBox2();
            comboBox3.Items.Add("15.30");
            comboBox3.Items.Add("17.00");
            comboBox3.Items.Add("18.30");
            comboBox3.Items.Add("20.00");
        }
        private void LoadDataToComboBox1()
        {
            // Gantilah YourConnectionString dengan string koneksi yang sesuai dengan database Anda
            SqlConnection conn = Konn.GetConn();

            conn.Open();
            cmd = new SqlCommand("SELECT judul FROM tb_film", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // Ambil nilai dari kolom "ColumnName"
                string value = dr["judul"].ToString();

                // Tambahkan nilai ke ComboBox
                comboBox1.Items.Add(value);
            }
            conn.Close();

        }
        private void LoadDataToComboBox2()
        {
            // Gantilah YourConnectionString dengan string koneksi yang sesuai dengan database Anda
            SqlConnection conn = Konn.GetConn();

            conn.Open();
            cmd = new SqlCommand("SELECT nama_bulan FROM tb_bulan", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // Ambil nilai dari kolom "ColumnName"
                string value = dr["nama_bulan"].ToString();

                // Tambahkan nilai ke ComboBox
                comboBox2.Items.Add(value);
            }
            conn.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUtama Form = new MenuUtama();
            Form.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection conn = Konn.GetConn();
            conn.Open();

          

            DialogResult result = MessageBox.Show("Apakah Anda yakin?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Periksa hasil dari MessageBox
            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox3.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox3.Text))
                {
                    MessageBox.Show("Tolong Isi Terlebih Dahulu!", "Kesalahan");
                    return;
                }

                // Tindakan yang akan diambil jika pengguna memilih "Ya"
                else
                {
                    string newValue1 = comboBox1.Text;
                    string newValue2 = comboBox2.Text;
                    string newValue3 = comboBox3.Text;
                    string newValue4 = textBox1.Text;
                    UpdateData(newValue1,newValue2, newValue3, newValue4);
                    this.Hide();
                    PilihKursi Form = new PilihKursi();
                    Form.ShowDialog();
                }
            }
            else
            {
                // Tindakan yang akan diambil jika pengguna memilih "Tidak"
                MessageBox.Show("Anda memilih 'Tidak'");
            }
            conn.Close();
            
        }
        private void UpdateData(string newValue1, string newValue2, string newValue3, string newValue4)
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();

           
            string iquery = "update tb_filmtampil SET film = @A, jam = @B, bulan = @C, tanggal = @D WHERE user_film = @Kondisi";
            SqlCommand commandDatabase = new SqlCommand(iquery, conn);
            commandDatabase.CommandTimeout = 60;
            using (SqlCommand command = new SqlCommand(iquery, conn))
            {
                // Tambahkan parameter untuk nilai baru dan kondisi
                command.Parameters.AddWithValue("@A", newValue1);
                command.Parameters.AddWithValue("@B", newValue2);
                command.Parameters.AddWithValue("@C", newValue3);
                command.Parameters.AddWithValue("@D", newValue4);
                command.Parameters.AddWithValue("@Kondisi", "saya"); // Ganti dengan nilai kondisi yang sesuai

           

                // Eksekusi query UPDATE
                int rowsAffected = command.ExecuteNonQuery();

                // Tampilkan pesan ke pengguna
                MessageBox.Show($"{rowsAffected} baris telah diupdate.");
            }
            try
            {
                SqlDataReader myReader = commandDatabase.ExecuteReader();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }
        


        }
}
