using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Univlog.Models;
using WebMatrix.Data;

namespace Univlog.Data_Access
{
    public class UserAccess
    {
        public bool Add(User user)
        {
            Database conn = Database.Open("UnivlogDB");
            string query = @"INSERT INTO [User](Name, PaternalSurname, MaternalSurname, Email, Password, Role) 
                             VALUES (@0, @1, @2, @3, HashBytes('MD5', @4), @5)";

            int rowsAffected = conn.Execute(query, user.Name, user.PaternalSurname, user.MaternalSurname, user.Email, user.Password, user.RoleCode);
            bool success = rowsAffected == 1;

            return success;
        }

        public User Get(short id)
        {
            User res = null;
            try
            {
                Database conn = Database.Open("UnivlogDB");
                string query = "SELECT * FROM [User] WHERE UserId = @0";

                var row = conn.QuerySingle(query, id);
                res = new User(row.UserId, row.Name, row.PaternalSurname, row.MaternalSurname, row.Email, row.Role);
            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }

        public User LogIn(string email, string password)
        {
            User res = null;
            try
            {
                Database conn = Database.Open("UnivlogDB");
                string query = "SELECT * FROM [User] WHERE Email = @0 AND Password = HashBytes('MD5', @1)";

                var row = conn.QuerySingle(query, email, password);
                res = new User(row.UserId, row.Name, row.PaternalSurname, row.MaternalSurname, row.Email, row.Role);
            }
            catch (Exception)
            {

                throw;
            }            

            return res;
        }


    }
}