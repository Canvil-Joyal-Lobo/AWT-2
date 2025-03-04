//Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace partbprg2
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
}
}
}


/////////////////////////

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
namespace partbprg2
{
public partial class Form2 : Form
{
public Form2()
{
InitializeComponent();
}
private void button1_Click(object sender, EventArgs e)
{
SqlConnection conn = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_LSA2;Integrated Security=True");
conn.Open();
SqlCommand cmd = new SqlCommand("insert into tbl_Subjects values(" + textBox1.Text +
",'" + textBox2.Text + "','" + textBox3.Text +"')", conn);
cmd.ExecuteNonQuery();
MessageBox.Show("Subject Details Entered Successfully");
textBox1.Text = "";
textBox2.Text = "";
textBox3.Text = "";
textBox1.Focus();
conn.Close();
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
namespace partbprg2
{
public partial class Form3 : Form
{
public Form3()
{
InitializeComponent();
}
{
private void button2_Click(object sender, EventArgs e)
new Form1().Show();
this.Hide();
}
{
private void button1_Click(object sender, EventArgs e)
SqlConnection conn = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_LSA2;Integrated Security=True");
conn.Open();
SqlCommand cmd = new SqlCommand("insert into tbl_Lecturers values(" + textBox1.Text +
",'" + textBox2.Text + "','" + textBox3.Text + "')", conn);
cmd.ExecuteNonQuery();
MessageBox.Show("Lecturer Details Entered Successfully");
textBox1.Text = "";
textBox2.Text = "";
textBox3.Text = "";
textBox1.Focus();
conn.Close();
}
}
}

/////////////////////////


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
namespace partbprg2
{
public partial class Form4 : Form
{
public Form4()
{
InitializeComponent();
}
{
private void Form4_Load(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_LSA2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("select LecturerName from tbl_Lecturers", con);
DataTable dt = new DataTable();
da.Fill(dt);
comboBox1.DataSource = dt;
comboBox1.DisplayMember = "LecturerName";
comboBox1.ValueMember = "LecturerName";
da = new SqlDataAdapter("select * from tbl_Subjects", con);
dt = new DataTable();
da.Fill(dt);
dataGridView1.DataSource = dt;
DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn();
c.Name = "Check";
c.Width = 50;
dataGridView1.Columns.Insert(0, c);
con.Close();
}
{
private void button1_Click(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_LSA2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("select IdLecturer from tbl_Lecturers where
LecturerName='" + comboBox1.SelectedValue.ToString() + "'", con);
DataTable dt = new DataTable();
da.Fill(dt);
foreach (DataGridViewRow r in dataGridView1.Rows)
{
if (Convert.ToBoolean(r.Cells["Check"].Value))
{
SqlCommand cmd = new SqlCommand("insert into tbl_LecturerSubjects
values(@sid,@scode,@lid)", con);
cmd.Parameters.AddWithValue("@sid", r.Cells["IdSubject"].Value);
cmd.Parameters.AddWithValue("@scode", r.Cells["SubjectCode"].Value);
cmd.Parameters.AddWithValue("@lid", int.Parse(dt.Rows[0][0].ToString()));
cmd.ExecuteNonQuery();
}
}
MessageBox.Show("Subject Allocated sucessfully");
con.Close();
}
{
private void button2_Click(object sender, EventArgs e)
new Form1().Show();
this.Hide();
}
}
}

///////////////////////

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
namespace partbprg2
{
public partial class Form5 : Form
{
public Form5()
{
InitializeComponent();
}
private void button2_Click(object sender, EventArgs e)
{
}
{
private void Form5_Load(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_LSA2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("select LecturerName from tbl_Lecturers", con);
DataTable dt = new DataTable();
da.Fill(dt);
comboBox1.DataSource = dt;
comboBox1.DisplayMember = "LecturerName";
comboBox1.ValueMember = "LecturerName";
con.Close();
}
{
private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_LSA2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("select a.IdSubject, a.SubjectCode, a.SubjectName
from tbl_Subjects a, tbl_Lecturers b, tbl_LecturerSubjects c where a.IdSubject = c.IdSubject AND
b.IdLecturer = c.IdLecturer AND b.LecturerName = '"+comboBox1.SelectedValue.ToString()+"'", con);
DataTable dt = new DataTable();
da.Fill(dt);
dataGridView1.DataSource = dt;
con.Close();
}
{
private void button1_Click(object sender, EventArgs e)
new Form1().Show();
this.Hide();
}
}
}