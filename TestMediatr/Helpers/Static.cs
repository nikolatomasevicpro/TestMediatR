using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatr.Helpers
{
    public static class Static
    {
        public static void MapType<T>(this SwaggerGenOptions options)
        {
            var oas = GetType(typeof(T));
            options.MapType<T>(() => oas);
        }

        public static OpenApiSchema GetType(Type t)
        {
            var oas = new OpenApiSchema();
            oas.Type = t.AssemblyQualifiedName;
            oas.Properties = GetProps(t);

            return oas;
        }

        private static IDictionary<string, OpenApiSchema> GetProps(Type t)
        {
            var props = new Dictionary<string, OpenApiSchema>();
            OpenApiSchema schema;

            var list = t.GetProperties();
            foreach (var item in list)
            {
                if (item.IsPubliclyWritable())
                { 
                    props[item.Name] = GetType(item.PropertyType);
                }
            }

            return props;
        }
    }
}
