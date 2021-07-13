using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrisonApplication
{
    
    public partial class Guardians : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = PrisonConnection.qrGuardian;
            if (!IsPostBack)
                gvFill(QR);
        }

        private void gvFill(string qr)
        {
            sdsGuardians.ConnectionString =
            PrisonConnection.connection.ConnectionString.ToString();
            sdsGuardians.SelectCommand = qr;
            sdsGuardians.DataSourceMode = SqlDataSourceMode.DataReader;
            gvGuardians.DataSource = sdsGuardians;
            gvGuardians.DataBind();
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choise.aspx");
        }

        protected void gvGuardians_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvGuardians.SelectedRow;
            tbFirstName.Text = row.Cells[2].Text.ToString();
            tbName.Text = row.Cells[3].Text.ToString();
            tbMiddleName.Text = row.Cells[4].Text.ToString();
            PrisonConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
        }

        protected void gvGuardians_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void btInsert_Click(object sender, EventArgs e)
        {
            switch (tbFirstName.Text == "")
            {
                case (true):
                    tbFirstName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbFirstName.BackColor = System.Drawing.Color.White;
                    switch (tbName.Text == "")
                    {
                        case (true):
                            tbName.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbName.BackColor = System.Drawing.Color.White;
                            switch (tbMiddleName.Text == "")
                            {
                                case (true):
                                    tbMiddleName.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                                    command.CommandText = "insert into [dbo].[Guardians] ([Surname_Guardian], " +
                                    "[Name_Guardian],[MiddleName_Guardian]) values ('" + tbFirstName.Text + "','"
                                    + tbName.Text + "','" + tbMiddleName.Text + "')";
                                    PrisonConnection.connection.Open();
                                    command.ExecuteNonQuery();
                                    PrisonConnection.connection.Close();
                                    gvFill(QR);
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            switch (tbFirstName.Text == "")
            {
                case (true):
                    tbFirstName.BackColor = System.Drawing.Color.Red;
                    break;
                case (false):
                    tbFirstName.BackColor = System.Drawing.Color.White;
                    switch (tbName.Text == "")
                    {
                        case (true):
                            tbName.BackColor = System.Drawing.Color.Red;
                            break;
                        case (false):
                            tbName.BackColor = System.Drawing.Color.White;
                            switch (tbMiddleName.Text == "")
                            {
                                case (true):
                                    tbMiddleName.BackColor = System.Drawing.Color.Red;
                                    break;
                                case (false):
                                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                                    command.CommandText = "update [dbo].[Guardians] set " +
                                    "[Surname_Guardian] ='" + tbFirstName.Text + "'," +
                                    "[Name_Guardian] ='" + tbName.Text + "'," +
                                    "[MiddleName_Guardian] ='" + tbMiddleName.Text + "'" +
                                    "where ID_Guardian = " + PrisonConnection.IDrecord + "";
                                    PrisonConnection.connection.Open();
                                    command.ExecuteNonQuery();
                                    PrisonConnection.connection.Close();
                                    gvFill(QR);
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            switch (System.Windows.Forms.MessageBox.Show(
               "Удалить выбранную запись?",
               "Ушёл на пенсию", System.Windows.Forms.MessageBoxButtons.YesNo,
               System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "delete from [dbo].[Guardians] " +
                        "where ID_Guardian = " + PrisonConnection.IDrecord + "";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvGuardians.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text))
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Name_Guardian] like '%" + tbSearch.Text + "%' or " +
             "[Surname_Guardian] like '%" + tbSearch.Text + "%' or " +
             "[MiddleName_Guardian] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }

        protected void gvGuardians_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Фамилия"):
                    e.SortExpression = "[Surname_Guardian]";
                    break;
                case ("Имя"):
                    e.SortExpression = "[Name_Guardian]";
                    break;
                case ("Отчество"):
                    e.SortExpression = "[MiddleName_Guardian]";
                    break;
                case ("Информация об охраннике"):
                    e.SortExpression = "[Surname_Guardian] + ' ' +[Name_Guardian] + ' ' +[MiddleName_Guardian]"; 
                    break;
            }
            sortGridView(gvGuardians, e, out sortDirection, out strField);
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
