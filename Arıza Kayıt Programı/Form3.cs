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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kayit.accdb");
        DataTable tablo = new DataTable();
        OleDbCommand kod = new OleDbCommand();
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
             try
            {
                bag.Open();
                kod.Connection = bag;
                this.Refresh();
                kod.CommandText = "INSERT INTO musteri(MusteriNo,ad,soyad,cep,email,adres) Values('" + maskedTextBox1.Text.ToString() +"','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox2.Text.ToString() + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                kod.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Kayıt İşlemi Tamamlanmıştır !", "Kayıt Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form2.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("KAYIT EDERKEN BİR HATA OLUŞTU. DİĞER FORM'A YÖNLENDİRİLİYORSUNUZ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form2.Show();
                this.Hide();
            }
        }
 }
}
