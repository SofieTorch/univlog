using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Univlog.Models;
using WebMatrix.Data;

namespace Univlog.Data_Access
{
    public class PostAccess
    {
        public IEnumerable<Post> GetSubjectsPosts()
        {
            List<Post> res = new List<Post>();
            Database conn = Database.Open("UnivlogDB");
            string query = "SELECT * FROM Post WHERE Topic = 1";

            foreach (var row in conn.Query(query))
                res.Add(new Post(row.PostId, row.Title, row.Topic));

            return res;
        }

        public IEnumerable<Post> GetTeachersPosts()
        {
            List<Post> res = new List<Post>();
            Database conn = Database.Open("UnivlogDB");
            string query = "SELECT * FROM Post WHERE Topic = 0";

            foreach (var row in conn.Query(query))
                res.Add(new Post(row.PostId, row.Title, row.Topic));

            return res;
        }
    }
}