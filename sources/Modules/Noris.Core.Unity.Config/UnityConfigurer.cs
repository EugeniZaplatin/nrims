using System.Collections.Generic;
using System.Security.Principal;
using Noris.Unity.Attributes;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;

namespace Noris.Core.Unity.Config
{
    /// <summary>
    /// Собирает по всему проекту классы, в которых есть атрибут, описывающий внедрение зависимостей и регистрирует их в Unity контейнере
    /// </summary>
    public static class UnityConfigurer
    {
        public static IUnityContainer UnityContainerBuilder(IList<Assembly> assemblies)
        {
            var container = new UnityContainer();

            //container.AddNewExtension<Interception>();
            container.RegisterInstance<IUnityContainer>(container);
            //container.RegisterType<DbConnection>(new PerRequestLifetimeManager(), new InjectionFactory(c => new DbConnection()));
            container.RegisterType(typeof(IPrincipal), typeof(NullPrincipal));

            //Регистрируются зависимости уровня ядра
            //_registerTypes(typeof(BaseDao<,,>).Assembly, container); //Репозитории
            //... Сервисы


            //Регистрируются зависимости уровня прикладного модуля
            foreach (var assembly in assemblies)
            {
                _registerTypes(assembly, container);
            }

            return container;
        }

        public class NullPrincipal : IPrincipal
        {
            public bool IsInRole(string role)
            {
                return false;
            }

            public IIdentity Identity { get; private set; }
        }


        /// <summary> Найденные в сборке классы на которых висит атрибут указывающий на внедрение зависимостей
        ///  регистрирует в переданном Unity контейнере
        /// ComponentAttribute - это родительский атрибут для всех атрибутов предназначенных для отметки классов использующих внедрение зависимостей
        /// </summary>
        private static void _registerTypes(Assembly assembly, IUnityContainer container)
        {
            var temp = assembly.GetTypes();

            var temp2 =  
                //Выбираются типы из указанной сборки
                temp.Select(t => new
                {
                    type = t,
                    componentAttributes =
                        t.GetCustomAttributes(typeof (ComponentAttribute), true)
                            //Выбираются атрибуты производные от указанного типа ComponentAttribute
                            .Cast<ComponentAttribute>() //Преобразуется к указанному типу ComponentAttribute
                            .ToList()
                })
                .Where(t => t.componentAttributes.Count() > 0)
                // у которых есть хоть один атрибут унаследованный от ComponentAttribute
                .ToList();

                temp2.ForEach(t =>
                {
                    //проходим по всем атрибутам выбранных типов
                    t.componentAttributes.ForEach(a =>
                    {
                        if (a is ConfigurationAttribute) //Атрибут класса устанавливающего зависимость для различных конфигураций
                        {
                            container.RegisterType(t.type, t.type, new ContainerControlledLifetimeManager());
                            
                        }
                        else
                        {
                            if (a is ServiceAttribute)
                            {
                                var sa = a as ServiceAttribute;
                                if (!string.IsNullOrEmpty(sa.ModuleName))
                                {
                                    container.RegisterType(a.ForInterface, t.type, sa.ModuleName);
                                }
                            }
                            else
                            {
                                var c = container.RegisterType(a.ForInterface, t.type);
                            }

                            //TODO Не понятно что происходит в этом коде. Из-за ошибке пока отключен
                            //if (a is ServiceAttribute) //Атрибут класса устанавливающего зависимость для сервисов
                            //{
                            //    c.Configure<Interception>()
                            //        .SetInterceptorFor(a.ForInterface, new InterfaceInterceptor());
                            //}
                        }
                    });
                });

            temp2.ForEach(x => x.componentAttributes.ForEach(a =>
            {
                if (a is ConfigurationAttribute)
                    container.Resolve(x.type, null);
            }));
        }
    }
}
