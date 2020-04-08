using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DataModels
{
    public class User
    {
        #region Private Members
        /// <summary>
        /// user name
        /// </summary>
        private string username;
        /// <summary>
        /// password of the user
        /// </summary>
        private string password;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of the user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User( string username, string password )
        {
            this.username = username;

            this.password = password;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Modifiers of the username
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Modifiers of the password of the user
        /// </summary>
        public string Password { get; set; }
        #endregion
    }
}
