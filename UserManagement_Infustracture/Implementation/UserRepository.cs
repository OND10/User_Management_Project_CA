using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;
using UserManagement_Domain.Interfaces;
using UserManagement_Infustracture.DBContext;

namespace UserManagement_Infustracture.Implementation
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public List<User> users;
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context):base(context)
        {
            _context = context;
            users = new List<User>()
            {
                 new User
                {
                    Id=1,Name="User1",Username="OND",Email="user1@gmail.com",Gender=Convert.ToBoolean(GenderEnum.Male),
                    PhoneNumber="+967-777777777",Password="Osamadammag2002$",ConfirmPassword="Osamadammag2002$"
                },

                new User
                {
                    Id=2,Name="User2",Username="Shelly",Email="user2@gmail.com",Gender=Convert.ToBoolean(GenderEnum.Female),
                    PhoneNumber="+967-777777254",Password="Shelly232@",ConfirmPassword="Shelly232@"
                },
            };
        }


        public string Email { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = null!;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public int Id { get; set; }


        public new async Task<IEnumerable<User>> GetAllAsync()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var list = _context.Users.ToList();
#pragma warning restore CS8604 // Possible null reference argument.
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return await Task.FromResult<IEnumerable<User>>(list);
            }
        }

        //public new int SaveChangeAsync()
        //{
        //    if (_context.SaveChanges() == 1)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public new async Task<User> AddAsync(User model)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _context.Users.Add(model);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _context.SaveChanges();
            return await Task.FromResult<User>(model);
        }

        public new async Task<User> DeleteAsync(User model)
        {
            users.Remove(model);
            return await Task.FromResult<User>(model);
        }


        public new async Task<User> GetByIdAsync(int id)
        {
            var find = users.FirstOrDefault(x => x.Id == id);
            if (find == null)
            {
                throw new IdNullException("Exception : Id is Null");
            }
            else
            {
                return await Task.FromResult<User>(find);
            }
        }

        public new Task<IEnumerable<User>> Query(string query)
        {
            throw new ModelNullException(nameof(query), "Repo Query Exception");
        }

        public new Task<User> UpdateAsync(User model)
        {
            throw new ModelNullException(nameof(model), "Repo Update Exception");
        }


    }
}
