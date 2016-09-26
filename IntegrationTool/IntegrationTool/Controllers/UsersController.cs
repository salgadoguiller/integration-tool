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

        [HttpGet]
        public ActionResult formUser()
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

        [HttpGet]
        public void getUser(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                User user = userModel.getUser(id);

                resp = serializeObject(user);
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the user. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getUserTypes()
        {
            string resp = "";
            try
            {
                connectModel();
                List<UsersType> userTypes = userModel.getUserTypes();

                resp = serializeObject(userTypes);
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the user types. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getResources()
        {
            string resp = "";
            try
            {
                connectModel();
                List<Resource> resources = userModel.getResources();

                resp = serializeObject(resources);
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the resources. Please try again.\"}";
            }

            response(resp);
        }

        // ================================================================================================================
        // Almacenar en base de datos usuarios.
        // ================================================================================================================
        [HttpPut]
        public void saveUser()
        {
            string resp = "";
            try
            {
                throw new Exception(Request.Form["Permissions"]);

                // connectModel();
                // userModel.saveUser(Request.Form["UserTypeId"], Request.Form["Name"], Request.Form["Username"], Request.Form["Email"], Request.Form["Password"], Request.Form["Permissions"]);

                resp = "{\"type\":\"success\", \"message\":\"User created succesfully..\"}";
            }
            catch (Exception e)
            {
                resp = "{\"type\":\"danger\", \"message\":\"" + e.Message + "\"}";
                // resp = "{\"type\":\"danger\", \"message\":\"Can not be created the user. Please try again.\"}";
            }

            response(resp);
        }


        // ================================================================================================================
        // Cambiar estados de usuarios.
        // ================================================================================================================
        [HttpGet]
        public void disableUser(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                userModel.disableUser(id);

                resp = "{\"type\":\"success\", \"message\":\"User disable successfully.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be disable user. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void enableUser(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                userModel.enableUser(id);

                resp = "{\"type\":\"success\", \"message\":\"User enable successfully.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be enable user. Please try again.\"}";
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
