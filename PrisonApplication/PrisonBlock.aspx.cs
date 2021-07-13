using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrisonApplication
{
    public partial class PrisonBlock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbFill();
            }
        }

        private void lbFill()
        {
            sdsBlock.ConnectionString = PrisonConnection.connection.ConnectionString.ToString();
            sdsBlock.SelectCommand = PrisonConnection.qrBlock;
            sdsBlock.DataSourceMode = SqlDataSourceMode.DataReader;
            lbBlock.DataSource = sdsBlock;
            lbBlock.DataTextField = "Name_of_block";
            lbBlock.DataValueField = "ID_Prison_Block";
            lbBlock.DataBind();
        }

        protected void btSelect_Click(object sender, EventArgs e)
        {
            tbName_of_Type.Text = lbBlock.SelectedItem.Text;
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choise.aspx");
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", PrisonConnection.connection);
            command.CommandText = "insert into [dbo].[Prison_Block] ([Name_of_block]) values ('" + tbName_of_Type.Text + "')";
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
            lbFill();
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", PrisonConnection.connection);
            command.CommandText = "update [dbo].[Prison_Block] set " +
            "[Name_of_block] ='" + tbName_of_Type.Text + "'," +
            "where ID_Prison_Block = " + PrisonConnection.IDrecord + "";
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
            lbFill();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
                "Удалить выбранную запись?",
                "Блок снесён", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "delete [dbo].[Prison_Block] " +
                        "where ID_Prison_Block = " + PrisonConnection.IDrecord + "";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    lbFill();
                    break;
            }
        }
    }
}