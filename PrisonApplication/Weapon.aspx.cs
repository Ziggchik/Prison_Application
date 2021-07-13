using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrisonApplication
{
    public partial class Weapon : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = PrisonConnection.qrWeapon;
            if (!IsPostBack)
            {
                gvFill(QR);
                lbFill();
                lbNakladnayaFill();
                lbFill1();
            }
        }

        private void gvFill(string qr)
        {
            sdsWeapon.ConnectionString =
            PrisonConnection.connection.ConnectionString.ToString();
            sdsWeapon.SelectCommand = qr;
            sdsWeapon.DataSourceMode = SqlDataSourceMode.DataReader;
            gvWeapon.DataSource = sdsWeapon;
            gvWeapon.DataBind();
        }

        private void lbNakladnayaFill()
        {
            sdsNakladnaya.ConnectionString = PrisonConnection.connection.ConnectionString.ToString();
            sdsNakladnaya.SelectCommand = PrisonConnection.qrNakladnaya;
            sdsNakladnaya.DataSourceMode = SqlDataSourceMode.DataReader;
            lbNakladnaya.DataSource = sdsNakladnaya;
            lbNakladnaya.DataTextField = "Nomer_Nakladnaya";
            lbNakladnaya.DataValueField = "ID_Nakladnaya";
            lbNakladnaya.DataBind();
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

        private void lbFill1()
        {
            sdsWeapon.ConnectionString = PrisonConnection.connection.ConnectionString.ToString();
            sdsWeapon.SelectCommand = PrisonConnection.qrGuardian;
            sdsWeapon.DataSourceMode = SqlDataSourceMode.DataReader;
            lbGuardians.DataSource =sdsWeapon;
            lbGuardians.DataTextField = "Информация об охраннике";
            lbGuardians.DataValueField = "ID_Guardian";
            lbGuardians.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choise.aspx");
        }

        protected void gvWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvWeapon.SelectedRow;
            tbWeaponName.Text = row.Cells[2].Text.ToString();
            PrisonConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString()); 
            lbType_Of_Weapon.SelectedValue = row.Cells[4].Text.ToString();
            lbNakladnaya.SelectedValue = row.Cells[8].Text.ToString();
            lbGuardians.SelectedValue = row.Cells[11].Text.ToString();
        }

        protected void gvWeapon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbWeaponName.Text == "")
            {
                case (true):
                    tbWeaponName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "insert into [dbo].[Weapon] ([Name_Weapon],[Type_of_Weapon_ID],[Nakladnaya_ID],[Guardians_ID]) values ('" + tbWeaponName.Text + "'," + lbType_Of_Weapon.SelectedValue + "," + lbNakladnaya.SelectedValue+"," +lbGuardians.SelectedValue+")";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbWeaponName.Text == "")
            {
                case (true):
                    tbWeaponName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "update [dbo].[Weapon] set " +
                                    "[Name_Weapon] ='" + tbWeaponName.Text + "'," +
                                    "[Guardians_ID]=" + lbGuardians.SelectedValue + "," +
                                    "[Type_of_Weapon_ID]=" + lbGuardians.SelectedValue + "," +
                                    "[Nakladnaya_ID]= " + lbNakladnaya.SelectedValue + "" +
                                    "where ID_Weapon = " + PrisonConnection.IDrecord + "";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
                "Удалить выбранную запись?",
                "Списано со  склада", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "delete [dbo].[Weapon] " +
                        "where ID_Weapon = " + PrisonConnection.IDrecord + "";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvWeapon.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text))
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Name_Weapon] like '%" + tbSearch.Text + "%'"+
                "[Nomer_Nakladnaya] like '%" + tbSearch.Text + "%'or " +
                "[Name_of_Type_of_Weapon] like '%" + tbSearch.Text + "%'or " +
                "[Surname_Guardian]+' '+[Name_Guardian]+' '+[MiddleName_Guardian] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void gvWeapon_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Название оружия"):
                    e.SortExpression = "[Name_Weapon]";
                break;
                case ("Тип оружия"):
                    e.SortExpression = "[Name_of_Type_of_Weapon]";
                break;
                case ("Накладная"):
                    e.SortExpression = "[Nomer_Nakladnaya]";
                break;
                case ("Информация об охраннике"):
                    e.SortExpression = "[Surname_Guardian] + ' ' +[Name_Guardian] + ' ' +[MiddleName_Guardian]";
                 break;
            }
            sortGridView(gvWeapon, e, out sortDirection, out strField);
                    string strDirection = sortDirection
                        == SortDirection.Ascending ? "ASC" : "DESC";
                    gvFill(QR + " order by " + e.SortExpression + " " + strDirection);
            }
        private void sortGridView(GridView gridView,
            GridViewSortEventArgs e,
            out SortDirection sortDirection,
            out string strSortField)
        {
            strSortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null &&
                gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (strSortField ==
                    gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"]
                        == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }
            }
            gridView.Attributes["CurrentSortField"] = strSortField;
            gridView.Attributes["CurrentSortDirection"] =
                (sortDirection == SortDirection.Ascending ? "ASC"
                : "DESC");
        }
    }
}