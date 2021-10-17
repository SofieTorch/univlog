using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Univlog.Models
{
    public class Post
    {
        public short PostId { private set; get; }
        public string Title { private set; get; }
        public byte Topic{ private set; get; }

        public Post()
        { }

        public Post(short postId, string title, byte topic)
        {
            PostId = postId;
            Title = title;
            Topic = topic;
        }
    }
}