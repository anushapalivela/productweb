using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DEMO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int clickscount = 0;
        int sessioCnt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                textbox1.Text = "0";
            
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //clickscount = clickscount + 1;
            //textbox1.Text = clickscount.ToString();
            if (ViewState["clicks"] != null)
            {
                
                clickscount = (int)ViewState["clicks"]+ 1;
            }
                textbox1.Text = clickscount.ToString();
                ViewState["clicks"] = int.Parse(textbox1.Text);
                if (Session["sessionclick"] == null)
                    Session["sessionclick"]= 0;
                Session["sessionclick"] = (int)Session["sessionclick"]+1;
                txtSession.Text = Session["sessionclick"].ToString();
               // HttpContext.Current.Response.Cookies.Add(new HttpCookie("test", "anusha"));

        }
    }
}