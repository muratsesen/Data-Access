using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Dashboard : Form
    {
        public BindingList<Artist> artists { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            listBoxArtist.DataSource = artists;
            listBoxArtist.DisplayMember = "Name";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            artists = dataAccess.GetByName(textBoxSearch.Text);
            UpdateBinding();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            db.InserArtist(artists);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxNameto.Text = "";
            textBoxSearch.Text = "";
            artists = null;
            UpdateBinding();

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (artists == null)
            {
                artists = new BindingList<Artist>();
            }
            artists.Add(new Artist { Name = textBoxNameto.Text });
            UpdateBinding();
        }
        
    }
}
