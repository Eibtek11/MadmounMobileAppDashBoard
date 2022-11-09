﻿using BL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BL
{
    public interface IGetChat
    {
        IEnumerable<GetPayment> GetAll(DateTime DateOne, DateTime DateTwo);

    }
    public class ClsGetPayment : IGetChat
    {
        private string connectionString;
        MadmounDbContext ctx;
        public ClsGetPayment(MadmounDbContext contex)
        {
            ctx = contex;
            connectionString = @"Server=SQL5105.site4now.net;Database=db_a788b5_madmoundatabase;User Id=db_a788b5_madmoundatabase_admin;Password=2812008a1A@;";
            //connectionString = @"Server=SQL5103.site4now.net;Database=db_a788b5_habibaahmedm;User Id=db_a788b5_habibaahmedm_admin;Password=2812008a1";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }



        public IEnumerable<GetPayment> GetAll(DateTime DateOne, DateTime DateTwo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

               
                var SQL = string.Format("EXECUTE dbo.SpGetPayment @DateOne=[{0}] , @DateTwo=[{1}]" , DateOne, DateTwo);
                IEnumerable<GetPayment> GetAll = dbConnection.Query<GetPayment>(SQL);
                return GetAll;
            }
        }
    }
}