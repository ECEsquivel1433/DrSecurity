using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllEF();
            ML.Usuario usuario = new ML.Usuario();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al consultar los usuarios";
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Result resultEstados = BL.Estado.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            if (resultEstados.Correct)
            {
                usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
            }

            //add
            if (idUsuario == null)
            {
                return View(usuario);
            }
            else //Update
            {
                ML.Result result = BL.Usuario.GetByIdEF(idUsuario.Value);

                usuario = (ML.Usuario)result.Object;

                ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;



                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.AddEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente el usuario";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el usuario";
                }
            }
            else
            {
                result = BL.Usuario.UpdateEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el usuario";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el usuario";
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Message = "Se elimino el usuario";

            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el usuario";
            }
            return PartialView("Modal");
        }


        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects);
        }



    }
}