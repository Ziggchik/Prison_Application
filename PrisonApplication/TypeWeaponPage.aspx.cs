using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrisonApplication
{
    public partial class TypeWeaponPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!IsPostBack)
            {
            lbFill();
            }
        }

        private void lbFill()
        {
            sdsTypeWeapon.ConnectionString = PrisonConnection.connection.ConnectionString.ToString();
            sdsTypeWeapon.SelectCommand = PrisonConnection.qrType_Of_Weapon;
            sdsTypeWeapon.DataSourceMode = SqlDataSourceMode.DataReader;
            lbType_Of_Weapon.DataSource = sdsTypeWeapon;
            lbType_Of_Weapon.DataTextField = "Name_of_Type_of_Weapon";
            lbType_Of_Weapon.DataValueField = "ID_Type_of_Weapon";
            lbType_Of_Weapon.DataBind();
        }
        protected void btSelect_Click(object sender, EventArgs e)
        {
            tbName_of_Type.Text = lbType_Of_Weapon.SelectedItem.Text;
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choise.aspx");
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", PrisonConnection.connection);
            command.CommandText = "insert into [dbo].[Type_of_Weapon] ([Name_of_Type_of_Weapon]) values ('" + tbName_of_Type.Text + "')";
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
            lbFill();
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("", PrisonConnection.connection);
            command.CommandText = "update [dbo].[Type_of_Weapon] set " +
            "[Name_of_Type_of_Weapon] ='" + tbName_of_Type.Text + "'," +
            "where ID_Type_of_Weapon = " + PrisonConnection.IDrecord + "";
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
            lbFill();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
                "Удалить выбранную запись?",
                "Тип устарел", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "delete [dbo].[Type_of_Weapon] " +
                        "where ID_Type_of_Weapon = " + PrisonConnection.IDrecord + "";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    lbFill();
                    break;
            }
        }
    }
}