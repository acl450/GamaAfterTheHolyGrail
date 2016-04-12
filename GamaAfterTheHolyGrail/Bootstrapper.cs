using Prism.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;

namespace GamaAfterTheHolyGrail
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = Shell as Window;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            //Type cooperacionModuleType = typeof(GamaAfterTheHolyGrail.CooperacionModule.CooperacionModule);
            //ModuleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = cooperacionModuleType.Name,
            //    ModuleType = cooperacionModuleType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand
            //});

            Type atencionesModuleType = typeof(Gama.AtencionesModule.AtencionesModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = atencionesModuleType.Name,
                ModuleType = atencionesModuleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }
    }
}
