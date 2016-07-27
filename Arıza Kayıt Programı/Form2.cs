using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Arıza_Kayıt_Programı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kayit.accdb");
        DataTable tablo = new DataTable();
        OleDbCommand kod = new OleDbCommand();
        private void listele() {
            bag.Close();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From musteri",bag);
            bag.Open();
            tablo.Clear();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
            this.AcceptButton = button2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From musteri Where MusteriNo='" + textBox1.Text + "'", bag);
                bag.Open();
                tablo.Clear();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                bag.Close();
                MessageBox.Show("Arama Sonuçlandırıldı !", "ARAMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                       MessageBox.Show("BİR HATA OLUŞTU.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }    
    }
}
