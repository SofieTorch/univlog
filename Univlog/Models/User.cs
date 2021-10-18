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
        public string Password { get; set; }
        public byte RoleCode { get; set; }

        public string FullName
        {
            get => $"{Name} {PaternalSurname} {MaternalSurname}";
        }

        public string GetRoleString()
        {
            if (RoleCode == 0) return "Estudiante";
            return "Docente";
        }

        public byte GetRoleByte()
        {
            string pattern = Email.Trim().Substring(Email.Trim().IndexOf('@'));
            if (pattern.Contains("est")) return 0;
            return 1;
        }

        public User()
        { }

        public User(short userId, string name, string paternalSurname, string maternalSurname, string email, string password, byte roleCode)
        {
            UserId = userId;
            Name = name;
            PaternalSurname = paternalSurname;
            MaternalSurname = maternalSurname;
            Email = email;
            Password = password;
            RoleCode = roleCode;
        }

        public User(short userId, string name, string paternalSurname, string maternalSurname, string email, byte roleCode)
        {
            UserId = userId;
            Name = name;
            PaternalSurname = paternalSurname;
            MaternalSurname = maternalSurname;
            Email = email;
            RoleCode = roleCode;
        }

        public User(string name, string paternalSurname, string maternalSurname, string email, string password, byte roleCode)
        {
            Name = name;
            PaternalSurname = paternalSurname;
            MaternalSurname = maternalSurname;
            Email = email;
            Password = password;
            RoleCode = roleCode;
        }

        public User(string name, string paternalSurname, string maternalSurname, string email, string password)
        {
            Name = name;
            PaternalSurname = paternalSurname;
            MaternalSurname = maternalSurname;
            Email = email;
            Password = password;
        }
    }
}