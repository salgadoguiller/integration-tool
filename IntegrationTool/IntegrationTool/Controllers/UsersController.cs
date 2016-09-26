using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegrationTool.Models;

namespace IntegrationTool.Controllers
{
    public class UsersController : Controller
    {
        private UsersModel userModel;
        private Encrypt encryptor;

        // ================================================================================================================
        // Retornar las vistas relacionadas con la gestión de usuarios.
        // ================================================================================================================
        [HttpGet]
        public ActionResult listUsers()
        {
            return View();
        }

        // ================================================================================================================
        // Obtener datos de la base de datos relacionados con la gestión de usuarios.
        // ================================================================================================================
        [HttpGet]
        public void getUsers()
        {
            string resp = "";
            try
            {
                connectModel();
                List<User> users = userModel.getUsers();

                resp = serializeObject(users);
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the users. Please try again.\"}";
            }

            response(resp);
        }

        // ================================================================================================================
        // Metodos privados que proveen funcionalidad a las acciones del controlador.
        // ================================================================================================================
        private void connectModel()
        {
            userModel = new UsersModel();
            encryptor = new Encrypt();
        }

        private void response(string json)
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }

        private string serializeObject(Object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

    }
}
