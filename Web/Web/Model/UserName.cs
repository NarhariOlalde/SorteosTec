using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Model
{
    public class UserName
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }

        public UserName()
        {
        }
    }
}

