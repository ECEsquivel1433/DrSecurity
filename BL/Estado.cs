using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    var queryEF = context.EstadoGetAll().ToList();
                    result.Objects = new List<object>();
                    foreach (var obj in queryEF)
                    {
                        ML.Estado estado = new ML.Estado();
                        estado.IdEstado = obj.IdEstado;
                        estado.Nombre = obj.Nombre;
                        result.Objects.Add(estado);
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el usuario" + ex;
            }
            return result;
        }
    }
}
