using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class WebUserControlHomepageItem : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Title
    {
        set { HyperLinkTitle.Text = value; }
    }

    public string Price
    {
        set { LabelPrice.Text = value; }
    }
    public string Bought
    {
        set { LabelBought.Text = value + "人已购买"; }
    }
    public string HyberLink
    {
        set 
        {
            HyperLinkTitle.NavigateUrl = @"~\Book.aspx?bookID=" + value;
            Image.NavigateUrl = @"~\Book.aspx?bookID=" + value;
        }
    }
    public string ImageUrl
    {
        set { Image.ImageUrl = @"~\images\books\" + value; }
    }

}
