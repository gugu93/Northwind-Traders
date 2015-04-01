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

namespace NorthwindTraders
{
    
    public partial class Form1 : Form
    {
       SqlConnection myConnection = new SqlConnection("user id=Adrian;" + 
                                       "password=adrian;server=127.0.0.1;" + 
                                       "Trusted_Connection=yes;" + 
                                       "database=Northwind; " + 
                                       "connection timeout=30");
       SqlDataReader myReader = null;

       private void Form1_Load(object sender, EventArgs e)
       {
           // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
           this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

       }

        public Form1()
        {
            InitializeComponent();
            gridView1.Columns.Add("Index", "CustomerID");
            gridView1.Columns.Add("Value", "Company Name");
            gridView1.Columns.Add("Value", "Contact Name");
            gridView1.Columns.Add("Value", "Contact Title");
            gridView1.Columns.Add("Value", "Address");
            gridView1.Columns.Add("Value", "City");
            gridView1.Columns.Add("Value", "Region");
            gridView1.Columns.Add("Value", "Postal Code");
            gridView1.Columns.Add("Value", "Country");
            gridView1.Columns.Add("Value", "Phone");
            gridView1.Columns.Add("Value", "Fax");
        }

        public void completeTable()
        {
            gridView1.Rows.Clear();
            while (myReader.Read())
            {
                gridView1.Rows.Add(new object[] { myReader["CustomerID"].ToString(), myReader["CompanyName"].ToString(), myReader["ContactName"].ToString(),
                    myReader["ContactTitle"].ToString(), myReader["Address"].ToString(), myReader["City"].ToString(), myReader["Region"].ToString(), myReader["PostalCode"].ToString(),
                    myReader["Country"].ToString(), myReader["Phone"].ToString(), myReader["Fax"].ToString()});
            }
        }

        private void refresh()
        {
            try
            {
               myConnection.Open();
                string rb = "";
                if (radioButton1.Checked == true)
                {
                    rb = "CustomerID ASC";
                }
                else if (radioButton2.Checked == true)
                {
                    rb = "CustomerID DESC";
                }
                else if (radioButton3.Checked == true)
                {
                    rb = "CompanyName ASC";
                }
                else if (radioButton4.Checked == true)
                {
                    rb = "CompanyName DESC";
                }
                else if (radioButton5.Checked == true)
                {
                    rb = "ContactName ASC";
                }
                else if (radioButton6.Checked == true)
                {
                    rb = "ContactName DESC";
                }
                else rb = "CustomerID ASC";
                SqlCommand myCommand = new SqlCommand("EXEC dbo.orderByColumn '" + rb + "'",
                                                        myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();
            }
            catch (Exception ele)
            {
                MessageBox.Show(ele.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("EXEC dbo.orderByColumn 'CustomerID ASC'",
                                                            myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();           
                SelectionChanged();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                myConnection.Close();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("EXEC dbo.orderByColumn 'CustomerID DESC'",
                                                        myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();           
                SelectionChanged();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("EXEC dbo.orderByColumn 'CompanyName ASC'",
                                                            myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();                
                SelectionChanged();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("EXEC dbo.orderByColumn 'CompanyName DESC'",
                                                            myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();             
                SelectionChanged();           
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("EXEC dbo.orderByColumn 'ContactName ASC'",
                                                            myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();              
                SelectionChanged();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("EXEC dbo.orderByColumn 'ContactName DESC'",
                                                            myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();               
                SelectionChanged();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                String searchValue = textBox2.Text;
                string cmd = "EXEC dbo.UpdateCustomers '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox2.Text + "'";
                SqlCommand myCommand = new SqlCommand(cmd, myConnection);
                myCommand.ExecuteReader();
                myReader.Close();
                myConnection.Close();
                refresh();
                int rowIndex = -1;
                //String searchValue = myReader["CustomerID"].ToString();
                foreach (DataGridViewRow row in gridView1.Rows)
                {
                    // MessageBox.Show(row.Cells[0].Value.ToString());
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;

                        break;
                    }
                }
                gridView1.Rows[rowIndex].Selected = true;
                gridView1.FirstDisplayedScrollingRowIndex = gridView1.SelectedRows[0].Index;
                SelectionChanged();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = gridView1.CurrentCell.RowIndex - 1;
                myConnection.Open();
                string id = textBox2.Text;
                SqlCommand myCommand = new SqlCommand("EXEC dbo.DeleteCustomers '" + id + "'",
                                                            myConnection);
                myCommand.ExecuteReader();
                myReader.Close();
                myConnection.Close();
                refresh();
                if (selectedRow >= 0)
                    gridView1.Rows[selectedRow].Selected = true;
                else gridView1.Rows[selectedRow + 1].Selected = true;
                gridView1.FirstDisplayedScrollingRowIndex = gridView1.SelectedRows[0].Index;
                SelectionChanged();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {       
            try
            {
                myConnection.Open();
                string cmd = "EXEC dbo.InsertCustomers '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "'";
                SqlCommand myCommand = new SqlCommand(cmd, myConnection);
                myReader = myCommand.ExecuteReader();
                String searchValue = textBox2.Text;
                String searchValue2 = textBox3.Text;
                myConnection.Close();
                refresh();
                myReader.Close();
                int rowIndex = -1;
                foreach (DataGridViewRow row in gridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue)==false && row.Cells[1].Value.ToString().Equals(searchValue2)==true )
                    {                       
                        rowIndex = row.Index;
                        break;
                    }
                }               
                gridView1.Rows[rowIndex].Selected = true;
                gridView1.FirstDisplayedScrollingRowIndex = gridView1.SelectedRows[0].Index;
                SelectionChanged();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                //myConnection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button5_Click(object sender, EventArgs e)
        {          
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("EXEC dbo.SelectCustomers",
                                                        myConnection);
                myReader = myCommand.ExecuteReader();
                completeTable();
                myReader.Close();
                SelectionChanged();
            }
            catch (Exception ele)
            {
                MessageBox.Show(ele.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gridView1.Rows[32].Selected = true;
            myConnection.Open();
            myConnection.Close();
        }
        
        private void gridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }       

        private void gridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
            DataGridViewRow row = gridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
                textBox7.Text = row.Cells[5].Value.ToString();
                textBox8.Text = row.Cells[6].Value.ToString();
                textBox9.Text = row.Cells[7].Value.ToString();
                textBox10.Text = row.Cells[8].Value.ToString();
                textBox11.Text = row.Cells[9].Value.ToString();
                textBox12.Text = row.Cells[10].Value.ToString();
            
        }

        private void SelectionChanged()
        {
            DataGridViewRow row = gridView1.SelectedRows[0];
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[1].Value.ToString();
            textBox4.Text = row.Cells[2].Value.ToString();
            textBox5.Text = row.Cells[3].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            textBox7.Text = row.Cells[5].Value.ToString();
            textBox8.Text = row.Cells[6].Value.ToString();
            textBox9.Text = row.Cells[7].Value.ToString();
            textBox10.Text = row.Cells[8].Value.ToString();
            textBox11.Text = row.Cells[9].Value.ToString();
            textBox12.Text = row.Cells[10].Value.ToString();
        }
        
        /* 
          ALTER TABLE [dbo].[Orders] DROP    [FK_Orders_Customers];",
          USE Northwind;ALTER TABLE [dbo].[Orders]  WITH NOCHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]) ON DELETE CASCADE; 
          ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [FK_Order_Details_Orders];
          ALTER TABLE [dbo].[Order Details] WITH NOCHECK ADD  CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]) ON DELETE CASCADE;
        */
    }
}
