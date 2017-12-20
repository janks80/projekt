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

namespace MyWallet
{
    public partial class Form1 : Form
    {

        List<Transaction> transaction = new List<Transaction>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            else
            {
                Transaction s = new Transaction();
                s.Data =  frm.Data;
                s.Kategoria = frm.Kategoria;
                s.Kwota = frm.Kwota;

                transaction.Add(s);
                ViewData();



            }
        }

        private void SaveData()
        {

            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Jan Kajszczak\Desktop\C#\MyWallet\MyWallet\bin\Debug\Kategorie.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            SqlCommand command = new SqlCommand("select * from [Table]", cnn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
            }

            cnn.Close();

        }

        private void ViewData()
        {

            dataGridView1.Rows.Clear();

            foreach (Transaction s in transaction)
            {

                int ind = dataGridView1.Rows.Add();

                dataGridView1.Rows[ind].Cells[0].Value = s.Data;
                dataGridView1.Rows[ind].Cells[1].Value = s.Kategoria;
                dataGridView1.Rows[ind].Cells[2].Value = s.Kwota;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();

            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();

            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            transaction.Clear();

            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Jan Kajszczak\Desktop\C#\MyWallet\MyWallet\bin\Debug\Kategorie.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            SqlCommand command = new SqlCommand("select * from [Table]", cnn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Transaction s = new Transaction();
                s.Data = reader.GetDateTime(1);
                s.Kategoria = reader.GetString(2);
                s.Kwota = reader.GetInt32(3);

                transaction.Add(s);

            }
            
            ViewData();

            cnn.Close();
        }

    }
}
