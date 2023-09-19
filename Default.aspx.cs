using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllVote();
            if (!Page.IsPostBack)//new request page, not triggered on button click - postback
            {
                BindDropDownListParti();
                BindDropDownListKommu();
            }
        }

        private void BindDropDownListParti()//dette blir en select *. det som returneres skal bindes til dropdown 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from Parti", conn);//@ betyr at det er et parameter
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }

            //loope gjennom datatable for å hente ut partinavn. lage et dropdownitem og putte navnet i det
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Parti"].ToString(), row["Pid"].ToString());//hente ut verdier
                DropDownListParti.Items.Add(item);//legge item i lista
            }

            //DropDownListParti.DataSource= dt;
            DropDownListParti.DataBind();
        }

        private void BindDropDownListKommu()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from Kommune", conn);//@ betyr at det er et parameter
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }

            //loope gjennom datatable for å hente ut partinavn. lage et dropdownitem og putte navnet i det
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Kommune"].ToString(), row["Kid"].ToString());//hente ut verdier
                DropDownListKommu.Items.Add(item);//legge item i lista
            }

            //DropDownListParti.DataSource= dt;
            DropDownListKommu.DataBind();
        }

        private void GetAllVote()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from Vote", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void StemButton_Click(object sender, EventArgs e)
        {
            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Vote (Pid, Kid) VALUES (@Pid, @Kid)", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@Pid", SqlDbType.Int);
                param.Value = int.Parse(DropDownListParti.SelectedValue);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Kid", SqlDbType.Int);
                param.Value = int.Parse(DropDownListKommu.SelectedValue);
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                conn.Close();
                GetAllVote();
            }
        }

    }

       
    
}