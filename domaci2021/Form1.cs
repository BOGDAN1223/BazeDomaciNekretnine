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

namespace baze2022
{
    public partial class Form1 : Form
    {

       

        int rows = 0;
        string cs = "Data source=PREDATOR\\BOGDAN; Initial catalog=baze2022; Integrated security=true";
        DataTable Objekat = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Objekat ", veza);
            adapter.Fill(Objekat);

            refresh(rows);

            if (rows == 0)
            {
                button2.Enabled = false;
            }
            if (rows == Objekat.Rows.Count - 1)
            {
                button3.Enabled = false;
            }
        }

        private void refresh(int x)
        {
            textBox1.Text = Objekat.Rows[x]["ID"].ToString();
            textBox2.Text = Objekat.Rows[x]["Tip"].ToString();
            textBox3.Text = Objekat.Rows[x]["Povrsina"].ToString();
            textBox4.Text = Objekat.Rows[x]["Cena"].ToString();
            textBox5.Text = Objekat.Rows[x]["Adresa"].ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rows < Objekat.Rows.Count - 1)
            {
                rows++;
                refresh(rows);
                button2.Enabled = true;
            }
            if (rows == Objekat.Rows.Count - 1)
            {
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rows > 0)
            {
                rows--;
                refresh(rows);
                button3.Enabled = true;
            }
            if (rows == 0)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rows = 0;
            refresh(rows);
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rows = Objekat.Rows.Count - 1;
            refresh(rows);
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("DELETE FROM Objekat WHERE ID=" + textBox1.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Objekat", veza);
            Objekat.Clear();
            adapter.Fill(Objekat);
            if (rows == Objekat.Rows.Count) rows = rows - 1;
            if (rows == 0)
            {
                button2.Enabled = false;
            }
            if (Objekat.Rows.Count > 1)
            {
                button3.Enabled = true;
            }
            if (rows == Objekat.Rows.Count - 1)
            {
                button3.Enabled = false;
            }

            refresh(rows);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Update Objekat Set Tip= '" + textBox2.Text + "', Povrsina= '" + textBox3.Text + "' , Cena= '" + textBox4.Text + "' , Adresa= '" + textBox5.Text + "'  where ID= " + textBox1.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Objekat", veza);
            Objekat.Clear();
            adapter.Fill(Objekat);
            refresh(rows);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("insert into Objekat (ID , Tip, Povrsina, Cena, Adresa) values (" + textBox1.Text + ", '" + textBox2.Text + "' ,'" + textBox3.Text + "', '" + textBox4.Text + "' , '" + textBox5.Text + "' ) ", veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Objekat", veza);
            Objekat.Clear();
            adapter.Fill(Objekat);
            refresh(rows);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }
    }
}
