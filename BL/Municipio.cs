using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int idEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    var queryEF = context.MunicipioGetByIdEstado(idEstado).ToList();
                    result.Objects = new List<object>();
                    foreach (var obj in queryEF)
                    {
                        ML.Municipio municipio = new ML.Municipio();
                        municipio.IdMunicipio = obj.IdMunicipio;
                        municipio.Nombre = obj.Nombre;
                        result.Objects.Add(municipio);
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
