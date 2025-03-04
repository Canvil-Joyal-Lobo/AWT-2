//Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace partbprg3
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
namespace partbprg3
{
public partial class Form2 : Form
{
public Form2()
{
InitializeComponent();
}
{
private void button1_Click(object sender, EventArgs e)
new Form1().Show();
this.Hide();
}
{
private void Form2_Load(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_VSS2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("select VehicleType from tbl_VehicleTypes", con);
DataTable dt = new DataTable();
da.Fill(dt);
comboBox1.DataSource = dt;
comboBox1.DisplayMember = "VehicleType";
comboBox1.ValueMember = "VehicleType";
con.Close();
}
{
private void button2_Click(object sender, EventArgs e)
SqlConnection con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_VSS2;Integrated Security=True;Pooling=False");
con.Open();
SqlDataAdapter da = new SqlDataAdapter("select IdVehicleType from tbl_VehicleTypes where
VehicleType = '"+comboBox1.SelectedValue.ToString()+"'", con);
DataTable dt = new DataTable();
da.Fill(dt);
SqlCommand cmd = new SqlCommand("insert into tbl_ServiceDetails values(" + textBox1.Text
+ ",'" + textBox2.Text + "','" + textBox3.Text + "', "+int.Parse((dt.Rows[0][0]).ToString())+")",
con);
cmd.ExecuteNonQuery();
MessageBox.Show("Records Entered Successfully");
textBox1.Text = "";
textBox2.Text = "";
textBox3.Text = "";
textBox1.Focus();
con.Close();
}
}
}




//////////////////////

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
namespace partbprg3
{
public partial class Form3 : Form
{
SqlConnection con;
SqlDataAdapter da;
DataTable dt;
public Form3()
{
InitializeComponent();
}
{
private void Form3_Load(object sender, EventArgs e)
con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_VSS2;Integrated Security=True;Pooling=False");
con.Open();
da = new SqlDataAdapter("select * from tbl_VehicleTypes", con);
dt = new DataTable();
da.Fill(dt);
dataGridView1.DataSource = dt;
}
{
private void button1_Click(object sender, EventArgs e)
SqlCommandBuilder cmd = new SqlCommandBuilder(da);
da.Update(dt);
MessageBox.Show("Service Charges Updated Successfully");
}
{
private void button2_Click(object sender, EventArgs e)
new Form1().Show();
this.Hide();
}
}
}



/////////////////


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
namespace partbprg3
{
public partial class Form4 : Form
{
SqlConnection con;
SqlDataAdapter da;
DataTable dt;
public Form4()
{
InitializeComponent();
}
private void Form4_Load(object sender, EventArgs e)
{
con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_VSS2;Integrated Security=True;Pooling=False");
con.Open();
da = new SqlDataAdapter("select VehicleType from tbl_VehicleTypes", con);
dt = new DataTable();
da.Fill(dt);
comboBox1.DataSource = dt;
comboBox1.DisplayMember = "VehicleType";
comboBox1.ValueMember = "VehicleType";
con.Close();
}
{
private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
con = new SqlConnection("Data Source=mca01-17\\sqlexpress;Initial
Catalog=db_VSS2;Integrated Security=True;Pooling=False");
con.Open();
da = new SqlDataAdapter("select IdVehicleType, ServiceCharge from tbl_VehicleTypes where
VehicleType = '"+comboBox1.SelectedValue.ToString()+"'", con);
dt = new DataTable();
da.Fill(dt);
int id=0, amt=0;
foreach (DataRow r in dt.Rows)
{
id = int.Parse(r[0].ToString());
amt = int.Parse(r[1].ToString());
}
da = new SqlDataAdapter("select IdVehicleType, count(*) from tbl_ServiceDetails group by
IdVehicleType", con);
dt = new DataTable();
da.Fill(dt);
int total_service = 0;
foreach(DataRow r in dt.Rows)
{
if(int.Parse(r[0].ToString()) ==id)
total_service = int.Parse(r[1].ToString())*amt;
}
textBox1.Text = total_service.ToString();
con.Close();
}
{
private void button2_Click(object sender, EventArgs e)
new Form1().Show();
this.Hide();
}
}
}