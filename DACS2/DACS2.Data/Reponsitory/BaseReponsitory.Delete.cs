using DACS2.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.Reponsitory
{
    public partial class BaseReponsitory
    {
        public virtual async Task DeleteAsync(BaseEntity entity)
        {
            var now = DateTime.Now;
            entity.DeleteAt = now;
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
      
        public virtual async Task DeleteAsync<TEntity>(int id) where TEntity : BaseEntity
        {
            var tableName = GetTableName<TEntity>();
            var now = DateTime.Now;
            var query = $"UPDATE {tableName} SET DeleteAt = GETDATE() WHERE Id = {id}";
            LogDebugQuery(query);
            await _db.Database.ExecuteSqlRawAsync(query);
        }

      

        public virtual async Task HardDeleteAsync<TEntity>(int id) where TEntity : BaseEntity
        {
            var tableName = GetTableName<TEntity>();
            var deleteQuery = $"DELETE FROM {tableName} WHERE Id = {id}";
            LogDebugQuery(deleteQuery);
            await _db.Database.ExecuteSqlRawAsync(deleteQuery);
        }

        public virtual async Task HardDeleteAsync<TEntity>(IEnumerable<int> ids) where TEntity : BaseEntity
        {
            if (ids == null || !ids.Any())
            {
                throw new Exception("Danh sách ID rỗng");
            }
            var tableName = GetTableName<TEntity>();
            var deleteQuery = $"DELETE FROM {tableName} WHERE Id IN ({string.Join(',', ids)})";
            LogDebugQuery(deleteQuery);
            await _db.Database.ExecuteSqlRawAsync(deleteQuery);
        }
    }
}
