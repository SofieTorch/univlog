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
        public User Get(int id)
        {
            Database conn = Database.Open("UnivlogDB");
            string query = "SELECT * FROM [User] WHERE UserId = @0";

            var row = conn.QuerySingle(query, id);
            User res = new User(row.UserId);
            res.Name = row.Name;
            res.PaternalSurname = row.PaternalSurname;
            res.MaternalSurname = row.MaternalSurname;
            res.Email = row.Email;
            res.RoleCode = row.Role;

            return res;
        }
    }
}