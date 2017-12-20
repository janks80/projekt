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

    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Jan Kajszczak\Desktop\C#\MyWallet\MyWallet\bin\config.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            SqlCommand command = new SqlCommand("select * from TableOptions", cnn);

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            textBox1.Text = reader.GetString(1);

        }
    }
}
