using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    var queryEF = context.ColoniaGetByIdMunicipio(idMunicipio).ToList();
                    result.Objects = new List<object>();
                    foreach (var obj in queryEF)
                    {
                        ML.Colonia colonia = new ML.Colonia();
                        colonia.IdColonia = obj.IdColonia;
                        colonia.Nombre = obj.Nombre;
                        result.Objects.Add(colonia);
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
