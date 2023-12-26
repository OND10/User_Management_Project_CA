using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Common.Enums;
using UserManagement_Domain.Common.Exceptions;
using UserManagement_Domain.Entities;
using UserManagement_Domain.IRepositories;
using UserManagement_Infustracture.DBContext;

namespace UserManagement_Infustracture.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T model)
        {
            try
            {
                if (model is not null)
                {
                    var add = await _context.AddAsync(model);
                    if (add.State == EntityState.Added)
                    {
                        await _context.SaveChangesAsync();
                        return add.Entity as T;
                    }
                    else
                    {
                        return add.Entity;
                    }
                }
                else
                {
                    throw new ModelNullException(nameof(model), "Repo Add Exception");
                }
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Repo Add Exception");
            }
        }

        public async Task<T> DeleteAsync(T model)
        {
            try
            {
                var del = _context.Remove(model);
                if (del.State == Microsoft.EntityFrameworkCore.EntityState.Deleted)
                {
                    await _context.SaveChangesAsync();
                    return del.Entity as T;
                }
                else
                {
                    return del.Entity;
                }
            }
            catch (Exception)
            {

                throw new ModelNullException(nameof(model), "Repo Delete Exception");
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var list = await _context.Set<T>().ToListAsync();
                if (list.Count == 0)
                {
                    return Enumerable.Empty<T>();
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(Exception), "Repo Getall Exception");
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {

                var find = await _context.Set<T>().FindAsync(id);
                if (find == null)
                {
                    throw new IdNullException("Repo GetId Exception");
                }

                else
                {
                    await _context.SaveChangesAsync();
                    return find;
                }
            }
            catch (Exception)
            {

                throw new IdNullException("Repo GetId Exception");
            }
        }


        public Task<IEnumerable<T>> Query(string query)
        {


            throw new ModelNullException(nameof(query), "Repo Query Exception");
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T model)
        {
            try
            {
                if (model is not null)
                {
                    var update = _context.Update(model);
                    if (update.State == EntityState.Modified)
                    {
                        await _context.SaveChangesAsync();
                        return update.Entity as T;
                    }
                    else
                    {
                        return update.Entity;
                    }

                }
                else
                {
                    throw new ModelNullException(nameof(model), "Repo Update Exception");
                }
            }
            catch (Exception)
            {
                throw new ModelNullException(nameof(model), "Repo Update Exception");
            }

        }
    }
}
