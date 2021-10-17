using Univlog.Data_Access;

namespace Univlog.Models
{
    public class Comment
    {
        public int CommentId { get; private set; }
        public string Content { get; set; }
        public string CreatedAt { get; private set; }
        public short PostId { get; private set; }
        public short UserId { get; private set; }
        public User User
        {
            get => _getUser();
        }

        public Comment(int commentId, string content, short postId, short userId, string createdAt)
        {
            CommentId = commentId;
            Content = content;
            CreatedAt = createdAt;
            PostId = postId;
            UserId = userId;
        }

        public Comment(string content, short postId, short userId)
        {
            Content = content;
            PostId = postId;
            UserId = userId;
        }

        private User _getUser()
        {
            UserAccess userAccess = new UserAccess();
            return userAccess.Get(UserId);
        }

    }
}