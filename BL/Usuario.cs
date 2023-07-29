using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    int queryEF = context.UsuarioAdd(usuario.Nombre, usuario.PrimerApellido, usuario.SegundoApellido, usuario.FechaNacimiento, usuario.Sexo, usuario.EstadoNacimiento, usuario.CURP, usuario.Direccion.Colonia.IdColonia);
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el usuario" + ex;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    int queryEF = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.PrimerApellido, usuario.SegundoApellido, usuario.FechaNacimiento, usuario.Sexo, usuario.EstadoNacimiento, usuario.CURP, usuario.Direccion.Colonia.IdColonia);
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el usuario" + ex;
            }
            return result;
        }
        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    int queryEF = context.UsuarioDelete(IdUsuario); //(usuario.IdUsuario)
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el usuario" + ex;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    var queryEF = context.UsuarioGetAll().ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.PrimerApellido = obj.PrimerApellido;
                            usuario.SegundoApellido = obj.SegundoApellido;
                            usuario.FechaNacimiento = (DateTime)obj.FechaNacimiento;
                            usuario.Sexo = obj.Sexo;
                            usuario.EstadoNacimiento = obj.EstadoNacimiento;
                            usuario.CURP = obj.CURP;


                            usuario.Direccion = new ML.Direccion();

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = obj.IdColonia;
                            usuario.Direccion.Colonia.Nombre = obj.Colonia;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.Municipio;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.Estado;



                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el usuario" + ex;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.DrSecurityModel context = new DL.DrSecurityModel())
                {
                    var obj = context.UsuarioGetById(idUsuario).FirstOrDefault();
                    if (obj != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = obj.IdUsuario;
                        usuario.Nombre = obj.Nombre;
                        usuario.PrimerApellido = obj.PrimerApellido;
                        usuario.SegundoApellido = obj.SegundoApellido;
                        usuario.FechaNacimiento = (DateTime)obj.FechaNacimiento;
                        usuario.Sexo = obj.Sexo;
                        usuario.EstadoNacimiento = obj.EstadoNacimiento;
                        usuario.CURP = obj.CURP;


                        usuario.Direccion = new ML.Direccion();

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = obj.IdColonia;
                        usuario.Direccion.Colonia.Nombre = obj.Colonia;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = obj.Municipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.Estado;

                        result.Object = usuario;

                        result.Correct = true;
                    }
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
