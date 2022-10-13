using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeShared
{
    /// <summary> Модуль для регистрации DI.</summary>
    public interface IModule
    {
        /// <summary> Зарегистрировать зависимости.</summary>
        /// <param name="services">Services.</param>
        void RegisterDependencies(IServiceCollection services);
    }
}
