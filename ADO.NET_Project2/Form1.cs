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

namespace ADO.NET_Project2
{
    public partial class Form1 : Form
    {
        // Connection String
        string ConStr = "Data Source = DESKTOP-T4LB3IA\\SQLEXPRESS; Initial Catalog = STUDENT; Integrated Security = True;";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConStr);

            try
            {
                string AddCustomersql = @"Insert Into CUSTOMER (CUS_ID, CUS_NAME, PAY_METHOD,ADDRESS)
                                   VALUES( @CUSID, @CUSNAME, @PAYMETHOD,@ADDRESS )";

                SqlCommand cmd = new SqlCommand(AddCustomersql, con);

                cmd.Parameters.AddWithValue("@CUSID", txtCusId.Text);
                cmd.Parameters.AddWithValue("@CUSNAME", txtCusName.Text);
                cmd.Parameters.AddWithValue("@PAYMETHOD", txtPayMethod.Text);
                cmd.Parameters.AddWithValue("@ADDRESS", txtAddress.Text);

                con.Open();

                int rowEffected = cmd.ExecuteNonQuery();

                if (rowEffected > 0)
                {
                    MessageBox.Show("Record Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("Record Was Not Inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured : "+ ex);
            }
            finally 
            {
                con.Close();
            } 
        }
    }
}
