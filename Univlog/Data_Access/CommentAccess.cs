using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Univlog.Models;
using WebMatrix.Data;

namespace Univlog.Data_Access
{
    public class CommentAccess
    {
        public IEnumerable<Comment> GetFrom(short postId)
        {
            List<Comment> res = new List<Comment>();
            Database conn = Database.Open("UnivlogDB");
            string query = "SELECT * FROM Comment WHERE PostId = @0";

            foreach (var row in conn.Query(query, postId))
                res.Add(new Comment(row.CommentId, row.Content, row.PostId, row.UserId, Convert.ToString(row.CreatedAt)));

            return res;
        }

        public bool Add(Comment comment)
        {
            Database conn = Database.Open("UnivlogDB");
            string query = "INSERT INTO Comment(UserId, PostId, Content) VALUES (@0, @1, @2)";

            int rowsAffected = conn.Execute(query, comment.UserId, comment.PostId, comment.Content);
            bool success = rowsAffected == 1;

            return success;
        }

        public bool Update(Comment comment)
        {
            Database conn = Database.Open("UnivlogDB");
            string query = "UPDATE Comment SET Content = @0 WHERE CommentId = @1";

            int rowsAffected = conn.Execute(query, comment.Content, comment.CommentId);
            bool success = rowsAffected == 1;
            return success;
        }
    }
}