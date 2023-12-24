using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common.Enums;

namespace TestProject
{
    public class UserFakeDataObject
    {

            
            public int Id { get; set; }
        
            public string Name { get; set; } = string.Empty;
       
            public string Email { get; set; } = string.Empty;

            public string? Password { get; set; }
        
            public bool Gender { get; set; } = Convert.ToBoolean(GenderEnum.Female);
       
            public string Username { get; set; } = null!;

            public string PhoneNumber { get; set; } = string.Empty;


    }
}
