using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VolviendoACasita.DataAccess.Data;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        // La propiedad tracked = true es para una entidad que solo necesite leer el dato y no tenga intención de modificarla
        // El include properties es para traerme la entidad o si quiero las composiciones (osea entidades dentro de entidades)
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public TDestination ConvertEntityToDto<TSource, TDestination>(TSource entity)
        {
            return _mapper.Map<TDestination>(entity);
        }

        public TSource ConvertDtoToEntity<TSource, TDestination>(TDestination dto)
        {
            return _mapper.Map<TSource>(dto);
        }

        public async Task EditItem(int id, T updatedEntity)
        {
            var trackedEntity = await dbSet.FindAsync(id);

            if (trackedEntity != null)
            {
                // Desvincula la entidad principal del contexto
                _db.Entry(trackedEntity).State = EntityState.Detached;

                // Desvincula las composiciones de la entidad principal del contexto
                DetachChildEntities(trackedEntity);
            }

            if (updatedEntity != null)
            {
                // Si la entidad actualizada está en estado Unchanged, la desvinculamos del contexto
                if (_db.Entry(updatedEntity).State == EntityState.Unchanged)
                {
                    _db.Entry(updatedEntity).State = EntityState.Detached;

                    // Desvincula las composiciones de la entidad actualizada del contexto
                    DetachChildEntities(updatedEntity);
                }

                // Actualiza la entidad principal y sus composiciones
                _db.Update(updatedEntity);

                // Guarda los cambios en la base de datos
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Entity not found.");
            }
        }

        private void DetachChildEntities(T entity)
        {
            // Implementa la lógica para desvincular las composiciones de la entidad del contexto
            // Recorre las propiedades de navegación y establece su estado en Detached
            foreach (var navigationEntry in _db.Entry(entity).Navigations)
            {
                if (navigationEntry.CurrentValue != null)
                {
                    if (navigationEntry.CurrentValue is IEnumerable<object> collection)
                    {
                        foreach (var item in collection)
                        {
                            _db.Entry(item).State = EntityState.Detached;
                        }
                    }
                    else
                    {
                        _db.Entry(navigationEntry.CurrentValue).State = EntityState.Detached;
                    }
                }
            }
        }



    }
}
