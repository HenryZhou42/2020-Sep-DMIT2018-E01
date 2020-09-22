
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion

namespace WebApp.SamplePages
{
    public partial class SearchByDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if(!Page.IsPostBack)
            {
                BindArtistList();
            }
        }

        protected void BindArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<SelectionList> info = sysmgr.Artists_List();

            //sort your list<T> before displaying
            info.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));

            //set up the DDL
            ArtistList.DataSource = info;
            ArtistList.DataTextField = nameof(SelectionList.DisplayText);
            ArtistList.DataValueField = nameof(SelectionList.ValueId);
            ArtistList.DataBind();

            //set up the prompt
            //ArtistList.Items.Insert(0, "Select an Artist"); could cause some problem // in CPSC1517

            //ListItem prompt = new ListItem();
            //prompt.Text = "Select and artist";
            //prompt.Value = "0";
            //ArtistList.Items.Insert(0, prompt);

            ArtistList.Items.Insert(0, new ListItem("Select and artist","0"));
        }

        protected void SearchAlbum_Click(object sender, EventArgs e)
        {
            if(ArtistList.SelectedIndex==0)
            {
                MessageLabel.Text = "Select and artist for the search";
            }
            else
            {
                AlbumController sysmgr = new AlbumController();
                List<AlbumArtist> info = sysmgr.Album_FindByArtist(int.Parse(ArtistList.SelectedValue));
                AlbumArtistList.DataSource = info;
                AlbumArtistList.DataBind();
            }
        }

        protected void AlbumArtistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //access the value from a Gridview Row
            //create an alias to gridview row
            GridViewRow agvrow = AlbumArtistList.Rows[AlbumArtistList.SelectedIndex];
            //pull data off the gridview row control
            //the data 
            MessageLabel.Text = (agvrow.FindControl("AlbumId") as Label).Text;
        }
    }
}