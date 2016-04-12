using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.Core;

namespace GamaAfterTheHolyGrail.CooperacionModule.Services
{
    public class FakeProyectoRepository : IProyectoRepository
    {
        public List<Proyecto> GetAll()
        {
            var fakeProject1 = new Proyecto()
            {
                Id = 1,
                Titulo = "Atlántida Juvenil 2015",
                FechaDeInicio = new DateTime(2016, 1, 1),
                FechaDeFinalizacion = new DateTime(2016, 1, 1),
                Descripcion = "Prism is designed so that you can use any of the preceding capabilities and design patterns individually, or all together, depending on your requirements and your application scenario. You can use the MVVM pattern, modularity, regions, commands, or events in any combination without having to adopt all of them. Of course, if you want to take full advantage of the benefits that separation of concerns and loose coupling offers, you will typically use many of Prism's capabilities and design patterns in conjunction with each other. The following illustration shows a typical Prism application architecture and shows how all the various capabilities of Prism can work together within a multi-module composite application.",
                Objetivos = new List<Objetivo>()
                {
                    new Objetivo() { Titulo = "Objetivo número 1 para conseguir algo más o menos concreto" },
                    new Objetivo() { Titulo = "A veces los objetivos se escriben de diferentes maneras" },
                    new Objetivo() { Titulo =  "Las piedras preciosas han llevado a más de un rey a la locura" },
                },
                Tags = new List<Tag>() {
                    new Tag() { Value = "juventud" },
                    new Tag() { Value = "relación en pareja" },
                    new Tag() { Value = "salud" },
                },
                Eventos = new List<Evento>()
                {
                    new Evento() { Titulo = "Ha tenido lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-13) },
                    new Evento() { Titulo = "Tuvo lugar aquel inverosímil evento", Fecha = DateTime.Now.AddDays(-4) },
                    new Evento() { Titulo = "Ha pasado lugar este sempiterno evento", Fecha = DateTime.Now.AddDays(-3) },
                    new Evento() { Titulo = "Sucedió lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-56) },
                    new Evento() { Titulo = "Ha colapsado un evento lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-2) },
                    new Evento() { Titulo = "Ha tenido lugar este inverosímil fenómeno", Fecha = DateTime.Now.AddDays(-1) },
                    new Evento() { Titulo = "Disolvióse delante nuestra, lugar este irreal evento", Fecha = DateTime.Now.AddDays(-13) },
                    new Evento() { Titulo = "Ha tenido lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-0) },
                    new Evento() { Titulo = "Ha tenido lugar este probable evento", Fecha = DateTime.Now.AddDays(-54) },
                },
                Seguimiento = "Prism is designed so that you can use any of the preceding capabilities and design patterns individually, or all together, depending on your requirements and your application scenario. You can use the MVVM pattern, modularity, regions, commands, or events in any combination without having to adopt all of them. Of course, if you want to take full advantage of the benefits that separation of concerns and loose coupling offers, you will typically use many of Prism's capabilities and design patterns in conjunction with each other. The following illustration shows a typical Prism application architecture and shows how all the various capabilities of Prism can work together within a multi-module composite application.",
                Estado = new EstadoDeProyecto()
                {
                    Estado = EstadoDeProyectoEnum.NoProporcionado,
                    UltimaInformacion = "El proyecto se ha iniciado sin incidentes",
                    UltimaActualizacion = DateTime.Now,
                },
                Colaboradores = new List<Colaborador>(),
            };

            var fakeProject2 = new Proyecto()
            {
                Id = 2,
                Titulo = "Atlántida Juvenil 2015",
                FechaDeInicio = new DateTime(2016, 1, 1),
                FechaDeFinalizacion = new DateTime(2016, 1, 1),
                Descripcion = "Prism is designed so that you can use any of the preceding capabilities and design patterns individually, or all together, depending on your requirements and your application scenario. You can use the MVVM pattern, modularity, regions, commands, or events in any combination without having to adopt all of them. Of course, if you want to take full advantage of the benefits that separation of concerns and loose coupling offers, you will typically use many of Prism's capabilities and design patterns in conjunction with each other. The following illustration shows a typical Prism application architecture and shows how all the various capabilities of Prism can work together within a multi-module composite application.",
                Objetivos = new List<Objetivo>()
                {
                    new Objetivo() { Titulo = "Objetivo número 1 para conseguir algo más o menos concreto" },
                    new Objetivo() { Titulo = "A veces los objetivos se escriben de diferentes maneras" },
                    new Objetivo() { Titulo =  "Las piedras preciosas han llevado a más de un rey a la locura" },
                },
                Tags = new List<Tag>() {
                    new Tag() { Value = "juventud" },
                    new Tag() { Value = "relación en pareja" },
                    new Tag() { Value = "salud" },
                },
                Eventos = new List<Evento>()
                {
                    new Evento() { Titulo = "Ha tenido lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-13) },
                    new Evento() { Titulo = "Tuvo lugar aquel inverosímil evento", Fecha = DateTime.Now.AddDays(-4) },
                    new Evento() { Titulo = "Ha pasado lugar este sempiterno evento", Fecha = DateTime.Now.AddDays(-3) },
                    new Evento() { Titulo = "Sucedió lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-56) },
                    new Evento() { Titulo = "Ha colapsado un evento lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-2) },
                    new Evento() { Titulo = "Ha tenido lugar este inverosímil fenómeno", Fecha = DateTime.Now.AddDays(-1) },
                    new Evento() { Titulo = "Disolvióse delante nuestra, lugar este irreal evento", Fecha = DateTime.Now.AddDays(-13) },
                    new Evento() { Titulo = "Ha tenido lugar este inverosímil evento", Fecha = DateTime.Now.AddDays(-0) },
                    new Evento() { Titulo = "Ha tenido lugar este probable evento", Fecha = DateTime.Now.AddDays(-54) },
                },
                Seguimiento = "Prism is designed so that you can use any of the preceding capabilities and design patterns individually, or all together, depending on your requirements and your application scenario. You can use the MVVM pattern, modularity, regions, commands, or events in any combination without having to adopt all of them. Of course, if you want to take full advantage of the benefits that separation of concerns and loose coupling offers, you will typically use many of Prism's capabilities and design patterns in conjunction with each other. The following illustration shows a typical Prism application architecture and shows how all the various capabilities of Prism can work together within a multi-module composite application.",
                Estado = new EstadoDeProyecto()
                {
                    Estado = EstadoDeProyectoEnum.NoProporcionado,
                    UltimaInformacion = "El proyecto se ha iniciado sin incidentes",
                    UltimaActualizacion = DateTime.Now,
                },
                Colaboradores = new List<Colaborador>(),
            };

            var fakeCollaborator1 = new Colaborador()
            {
                Nombre = "Johanus Chimailon Ermenético",
                Telefono = "+34 233 462 2334",
                Email = "Johanus.Chimailon@domain.com",
                Avatar = "avatar2.PNG",
                AvatarB = GetImageProperty(2),
            };

            var fakeCollaborator2 = new Colaborador()
            {
                Nombre = "Bigus Dickus Astronomitelus",
                Telefono = "+34 213 771 5672",
                Email = "Bigus.Dickus@domain.com",
                Avatar = "../Assets/avatar1.PNG",
                AvatarB = GetImageProperty(1),
            };

            var fakeCollaborator3 = new Colaborador()
            {
                Nombre = "Bartolomenius Brian von Hayek",
                Telefono = "+34 219 513 3561",
                Email = "bartolomenius@youareatwat.com",
                Avatar = "../Assets/avatar3.PNG",
                AvatarB = GetImageProperty(3),
            };

            fakeProject1.Colaboradores.Add(fakeCollaborator1);
            fakeProject1.Colaboradores.Add(fakeCollaborator2);
            fakeProject1.Colaboradores.Add(fakeCollaborator3);
            fakeProject1.Colaboradores.Add(fakeCollaborator1);
            fakeProject1.Colaboradores.Add(fakeCollaborator2);

            fakeProject2.Colaboradores.Add(fakeCollaborator1);
            fakeProject2.Colaboradores.Add(fakeCollaborator2);
            fakeProject2.Colaboradores.Add(fakeCollaborator3);
            fakeProject2.Colaboradores.Add(fakeCollaborator1);
            fakeProject2.Colaboradores.Add(fakeCollaborator2);

            var proyectos = new List<Proyecto>() { fakeProject1, fakeProject2 };
            return proyectos;
        }

        private byte[] GetImageProperty(int i)
        {   
            var streamResourceInfo =
                App.GetResourceStream(
                new Uri(String.Format("GamaAfterTheHolyGrail.CooperacionModule;component/Assets/avatar{0}.PNG", i.ToString()),
                UriKind.Relative));

            var length = streamResourceInfo.Stream.Length;
            byte[] image = new byte[length];
            streamResourceInfo.Stream.Read(image, 0, (int)length);

            return image;
        }
    }
}
