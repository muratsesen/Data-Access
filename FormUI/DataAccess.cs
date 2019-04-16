using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public class DataAccess
    {
        public BindingList<Artist> GetByName(string value)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Chinook")))
            {
                //This is not secure
                //var output = connection.Query<Artist>($"select * from Artist where Name like '%{value}%'").ToList();
                
                //This is secure
                var output = connection.Query<Artist>("dbo.Artist_GetByName @pName", new { pName = value}).ToList();

                return new BindingList<Artist>(output);
            }
        }

        internal void InserArtist(BindingList<Artist> artists)
        {
            using (IDbConnection connection =  new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Chinook")))
            {
                connection.Execute("dbo.Artist_Insert @Name",artists);
            }
        }
    }
}
