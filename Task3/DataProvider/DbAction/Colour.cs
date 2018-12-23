using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataBase;
using DataProvider.DbObjects;

namespace DataProvider.DbAction
{
    public class Colour
    {
        public static bool Exist(DbLink dbLink, string title)
        {
            if (string.IsNullOrEmpty(title))
                return false;

            string query = @"select * from colors t
                where t.title = @title";

            var result = dbLink.GetConnection().QueryFirstOrDefault(query,
                new { title = title });

            return result != null;               
        }

        public static bool Insert(DbLink dbLink, string title)
        {
            try
            {
                string query = @"insert into colors (title) values(@title)";
                dbLink.GetConnection().Execute(query, new { title = title });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
