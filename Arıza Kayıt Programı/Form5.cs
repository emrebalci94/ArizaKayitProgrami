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
    public partial class Form5 : Form
    {
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kayit.accdb");
        DataTable tablo = new DataTable();
        OleDbCommand kod = new OleDbCommand();
        public Form5()
        {
            InitializeComponent();
        }
        private void sil()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            try
            {
                bag.Open();
                kod.Connection = bag;
                this.Refresh();
                kod.CommandText = "INSERT INTO ariza(musterino,tarih,ad,soyad,urunadi,serino,marka,model,garanti,gtarih,ctarih) Values('" + maskedTextBox1.Text.ToString() +"','"+maskedTextBox2.Text.ToString()+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text  + "','" + textBox4.Text + "','" + textBox5.Text +"','"+textBox6.Text +"','"+textBox7.Text +"','"+maskedTextBox3.Text.ToString()+"','"+ maskedTextBox4.Text .ToString()+ "')";
                kod.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Kayıt İşlemi Tamamlanmıştır !", "Kayıt Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form4.Show();
                this.Hide();
            }
            catch (Exception )
            {

                MessageBox.Show("Hata Oluştu. Lütfen Bilgilerinizi Kontrol Ediniz.","Arıza Kayıt",MessageBoxButtons.OK ,MessageBoxIcon.Error );
            }
        }
    }
}
