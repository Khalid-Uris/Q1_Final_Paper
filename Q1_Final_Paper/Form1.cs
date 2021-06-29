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

namespace Q1_Final_Paper
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-153RETS;Initial Catalog=IUvplDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
       
        public Form1()
        {
            InitializeComponent();
            displayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into Post values('" +textBox1.Text + "','" + textBox2.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been saved in the database ");

            con.Close();
            //displayData();
            Clear();

            Form3 obj = new Form3();
            obj.Show();
            this.Hide();

        }
        public void displayData()
        {
            con.Open();

            adpt = new SqlDataAdapter("select * from Post", con);
            dt = new DataTable();
            adpt.Fill(dt);
            
            con.Close();
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            
        }
    }
}
