//Form 1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace prg1partb
{
public partial class Form1 : Form
{
public Form1()
{
InitializeComponent();
}
{
private void button1_Click(object sender, EventArgs e)
new Form2().Show();
this.Hide();
}
{
private void button2_Click(object sender, EventArgs e)
new Form3().Show();
this.Hide();
}
{
private void button3_Click(object sender, EventArgs e)
new Form4().Show();
this.Hide();
}
{
private void button4_Click(object sender, EventArgs e)
new Form5().Show();
this.Hide();
private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
}
{
}
{
private void button5_Click(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_EMS2;Integrated Security=True;Pooling=False");
con.Open();
string query = "SELECT * FROM tbl_EmployeeDetails";
SqlDataAdapter da = new SqlDataAdapter(query, con);
DataTable dt = new DataTable();
da.Fill(dt);
dataGridView1.DataSource = dt;
con.Close();
}
}
}

/////////////////////////////
//Form2.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace prg1partb
{
public partial class Form2 : Form
{
public Form2()
{
InitializeComponent();
}
{
private void button1_Click(object sender, EventArgs e)
SqlConnection conn = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_EMS2;Integrated Security=True;Pooling=False");
conn.Open();
SqlCommand cmd = new SqlCommand("insert into tbl_EmployeeDetails
values("+textBox1.Text+",'"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Tex
t+"')",conn);
cmd.ExecuteNonQuery();
MessageBox.Show("Employee Details Entered Successfully");
textBox1.Text = "";
textBox2.Text = "";
textBox3.Text = "";
textBox4.Text = "";
textBox5.Text = "";
textBox1.Focus();
conn.Close();
private void textBox1_TextChanged(object sender, EventArgs e)
}
{
}
{
private void button2_Click(object sender, EventArgs e)
new Form1().Show();
this.Hide();
}
}
}
/////////////////////////////

//Form3.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace prg1partb
{
public partial class Form3 : Form
{
public Form3()
{
InitializeComponent();
}
{
private void button1_Click(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_EMS2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_EmployeeDetails WHERE
IdReportingTo = (SELECT IdEmployee FROM tbl_EmployeeDetails WHERE EmployeeName = '" +
comboBox1.SelectedValue.ToString() + "')", con);
DataTable dt = new DataTable();
da.Fill(dt);
dataGridView1.DataSource = dt;
con.Close();
}
{
private void Form3_Load(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_EMS2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeName FROM tbl_EmployeeDetails
WHERE IdDesignation = 1", con);
DataTable dt = new DataTable();
da.Fill(dt);
comboBox1.DataSource = dt;
comboBox1.DisplayMember = "EmployeeName";
comboBox1.ValueMember = "EmployeeName";
con.Close();
}
private void button2_Click(object sender, EventArgs e)
{
new Form1().Show();
this.Hide();
}
}
}

/////////////////////////////


//Form4.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace prg1partb
{
public partial class Form4 : Form
{
public Form4()
{
InitializeComponent();
}
private void Form4_Load(object sender, EventArgs e)
{
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_EMS2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeName FROM tbl_EmployeeDetails
WHERE IdDesignation = 2", con);
DataTable dt = new DataTable();
da.Fill(dt);
comboBox1.DataSource = dt;
comboBox1.DisplayMember = "EmployeeName";
comboBox1.ValueMember = "EmployeeName";
con.Close();
}
{
private void button1_Click(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_EMS2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_EmployeeDetails WHERE
IdReportingTo = (SELECT IdEmployee FROM tbl_EmployeeDetails WHERE EmployeeName = '" +
comboBox1.SelectedValue.ToString() + "')", con);
DataTable dt = new DataTable();
da.Fill(dt);
dataGridView1.DataSource = dt;
con.Close();
}
private void button2_Click(object sender, EventArgs e)
{
new Form1().Show();
this.Hide();
}
}
}



/////////////////////////////



//Form5.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace prg1partb
{
public partial class Form5 : Form
{
public Form5()
{
InitializeComponent();
}
private void button1_Click(object sender, EventArgs e)
{
new Form1().Show();
this.Hide();
}
{
private void Form5_Load(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial Catalog=db_EMS2;Integrated Security=True;Pooling=False");
con.Open();
string query = "SELECT a.IdEmployee, a.EmployeeName, a.ContactNumber, a.IdDesignation,
a.IdReportingTo, b.EmployeeName AS ManagerName FROM tbl_EmployeeDetails a, tbl_EmployeeDetails b
WHERE a.IdReportingTo = b.IdEmployee;";
SqlDataAdapter da = new SqlDataAdapter(query, con);
DataTable dt = new DataTable();
da.Fill(dt);
dataGridView1.DataSource = dt;
con.Close();
private void label1_Click(object sender, EventArgs e)
}
{
}
}
}