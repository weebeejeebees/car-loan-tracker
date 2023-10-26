using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace carloantracker
{
    public partial class Form1 : Form
    {

        koneksyon kon = new koneksyon();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rd;

        double dpRate = 0.3;
        double interestRate = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float m2p = float.Parse(textBox10.Text);
                float price = float.Parse(textBox9.Text);
                float tp = (float)price * (m2p * 2.0f / 100.0f) + (float)price; // total price formula
                float dp = (float)(0.3 * price); // down payment formula
                float rb = (float)tp - dp; // remaining balance
                int age = int.Parse(textBox3.Text);
                long cn = long.Parse(textBox12.Text);

                Console.WriteLine(tp);
                Console.WriteLine(dp);
                Console.WriteLine(rb);


                conn = kon.getCon();
                conn.Open();
                cmd = new SqlCommand("INSERT INTO loans (firstName, lastName, age, contactNumber, address, loanDateStart, carBrand, carModel, yearModel, plateNumber, totalPrice, monthsToPay, downPayment, remainingBalance) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', " + age + ", " + cn + ", '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox13.Text + "', " + tp + ", " + m2p + ", " + dp + ", " + rb + ")", conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("New record saved");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";

                cmd.Dispose();
                conn.Close();
                button4_Click(sender, e);
            }

            catch
            {
                MessageBox.Show("Check your inputs! Something might be in an incorrect format!");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = kon.getCon();
            conn.Open();

            cmd = new SqlCommand("select * from loans where id = '" + textBox11.Text + "'", conn);
            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    textBox1.Text = rd["firstName"].ToString();
                    textBox2.Text = rd["lastName"].ToString();
                    textBox3.Text = rd["age"].ToString();
                    textBox4.Text = rd["address"].ToString();
                    textBox5.Text = rd["loanDateStart"].ToString();
                    textBox6.Text = rd["carBrand"].ToString();
                    textBox7.Text = rd["carModel"].ToString();
                    textBox8.Text = rd["yearModel"].ToString();
                    textBox9.Text = rd["totalPrice"].ToString();
                    textBox10.Text = rd["monthsToPay"].ToString();
                    textBox12.Text = rd["contactNumber"].ToString();
                    textBox13.Text = rd["plateNumber"].ToString();

                }

                MessageBox.Show("Record(s) found!");
            }
            else
            {
                MessageBox.Show("No results found.");
            }

            cmd.Dispose();
            rd.Close();
            conn.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                float m2p = float.Parse(textBox10.Text);
                float price = float.Parse(textBox9.Text);
                float tp = (float)price * (m2p * 2.0f / 100.0f) + (float)price; // total price formula
                float dp = (float)(0.3 * price); // down payment formula
                float rb = (float)tp - dp; // remaining balance
                int age = int.Parse(textBox3.Text);
                int id = int.Parse(textBox11.Text);
                long cn = long.Parse(textBox12.Text);


                conn = kon.getCon();
                conn.Open();

                cmd = new SqlCommand("update loans set firstName = '" + textBox1.Text + "', lastName = '" + textBox2.Text + "' , age = '" + age + "' , contactNumber = '" + cn + "' , address = '" + textBox4.Text + "' , loanDateStart = '" + textBox5.Text + "' , carBrand = '" + textBox6.Text + "' , carModel = '" + textBox7.Text + "' , yearModel = '" + textBox8.Text + "' , plateNumber = '" + textBox13.Text + "' ,  totalPrice = '" + tp + "' , monthsToPay = '" + m2p + "' , downPayment = '" + dp + "' , remainingBalance = '" + rb + "' where id = '" + id + "'", conn);
                cmd.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";

                MessageBox.Show("Record(s) updated!");
                cmd.Dispose();
                conn.Close();
                button4_Click(sender, e);
            }

            catch
            {
                MessageBox.Show("Check your inputs! Something might be in an incorrect format!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = kon.getCon();
            conn.Open();
            cmd = new SqlCommand("select * from loans" , conn);
            rd = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();
            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString (), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString(), rd[9].ToString(), rd[10].ToString(), rd[11].ToString(), rd[12].ToString(), rd[13].ToString(), rd[14].ToString());
            }
            cmd.Dispose();
            rd.Close();
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn = kon.getCon();
                conn.Open();
                int id = int.Parse(textBox11.Text);  // Assuming textBox11 contains the ID of the row to be deleted

                // Check if the record exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM loans WHERE id = @Id", conn);
                checkCmd.Parameters.AddWithValue("@Id", id);
                int recordCount = (int)checkCmd.ExecuteScalar();
                if (recordCount == 0)
                {
                    MessageBox.Show("Record with the specified ID does not exist.");
                }
                else
                {
                    // SQL command to delete the row based on the ID
                    cmd = new SqlCommand("DELETE FROM loans WHERE id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";

                    MessageBox.Show("Record deleted!");
                    cmd.Dispose();
                    button4_Click(sender, e);
                }
                checkCmd.Dispose();
            }
            catch
            {
                MessageBox.Show("Check your inputs! Type the correct ID!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private DataTable GetDataFromDatabase(int selectedId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                conn = kon.getCon();
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM loans WHERE id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", selectedId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return dataTable;
        }

        // Method to generate PDF
        private void GeneratePDF(DataTable data)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("output.pdf", FileMode.Create));

            // Set up the font and style
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 5, iTextSharp.text.Font.NORMAL);

            doc.Open();

            // Create a table with 15 columns
            PdfPTable table = new PdfPTable(15);
            table.WidthPercentage = 110;

            // Set the width for each column
            float[] columnWidths = new float[] { 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f };
            table.SetWidths(columnWidths);

            // Add headers to the table with defined font
            table.AddCell(new Phrase("ID", font));
            table.AddCell(new Phrase("First Name", font));
            table.AddCell(new Phrase("Last Name", font));
            table.AddCell(new Phrase("Age", font));
            table.AddCell(new Phrase("Contact Number", font));
            table.AddCell(new Phrase("Address", font));
            table.AddCell(new Phrase("Loan Date Start", font));
            table.AddCell(new Phrase("Car Brand", font));
            table.AddCell(new Phrase("Car Model", font));
            table.AddCell(new Phrase("Year Model", font));
            table.AddCell(new Phrase("Plate Number", font));
            table.AddCell(new Phrase("Total Price", font));
            table.AddCell(new Phrase("Months to Pay", font));
            table.AddCell(new Phrase("Down Payment", font));
            table.AddCell(new Phrase("Remaining Balance", font));

            // Add data to the table with defined font
            foreach (DataRow row in data.Rows)
            {
                table.AddCell(new Phrase(row[0].ToString(), font));
                table.AddCell(new Phrase(row["firstName"].ToString(), font));
                table.AddCell(new Phrase(row["lastName"].ToString(), font));
                table.AddCell(new Phrase(row["age"].ToString(), font));
                table.AddCell(new Phrase(row["contactNumber"].ToString(), font));
                table.AddCell(new Phrase(row["address"].ToString(), font));
                table.AddCell(new Phrase(row["loanDateStart"].ToString(), font));
                table.AddCell(new Phrase(row["carBrand"].ToString(), font));
                table.AddCell(new Phrase(row["carModel"].ToString(), font));
                table.AddCell(new Phrase(row["yearModel"].ToString(), font));
                table.AddCell(new Phrase(row["plateNumber"].ToString(), font));
                table.AddCell(new Phrase(row["totalPrice"].ToString(), font));
                table.AddCell(new Phrase(row["monthsToPay"].ToString(), font));
                table.AddCell(new Phrase(row["downPayment"].ToString(), font));
                table.AddCell(new Phrase(row["remainingBalance"].ToString(), font));
            }

            // Add the table to the document
            doc.Add(table);

            // Close the document
            doc.Close();

            MessageBox.Show("PDF generated successfully!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selectedId;
            if (int.TryParse(textBox11.Text, out selectedId))
            {
                DataTable data = GetDataFromDatabase(selectedId);
                if (data.Rows.Count > 0)
                {
                    GeneratePDF(data);
                }
                else
                {
                    MessageBox.Show("No data found for the specified ID.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.");
            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
