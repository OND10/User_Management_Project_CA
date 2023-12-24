using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Entities;
using UserManagement_Domain.IRepositories;

namespace UserManagement_Infustracture.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

       

        public Task<T> AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Query(string query)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}
