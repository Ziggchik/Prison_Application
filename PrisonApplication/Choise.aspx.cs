using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrisonApplication
{
    public partial class Choise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btPrisoners_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prison.aspx");
        }

        protected void btGuardians_Click(object sender, EventArgs e)
        {
            Response.Redirect("Guardians.aspx");
        }

        protected void btWeapons_Click(object sender, EventArgs e)
        {
            Response.Redirect("Weapon.aspx");
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autorization.aspx");
        }

        protected void btTypeWeapon_Click(object sender, EventArgs e)
        {
            Response.Redirect("TypeWeaponPage.aspx");
        }

        protected void btBlock_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrisonBlock.aspx");
        }

        protected void btNakladnaya_Click(object sender, EventArgs e)
        {
            Response.Redirect("Nakladnaya.aspx");
        }
    }
}