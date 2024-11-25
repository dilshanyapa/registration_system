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



namespace WindowsFormsApplication2
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.Reg_Button.Click += new System.EventHandler(this.button1_Click);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Your connection string (update with your SQL Server info)
            string connectionString = @"Data Source=DILSHAN-PC\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection Successful");

                    // Here, add code to insert data into the database
                    string query = "INSERT INTO Registration (regNo, firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, parentName, nic, contactNo) " +
                                   "VALUES (@regNo, @firstName, @lastName, @dateOfBirth, @gender, @address, @email, @mobilePhone, @homePhone, @parentName, @nic, @contactNo)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Set the parameters based on user inputs
                        cmd.Parameters.AddWithValue("@regNo", cmbRegNo.Text);
                        cmd.Parameters.AddWithValue("@firstName", FirstName.Text);
                        cmd.Parameters.AddWithValue("@lastName", LastName.Text);
                        
                        cmd.Parameters.AddWithValue("@dateOfBirth", Date.Value);
                       
                        cmd.Parameters.AddWithValue("@gender", Male.Checked ? "Male" : "Female");
                        
                        cmd.Parameters.AddWithValue("@address", Address.Text);
                        cmd.Parameters.AddWithValue("@email", Email.Text);
                        cmd.Parameters.AddWithValue("@mobilePhone", Mobile.Text);
                        cmd.Parameters.AddWithValue("@homePhone", Home.Text);
                        cmd.Parameters.AddWithValue("@parentName", ParemtName.Text);
                        cmd.Parameters.AddWithValue("@nic", NIC.Text);
                        cmd.Parameters.AddWithValue("@contactNo", PMobile.Text);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if insert was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration Successful!");
                        }
                        else
                        {
                            MessageBox.Show("Registration Failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DILSHAN-PC\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";
            try
            {
                // Define the SQL query to delete the record
                string query = "DELETE FROM Registration WHERE regNo = @regNo";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter
                        cmd.Parameters.AddWithValue("@regNo", Convert.ToInt32(cmbRegNo.Text));

                        // Confirm delete
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            // Execute the delete
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                MessageBox.Show("Record deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Delete failed.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear the ComboBox (RegNo)
            cmbRegNo.SelectedIndex = -1;

            // Clear all TextBox fields
            FirstName.Clear();  // First name field
            LastName.Clear();   // Last name field

            // Reset DateTimePicker to today's date
            Date.Value = DateTime.Now;

            // Uncheck Gender RadioButtons
            Male.Checked = false;
            Female.Checked = false;

            // Clear Contact Details
            Address.Clear();    // Address field
            Email.Clear();      // Email field
            Mobile.Clear();     // Mobile Phone field
            Home.Clear();       // Home Phone field

            // Clear Parent Details
            ParemtName.Clear();  // Parent Name field (Correct to "ParentName")
            NIC.Clear();         // NIC field
            PMobile.Clear();     // Parent's Mobile field

            // Set focus back to the first input field
            FirstName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DILSHAN-PC\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";
            try
            {
                // Define the SQL query to update the record
                string query = "UPDATE Registration SET firstName = @firstName, lastName = @lastName, dateOfBirth = @dateOfBirth, gender = @gender, address = @address, " +
                               "email = @email, mobilePhone = @mobilePhone, homePhone = @homePhone, parentName = @parentName, nic = @nic, contactNo = @contactNo " +
                               "WHERE regNo = @regNo";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@regNo", Convert.ToInt32(cmbRegNo.Text));
                        cmd.Parameters.AddWithValue("@firstName", FirstName.Text);
                        cmd.Parameters.AddWithValue("@lastName", LastName.Text);
                        cmd.Parameters.AddWithValue("@dateOfBirth", Date.Value);
                        cmd.Parameters.AddWithValue("@gender", Male.Checked ? "Male" : "Female");
                        cmd.Parameters.AddWithValue("@address", Address.Text);
                        cmd.Parameters.AddWithValue("@email", Email.Text);
                        cmd.Parameters.AddWithValue("@mobilePhone", Convert.ToInt32(Mobile.Text));
                        cmd.Parameters.AddWithValue("@homePhone", Convert.ToInt32(Home.Text));
                        cmd.Parameters.AddWithValue("@parentName", ParemtName.Text);
                        cmd.Parameters.AddWithValue("@nic", NIC.Text);
                        cmd.Parameters.AddWithValue("@contactNo", Convert.ToInt32(PMobile.Text));

                        // Execute the update
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Update successful!");
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DILSHAN-PC\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";
            
            try
            {
                string query = "SELECT regNo FROM Registration";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmbRegNo.Items.Add(reader["regNo"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
