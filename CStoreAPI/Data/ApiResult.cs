using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace CStoreAPI.Data
{
    public class ApiResult<T>
    {
        private ApiResult(
            List<T> data)
        {
            Data = data;
        }

        public static async Task<ApiResult<T>> CreateAsync(IQueryable<T> source)
        {
            var count = await source.CountAsync();


            var data = await source.ToListAsync();

            return new ApiResult<T>(
                data);
        }

        public static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(T).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Instance);
            if (prop == null && throwExceptionIfNotFound)
                throw new NotSupportedException(string.Format($"ERROR: Property '{propertyName}' does not exist."));
            return prop != null;
        }
        public List<T> Data { get; private set; }
    }
}