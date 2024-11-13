using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp.efc
{
    public static class AddDatabase
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection collection, string connectionString)
        {
            return collection.AddDbContextPool<bpContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
            });
        }
    }
}