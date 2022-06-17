using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-LHK17QQH;Initial Catalog=ExeCRUD;User ID=sa;Password=Dhani030117 ");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int karid = int.Parse(textBox1.Text);
            string karname = textBox2.Text, alamat = comboBox1.Text, kontak = textBox4.Text, Jenis_Kelamin = "";
            double umur = double.Parse(textBox3.Text);
            DateTime tglbrgbg = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { Jenis_Kelamin = "Pria"; } else { Jenis_Kelamin = "Perempuan"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec Add_Kar '" + karid + "','" + karname + "','" + alamat + "','" + kontak + "','" + umur + "','" + Jenis_Kelamin + "','" + tglbrgbg + "',", con);
            MessageBox.Show("Berhasil Ditambahkan");
            GetKarList();
            c.ExecuteNonQuery();
        }
        void GetKarList()
        {
            SqlCommand c = new SqlCommand("exec List_Kar", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exeCRUDDataSet.Karyawan' table. You can move, or remove it, as needed.
            this.karyawanTableAdapter.Fill(this.exeCRUDDataSet.Karyawan);
            GetKarList();
        }
    }
}
