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
        public void updateUser()
        {

        }


        // ================================================================================================================
        // Obtener datos relacionados con la gestón de usuarios en el sistema.
        // ================================================================================================================
        public List<User> getUsers()
        {
            List<User> users = usersDB.Users.ToList();
            return users;
        }
    }
}
