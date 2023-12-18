using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_Application.Services
{
    public class User:IUser
    {
        public string Email { get; set; }

        public string Phonenumber { get; set; }


    }
}
