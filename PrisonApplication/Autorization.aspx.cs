using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrisonApplication
{
    public partial class Autorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btEnter_Click(object sender, EventArgs e)
        {
            //PrisonConnection connection = new PrisonConnection();
            //connection.dbEnter(tbSecrtnoeSlovo.Text);
            switch (tbSecrtnoeSlovo.Text == "Porasha")
            {
                case (false):
                    tbSecrtnoeSlovo.BackColor = System.Drawing.Color.Red;
                    lblTitle.Text = "Введено не верное слово!";
                    tbSecrtnoeSlovo.Text = "";
                    break;
                default:
                    Response.Redirect("Choise.aspx");
                    break;
            }
        }
    }
}