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
    public partial class Form4 : Form
    {
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kayit.accdb");
        DataTable tablo = new DataTable();
        OleDbCommand kod = new OleDbCommand();
        private void listele()
        {
            bag.Close();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From ariza", bag);
            bag.Open();
            tablo.Clear();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

  

        private void textBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
            this.AcceptButton = button2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
                this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From ariza Where MusteriNo='" + textBox1.Text + "'", bag);
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

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
