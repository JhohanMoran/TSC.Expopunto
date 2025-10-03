using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Common.ModelExcel;

namespace TSC.Expopunto.Common
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {

            services.AddTransient<IModelExcelRepository, ModelExcelRepository>();

            return services;
        }
    }
}
