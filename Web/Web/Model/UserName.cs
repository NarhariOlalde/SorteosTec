using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Model
{
    public class UserName
    {
        [Key]
        [ForeignKey("Usuario")]
        public int id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }

        public Usuario Usuario { get; set; }
    }
}

