using System;
namespace Web.Model
{
    public class UserGame
    {
        public int id_usuario { get; set; } = 0;
        public int puntuacion_juego { get; set; } = 0;
        public int tiempo_jugado { get; set; } = 0;
        public int llaves_obtenidas { get; set; } = 0;
        public string premios { get; set; } = string.Empty;

        public UserGame()
        {
        }
    }
}

