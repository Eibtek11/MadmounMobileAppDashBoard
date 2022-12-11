using BL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BL
{
    public interface IGetServiceApproved
    {
        IEnumerable<GetServicesApproed> GetAll(DateTime DateOne, DateTime DateTwo);

    }
    public class ClsGetServiceApproved : IGetServiceApproved
    {
        private string connectionString;
        MadmounDbContext ctx;
        public ClsGetServiceApproved(MadmounDbContext contex)
        {
            ctx = contex;
            //connectionString = @"Server=DESKTOP-262OT74;Database=MadmounDb;Trusted_Connection=True;";
            connectionString = @"Server=SQL5070.site4now.net;Database=db_a788b5_newmadmon;User Id=db_a788b5_newmadmon_admin;Password=2812008a1A#;";
            //connectionString = @"Server=SQL5103.site4now.net;Database=db_a788b5_habibaahmedm;User Id=db_a788b5_habibaahmedm_admin;Password=2812008a1";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }



        public IEnumerable<GetServicesApproed> GetAll(DateTime DateOne, DateTime DateTwo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();


                var SQL = string.Format("EXECUTE dbo.SpGetServicesApproved @DateOne=[{0}] , @DateTwo=[{1}]", DateOne, DateTwo);
                IEnumerable<GetServicesApproed> GetAll = dbConnection.Query<GetServicesApproed>(SQL);
                return GetAll;
            }
        }
    }
}
