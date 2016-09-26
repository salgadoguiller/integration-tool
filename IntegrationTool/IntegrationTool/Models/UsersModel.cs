using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationTool.Models
{
    public class UsersModel
    {
        private IntegrationToolEntities usersDB;

        public UsersModel()
        {
            usersDB = new IntegrationToolEntities();
        }

        // ================================================================================================================
        // Almacenar datos relacionados con la gestón de usuarios en el sistema.
        // ================================================================================================================
        public void saveUser()
        {

        }

        // ================================================================================================================
        // Actualizar datos relacionados con la gestón de usuarios en el sistema.
        // ================================================================================================================
        public void enableUser(int id)
        {
            User user = usersDB.Users.Where(param => param.UserId == id).ToList()[0];
            int enable = usersDB.Status.Where(param => param.Name == "Enable").ToList()[0].StatusId;

            user.StatusId = enable;

            usersDB.SaveChanges();
        }

        public void disableUser(int id)
        {
            User user = usersDB.Users.Where(param => param.UserId == id).ToList()[0];
            int disable = usersDB.Status.Where(param => param.Name == "Disable").ToList()[0].StatusId;

            user.StatusId = disable;

            usersDB.SaveChanges();
        }


        // ================================================================================================================
        // Obtener datos relacionados con la gestón de usuarios en el sistema.
        // ================================================================================================================
        public List<User> getUsers()
        {
            List<User> users = usersDB.Users.ToList();
            return users;
        }

        public User getUser(int id)
        {
            User user = usersDB.Users.Where(param => param.UserId == id).ToList()[0];
            return user;
        }

        public List<UsersType> getUserTypes()
        {
            List<UsersType> userTypes = usersDB.UsersTypes.ToList();
            return userTypes;
        }

        public List<Resource> getResources()
        {
            List<Resource> resources = usersDB.Resources.ToList();
            return resources;
        }
    }
}
