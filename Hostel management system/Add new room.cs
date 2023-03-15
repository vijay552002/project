using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject
{
    public partial class AddNewRoom : Form
    {
        function fn = new function();
        String query;

        public AddNewRoom()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            labelRoom.Visible = false;
            labelRoomExist.Visible = false;

            query = "select * from rooms";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            query="select * from rooms where roomNo="+txtRomNo1.Text+"";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count==0)
            {
                String status;

                if(checkBox1.Checked)
                {
                    status = "yes";

                }
                else
                {
                    status = "No";
                }
                labelRoomExist.Visible = false;
                query = "insert into rooms (roomNo,roomStatus) values("+txtRomNo1.Text+",'"+status+"')";
                fn.setData(query,"Room Added.");
                AddNewRoom_Load(this, null);
            }
            else
            {
                labelRoomExist.Text = "Room All Ready Exist.";
                labelRoomExist.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "select * from rooms where roomNo = " + txRoomNo2.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count==0)
            {
                labelRoom.Text = "No Room Exist.";
                labelRoom.Visible = true;
                checkBox2.Checked = false;
            }
            else
            {
                labelRoom.Text = "Room Found.";
                labelRoom.Visible = true;
                if (ds.Tables[0].Rows[0][1].ToString()=="Yes")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if(checkBox2.Checked)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            query="update rooms set roomStatus='" + status + "'where roomNo ="+txRoomNo2.Text+"";
            fn.setData(query, "Details Updated.");
            AddNewRoom_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
