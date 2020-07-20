//Programmer: Austin Parker
//Date: July 3, 2020
//Assignment: Ch.14/ Bank Account/ PE1
//Purpose: Use database to store and display customer information from bank


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

namespace BankAcct

{

    public partial class Form1 : Form
    {
        SqlConnection connect;
        SqlDataAdapter data;

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //calling method to bindGrid()
            bindGrid();
        }

        //method to get connection
        public string getConnection()
        {
            //return connection string
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SampleDatabase.mdf;Integrated Security=True";
        }
        //method to bindgrid
        public void bindGrid()
        {
            //try catch block
            try
            {
                //creating obejct of connection class
                connect = new SqlConnection(getConnection());
                //dataAdapter object
                data = new SqlDataAdapter("select * from customers", connect);
                //creating object of DataTable
                DataTable dt = new DataTable("customers");
                //filling datatable
                data.Fill(dt);
                //using datatable as source with dt
                gridAccount.DataSource = dt;

            }

            //if any exception display this message
            catch (Exception except)
            {
                //display exception in messagebox
                MessageBox.Show(except.Message);
            }
        }

    }
}





