using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstadoNacimiento { get; set; }
        public string CURP { get; set; }

        public List<object> Usuarios { get; set; }
        public ML.Direccion Direccion { get; set; }
    }
}
