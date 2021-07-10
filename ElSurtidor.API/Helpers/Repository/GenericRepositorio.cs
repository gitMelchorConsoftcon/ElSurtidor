using ElSurtidor.API.Data;
using ElSurtidor.API.Helpers.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElSurtidor.API.Helpers.Repository
{
    public class GenericRepositorio<T> : IGenericRepositorio<T> where T : class
    {
        private readonly DataContext DB;
        private readonly DbSet<T> Entidad;
        public GenericRepositorio(DataContext db)
        {
            DB = db;
            Entidad = db.Set<T>();
        }

        public async Task< List<T>> GetAll()
        {
            return await Entidad.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Entidad.FindAsync(id);
        }

        public async Task<T> Post(T obj)
        {
            Entidad.Add(obj);
            await DB.SaveChangesAsync();
            return obj;
        }

        public async Task<T> Put(int id, T obj)
        {
            var modificar = await Entidad.FindAsync(id);
            modificar = obj;

            Entidad.Update(modificar);
            await DB.SaveChangesAsync();
            return modificar;
        }

        public async Task<T> Delete(int id)
        {
            var borrar = await Entidad.FindAsync(id);
            Entidad.Remove(borrar);
            await DB.SaveChangesAsync();
            return borrar;
        }

       
       

    }
}
