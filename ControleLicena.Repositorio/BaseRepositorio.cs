using ControleLicenca.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContratoLicena.Modelo.Repositorio
{
    public class BaseRepositorio <TEntity>
                                where TEntity: ModelBase
    {
        protected DbContext Context { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }
        public BaseRepositorio(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> Add(TEntity model)
        {
            DbSet.Add(model);
            await Context.SaveChangesAsync();
            return model;
        }
        public virtual async Task<TEntity> Replace(int id, TEntity model)
        {
            var originalModel = await FindById(id);

            if (originalModel is null)
            {
                //Claudia, coloque uma exception correta aqui. Eu não me lembro mais, mas é alguma
                //coisa relacionada à NotFoundEntityExcepetion. Pesquise no Google
                //Essa exception é muito genérica.
                throw new Exception("Nenhum elementos encontrado para atualização!");
            }

            model.Id = id;
            Context.Entry(originalModel).CurrentValues.SetValues(model);
            await Context.SaveChangesAsync();
            return model;
        }
        public virtual async Task Remove(int id)
        {
            var originalModel = await FindById(id);
            DbSet.Remove(originalModel);
            await Context.SaveChangesAsync();
        }
        public virtual async Task<TEntity[]> All()
        {
            var result = await DbSet.ToArrayAsync();
            return result;
        }
        public virtual async Task<TEntity> FindById(int id)
        {
            return await Task.Run(() =>
            {
                var model = DbSet.FirstOrDefault(e => e.Id == id);
                return model;
            });
        }
    }
}
