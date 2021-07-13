using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrisonApplication
{
    public partial class Nakladnaya : System.Web.UI.Page
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
            sdsTypeNakladnaya.ConnectionString = PrisonConnection.connection.ConnectionString.ToString();
            sdsTypeNakladnaya.SelectCommand = PrisonConnection.qrNakladnaya;
            sdsTypeNakladnaya.DataSourceMode = SqlDataSourceMode.DataReader;
            lbNakladnaya.DataSource = sdsTypeNakladnaya;
            lbNakladnaya.DataTextField = "Nomer_Nakladnaya";
            lbNakladnaya.DataValueField = "ID_Nakladnaya";
            lbNakladnaya.DataBind();
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", PrisonConnection.connection);
            command.CommandText = "insert into [dbo].[Nakladnaya] ([Nomer_Nakladnaya]) values ('" + tbNameNakladnaya.Text + "')";
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
            lbFill();
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", PrisonConnection.connection);
            command.CommandText = "update [dbo].[Nakladnaya] set " +
            "[Nomer_Nakladnaya] ='" + tbNameNakladnaya.Text + "'" +
            "where ID_Nakladnaya= " + PrisonConnection.IDrecord + "";
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
            lbFill();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
                "Удалить выбранную запись?",
                "Накладная недействительна", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "delete [dbo].[Nakladnaya] " +
                        "where ID_Nakladnaya = " + PrisonConnection.IDrecord + "";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    lbFill();
                    break;
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choise.aspx");
        }

        protected void btSelect_Click(object sender, EventArgs e)
        {
            tbNameNakladnaya.Text = lbNakladnaya.SelectedItem.Text;
        }
    }
}