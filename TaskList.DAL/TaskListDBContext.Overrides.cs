using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskList.Domain;

namespace TaskList.DAL
{
    public partial class TaskListDBContext
    {

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasKey(x => x.Id);
            builder.Entity<T>().HasQueryFilter(x => x.IsDeleted);
            
        }
        static readonly MethodInfo SetGlobalQueryMethod = typeof(TaskListDBContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        private static IList<Type> _entityTypeCache;



        private static IList<Type> GetEntitytypes()
        {
            if(_entityTypeCache!=null)
            {

                return _entityTypeCache.ToList();
            }
            _entityTypeCache = (from a in GetReferencingAssemblies()

                                from t in a.DefinedTypes
                                where t.BaseType == typeof(BaseEntity)
                                select t.AsType()
                               ).ToList();
            return _entityTypeCache;

        }

        private static IEnumerable<Assembly> GetReferencingAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var libaray in dependencies)
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(libaray.Name));
                    assemblies.Add(assembly);

                }
                catch (FileNotFoundException)
                {

                    throw;
                }
               

            }
            return assemblies;


        }


        private string GetLoggedInEmployee()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if(httpContext!=null)
            {
                var user = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if(user!=null)
                {
                    var userIdStr = user.Value;
                    return userIdStr;


                }

            }
            return null;

        }


        //private void OnBeforeSaving()
        //{



        //}
    }
}
