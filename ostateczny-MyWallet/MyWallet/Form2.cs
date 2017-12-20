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
    public partial class Form2 : Form
    {
        
        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private string kategoria;
        public string Kategoria
        {
            get { return kategoria; }
            set { kategoria = value; }
        }

        private int kwota;
        public int Kwota
        {
            get { return kwota; }
            set { kwota = value; }
        }

        public Form2()
        {
            InitializeComponent();

            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Jan Kajszczak\Desktop\C#\MyWallet\MyWallet\bin\Debug\Kategorie.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            SqlCommand command = new SqlCommand("select * from Kategorie", cnn);

            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string s = reader.GetString(1);
                comboBox1.Items.Add(s);
            }

            cnn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            data = Convert.ToDateTime(dateTimePicker1.Text);
            kategoria = comboBox1.Text;
            kwota = Convert.ToInt32(numericUpDown1.Value);

            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
