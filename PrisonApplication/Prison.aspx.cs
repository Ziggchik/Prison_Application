using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrisonApplication
{
    public partial class Prison : System.Web.UI.Page
    {
        private string QR = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            QR = PrisonConnection.qrPrisoner;
            if (!IsPostBack)
            {
                gvFill(QR);
                lbFill();
                lbFill1();
            }
                
        }

        private void gvFill(string qr)
        {
            sdsPrisoners.ConnectionString =
            PrisonConnection.connection.ConnectionString.ToString();
            sdsPrisoners.SelectCommand =qr;
            sdsPrisoners.DataSourceMode = SqlDataSourceMode.DataReader;
            gvPrisoners.DataSource = sdsPrisoners;
            gvPrisoners.DataBind();
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

        private void lbFill1()
        {
            sdsPrisoners.ConnectionString = PrisonConnection.connection.ConnectionString.ToString();
            sdsPrisoners.SelectCommand = PrisonConnection.qrGuardian;
            sdsPrisoners.DataSourceMode = SqlDataSourceMode.DataReader;
            lbGuardians.DataSource = sdsPrisoners;
            lbGuardians.DataTextField = "Информация об охраннике";
            lbGuardians.DataValueField = "ID_Guardian";
            lbGuardians.DataBind();
        }
        protected void gvPrisoners_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }

        protected void gvPrisoners_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPrisoners.SelectedRow;
            tbFirstName.Text = row.Cells[2].Text.ToString();
            tbName.Text = row.Cells[3].Text.ToString();
            tbMiddleName.Text = row.Cells[4].Text.ToString();
            PrisonConnection.IDrecord = Convert.ToInt32(row.Cells[1].Text.ToString());
            lbBlock.SelectedValue = row.Cells[5].Text.ToString();
            lbGuardians.SelectedValue = row.Cells[9].Text.ToString();

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
                                            command.CommandText = "insert into [dbo].[Prisoners] ([Surname_Prisoner], " +
                                            "[Name_Prisoner],[MiddleName_Prisoner],[Prison_Block_ID],[Guardians_ID]) values ('" + tbFirstName.Text + "','"
                                            + tbName.Text + "','" + tbMiddleName.Text + "',"+lbBlock.SelectedValue +"," + lbGuardians.SelectedValue+")";
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
                                    command.CommandText = "update [dbo].[Prisoners] set " +
                                    "[Surname_Prisoner] ='" + tbFirstName.Text + "'," +
                                    "[Name_Prisoner] ='" + tbName.Text + "'," +
                                    "[MiddleName_Prisoner] ='" + tbMiddleName.Text + "'," +
                                    "[Guardians_ID]=" +lbGuardians.SelectedValue +","+
                                    "[Prison_Block_ID]= "+lbBlock.SelectedValue + ""+ 
                                    "where ID_Prisoner = " + PrisonConnection.IDrecord + "";
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
                 "Отбыл срок", System.Windows.Forms.MessageBoxButtons.YesNo,
                 System.Windows.Forms.MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SqlCommand command = new SqlCommand("", PrisonConnection.connection);
                    command.CommandText = "delete [dbo].[Prisoners] " +
                        "where ID_Prisoner = " + PrisonConnection.IDrecord + "";
                    PrisonConnection.connection.Open();
                    command.ExecuteNonQuery();
                    PrisonConnection.connection.Close();
                    gvFill(QR);
                    break;
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choise.aspx");
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvPrisoners.Rows)
            {
                if (row.Cells[2].Text.Equals(tbSearch.Text)
                    || row.Cells[3].Text.Equals(tbSearch.Text)
                    || row.Cells[4].Text.Equals(tbSearch.Text)
                    || row.Cells[7].Text.Equals(tbSearch.Text)
                    || row.Cells[10].Text.Equals(tbSearch.Text))
                    row.BackColor = System.Drawing.Color.DarkGray;
                else
                    row.BackColor = System.Drawing.Color.White;
            }
        }
        protected void btFilter_Click(object sender, EventArgs e)
        {
            string newQr = QR + " where [Surname_Prisoner] like '%" + tbSearch.Text + "%' or " +
                "[Name_Prisoner] like '%" + tbSearch.Text + "%' or " +
                "[MiddleName_Prisoner] like '%" + tbSearch.Text + "%'or "+
                "[Name_of_block] like '%" + tbSearch.Text + "%'or "+
                "[Surname_Guardian]+' '+[Name_Guardian]+' '+[MiddleName_Guardian] like '%" + tbSearch.Text + "%'";
            gvFill(newQr);
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            btSearch_Click(sender, e);
            gvFill(QR);
        }
        protected void gvPrisoners_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string strField = string.Empty;
            switch (e.SortExpression)
            {
                case ("Фамилия"):
                    e.SortExpression = "[Surname_Prisoner]";
                    break;
                case ("Имя"):
                    e.SortExpression = "[Name_Prisoner]";
                    break;
                case ("Отчество"):
                    e.SortExpression = "[MiddleName_Prisoner]";
                    break;
                case ("Название блока"):
                    e.SortExpression = "[Name_of_block]";
                    break;
                case ("Информация об охраннике"):
                    e.SortExpression = "[Surname_Guardian] + ' ' +[Name_Guardian] + ' ' +[MiddleName_Guardian]";
                    break;
            }
            sortGridView(gvPrisoners, e, out sortDirection, out strField);
            string strDirection = sortDirection
                == SortDirection.Ascending ? "ASC" : "DESC";
            gvFill(QR +" order by "+ e.SortExpression+" "+ strDirection);
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

    
