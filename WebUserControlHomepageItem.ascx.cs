using System;
using System.Web.UI.WebControls;

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
