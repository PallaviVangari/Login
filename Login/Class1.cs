using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Login
{
    class Class1
    {
        SqlConnection conn;
        DataTable dt;
        public Class1()
        {
            dt = new DataTable();
            DataColumn itemnum = new DataColumn("itemnum", typeof(int));
            DataColumn itemname = new DataColumn("itemname", typeof(string));
            DataColumn cost = new DataColumn("cost", typeof(int));

            dt.Columns.Add(itemnum);
            dt.Columns.Add(itemname);
            dt.Columns.Add(cost);

            conn = new SqlConnection(@"Data Source=DESKTOP-HR2SEVF\SQLEXPRESS;Initial Catalog=my;User ID=sa;Password=pallavi");

        }

        public DataTable process(int k)
        {
            string query = "select * from item where itemnum='" + k + "';";
            SqlCommand cmd = new SqlCommand(query, conn);


            try
            {
                if (ConnectionState.Closed == conn.State)
                    conn.Open();

            }
            catch
            { }
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        int num = rd.GetInt32(0);
                        int cost1 = rd.GetInt32(2);
                        string name = rd.GetString(1);
                       // MessageBox.Show(name);
                        //MessageBox.Show(cost1.ToString());
                        DataRow row = dt.NewRow();
                        row[0] = num;
                        row[1] = name;
                        row[2] = cost1;
                        dt.Rows.Add(row);
                        // dt.Load(rd);

                    }
                    rd.Close();
                }
                else
                    MessageBox.Show("Enter a valid item number");
                //return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Error in reading");
            }
            return dt;
        }
        public DataTable deleteItem(DataTable temp, int k)
        {
            int Flag = 0;
            foreach (DataRow row in temp.Rows)
            {
                if (int.Parse(row["itemnum"].ToString()) == k)
                {
                    row.Delete();
                    Flag = 1;
                    break;
                }
            }
            if (Flag == 0)
                MessageBox.Show("Item doesn't exist in bill to delete");
            return temp;
        }
    }
}
