using BL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BL
{
    
    public interface IGetServiceOffers
    {
        IEnumerable<GetServicesOffers> GetAll(DateTime DateOne, DateTime DateTwo);

    }
    public class ClsGetServicesOffers : IGetServiceOffers
    {
        private string connectionString;
        MadmounDbContext ctx;
        public ClsGetServicesOffers(MadmounDbContext contex)
        {
            ctx = contex;
            connectionString = @"Server=DESKTOP-262OT74;Database=MadmounDb;Trusted_Connection=True;";
            //connectionString = @"Server=SQL5070.site4now.net;Database=db_a788b5_newmadmon;User Id=db_a788b5_newmadmon_admin;Password=2812008a1A#;";
            //connectionString = @"Server=SQL5103.site4now.net;Database=db_a788b5_habibaahmedm;User Id=db_a788b5_habibaahmedm_admin;Password=2812008a1";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }



        public IEnumerable<GetServicesOffers> GetAll(DateTime DateOne, DateTime DateTwo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();


                var SQL = string.Format("EXECUTE dbo.SpGetServicesOffers @DateOne=[{0}] , @DateTwo=[{1}]", DateOne, DateTwo);
                IEnumerable<GetServicesOffers> GetAll = dbConnection.Query<GetServicesOffers>(SQL);
                return GetAll;
            }
        }
    }
}
