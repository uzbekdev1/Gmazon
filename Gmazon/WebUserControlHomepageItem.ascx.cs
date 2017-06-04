using System;
using System.Web.UI.WebControls;

namespace Gmazon
{
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
            set { LabelBought.Text = "已售出" + value + "本"; }
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
}