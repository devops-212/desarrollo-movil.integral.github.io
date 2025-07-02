using System.Collections.Generic;

namespace EcoDive_Integradora.Models
{
    public class TriviaModel
    {
        public string Id { get; set; } // Opcional, por si necesitas editar/eliminar
        public string Nombre { get; set; } // Nombre del usuario
        public List<string> Respuestas { get; set; } // Lista de respuestas a las preguntas
    }
}
