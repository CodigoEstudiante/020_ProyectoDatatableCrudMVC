using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {

            List<PERSONAS> oLstPersona = new List<PERSONAS>();

            using (DBPRUEBASEntities db = new DBPRUEBASEntities()) {

                oLstPersona = (from p in db.PERSONAS
                               select p).ToList();
            }
            return Json(new { data = oLstPersona }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Obtener(int idpersona) {
            PERSONAS oPersona = new PERSONAS();

            using (DBPRUEBASEntities db = new DBPRUEBASEntities()) {

                oPersona = (from p in db.PERSONAS.Where(x => x.IdPersona == idpersona)
                            select p).FirstOrDefault();
            }

            return Json(oPersona, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(PERSONAS oPersona) {

            bool respuesta = true;
            try
            {

                if (oPersona.IdPersona == 0)
                {
                    using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                    {
                        db.PERSONAS.Add(oPersona);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                    {
                        PERSONAS tempPersona = (from p in db.PERSONAS
                                                where p.IdPersona == oPersona.IdPersona
                                                select p).FirstOrDefault();

                        tempPersona.Nombre = oPersona.Nombre;
                        tempPersona.Apellidos = oPersona.Apellidos;
                        tempPersona.Correo = oPersona.Correo;

                        db.SaveChanges();
                    }

                }
            }
            catch {
                respuesta = false;

            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Eliminar(int idpersona)
        {
            bool respuesta = true;
            try
            {
                using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                {
                    PERSONAS oPersona = new PERSONAS();
                    oPersona = (from p in db.PERSONAS.Where(x => x.IdPersona == idpersona)
                                select p).FirstOrDefault();

                    db.PERSONAS.Remove(oPersona);

                    db.SaveChanges();
                }
            }
            catch {
                respuesta = false;
            }

            

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


    }
}