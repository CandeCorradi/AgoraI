using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ExtensionMethod
{
    public static class MyExtensions
    {
        
        public static void TryAttach<TContext, TEntity>(this TContext context, TEntity entity)
                where TContext : DbContext
                where TEntity : class?
        {
            if (entity == null)
            {
                return;
            }
            if (!context.Set<TEntity>().Local.Any(e => e == entity))
            {
                context.Set<TEntity>().Attach(entity);
                return;
            }
            var entryAttached = context.Set<TEntity>().Local.FirstOrDefault(e => e == entity);
            entity = entryAttached; 
            return;
        }
    }
}
//intenta hacer el attach pero lo hace solo si no esta atachado, basicamente, recibe por parametros la identidad que se intenta atachar, si no la recibe retorna y no hace nada
//, si la recibe, busca en el contexto si ya existe un objeto atachado con esa identidad, si no lo encuentra, hace el attach, si lo encuentra, asigna la referencia del objeto atachado a la variable entity y retorna.
//atachar = ignorar