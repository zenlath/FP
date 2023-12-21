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
    public partial class PilihKursi : Form
    {
        private SqlCommand cmd;
        private SqlDataReader dr;

        Koneksi Konn = new Koneksi();
        public PilihKursi()
        {
            InitializeComponent();
            LoadDataToComboBox();
        }

        private void PilihKursi_Load(object sender, EventArgs e)
        {

        }
        private void LoadDataToComboBox()
        {
            // Gantilah YourConnectionString dengan string koneksi yang sesuai dengan database Anda
            SqlConnection conn = Konn.GetConn();



            conn.Open();
            cmd = new SqlCommand("SELECT no_kursi FROM tb_kursi", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // Ambil nilai dari kolom "ColumnName"
                string value = dr["no_kursi"].ToString();

                // Tambahkan nilai ke ComboBox
                comboBox1.Items.Add(value);
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = Konn.GetConn();
            conn.Open();
            DialogResult result = MessageBox.Show("Apakah Anda yakin?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Tolong Isi Terlebih Dahulu!", "Kesalahan");
                    return;
                }

                // Tindakan yang akan diambil jika pengguna memilih "Ya"
                else
                {
                    string newValue = comboBox1.Text;
                    UpdateData(newValue);
                    MessageBox.Show("Kursi Telah Terpilih!");
                    conn.Close();
                }
            }
            else
            {
                // Tindakan yang akan diambil jika pengguna memilih "Tidak"
                MessageBox.Show("Anda memilih 'Tidak'");
            }
        }
        private void UpdateData(string newValue)
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();


            string iquery = "update tb_filmtampil SET kursi = @E WHERE user_film = @Kondisi";
            SqlCommand commandDatabase = new SqlCommand(iquery, conn);
            commandDatabase.CommandTimeout = 60;
            using (SqlCommand command = new SqlCommand(iquery, conn))
            {
                // Tambahkan parameter untuk nilai baru dan kondisi
                command.Parameters.AddWithValue("@E", newValue);
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
    

    

