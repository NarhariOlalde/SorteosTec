using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Web.Model
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; } = 0;
        public string nombre { get; set; } = string.Empty;
        public string apellidos { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public string datos_bancarios { get; set; } = string.Empty;
        public string sexo { get; set; } = string.Empty;
        public int edad { get; set; } = 0;
        public string localizacion { get; set; } = string.Empty;
    }
}

