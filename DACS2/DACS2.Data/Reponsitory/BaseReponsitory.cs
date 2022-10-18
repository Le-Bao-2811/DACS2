using DACS2.Data.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.Reponsitory
{
    public partial class BaseReponsitory
    {
        public readonly DACS2DbContext _db;
        protected readonly IHttpContextAccessor _httpContext;
        protected readonly ILogger<BaseReponsitory> _logger;
        public BaseReponsitory(DACS2DbContext db, IHttpContextAccessor httpContext, ILogger<BaseReponsitory> logger) { 
            _db = db;
            _logger= logger;
            _httpContext= httpContext;
        }
        public virtual async Task BeginTransactionAsync()
        {
            await _db.Database.BeginTransactionAsync();
        }

        public virtual async Task CommitTransactionAsync()
        {
            await _db.Database.CommitTransactionAsync();
        }

        public virtual async Task RollbackTransactionAsync()
        {
            await _db.Database.RollbackTransactionAsync();
        }

        public virtual async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expr) where TEntity : BaseEntity
        {
            return await _db.Set<TEntity>().AnyAsync(expr);
        }
    }
}
