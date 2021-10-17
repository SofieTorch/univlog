using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Univlog.Models
{
    public class User
    {
        public short UserId { get; private set; }
        public string Name { get; set; }
        public string PaternalSurname { get; set; }
        public string MaternalSurname { get; set; }
        public string Email { get; set; }
        public byte RoleCode { get; set; }

        public string FullName
        {
            get => $"{Name} {PaternalSurname} {MaternalSurname}";
        }

        public User()
        { }

        public User(short userId)
        {
            UserId = userId;
        }
    }
}