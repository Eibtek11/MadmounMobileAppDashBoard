using BL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BL
{
    public interface IGetLogInHistory
    {
        IEnumerable<GetLogInHistory> GetAll(DateTime DateOne, DateTime DateTwo);

    }
    public class ClsGetLogInHistory : IGetLogInHistory
    {
        private string connectionString;
        MadmounDbContext ctx;
        public ClsGetLogInHistory(MadmounDbContext contex)
        {
            ctx = contex;
            //connectionString = @"Server=DESKTOP-262OT74;Database=MadmounDb;Trusted_Connection=True;";
            //connectionString = @"Server=SQL5105.site4now.net;Database=db_a788b5_madmoundatabase;User Id=db_a788b5_madmoundatabase_admin;Password=2812008a1A@;";
            //connectionString = @"Server=SQL5103.site4now.net;Database=db_a788b5_habibaahmedm;User Id=db_a788b5_habibaahmedm_admin;Password=2812008a1";
            connectionString = @"Server=SQL5070.site4now.net;Database=db_a788b5_newmadmon;User Id=db_a788b5_newmadmon_admin;Password=2812008a1A#;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public IEnumerable<GetLogInHistory> GetAll(DateTime DateOne, DateTime DateTwo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();


                var SQL = string.Format("EXECUTE dbo.SpGetLogInHistory @DateOne=[{0}] , @DateTwo=[{1}]", DateOne, DateTwo);
                IEnumerable<GetLogInHistory> GetAll = dbConnection.Query<GetLogInHistory>(SQL);
                return GetAll;
            }
        }
    }
}
