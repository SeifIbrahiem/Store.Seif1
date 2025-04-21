using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository <TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackhCanges = false);
        Task<TEntity?> GetAsync(Tkey id);
        Task AddAsync (TEntity entity);
        void Update (TEntity entity);
        void Delete(TEntity entity);
       
    }
}
