using Domain.Contracts;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery <TEntity , Tkey> 
            (
            IQueryable<TEntity> InputQuery,
            ISpecifications<TEntity , Tkey> spec
            )
         where TEntity : BaseEntity<Tkey>
        {
            var query = InputQuery;

            if ( spec.Criteria is not null ) 
                query = query.Where(spec.Criteria);

            query = spec.IncludeExpressions.Aggregate(query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));
            
            return query;
        }



    }
}
