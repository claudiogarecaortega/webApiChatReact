// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System;
using System.Web.Http;
using Persistencia.Daos;
using Persistencia.Daos.Interfaces;
using Persistencia.UnitsOfWork;
using StructureMap;
using Utilidades;
using Modelos.ViewModelMappers;
using Modelos.ViewModelMappers.Interfaces;
using System.Web.Mvc;
using WebChatApi.Controllers;
using WebGrease;
namespace WebChatApi.DependencyResolution {
    using Dominio.Usuarios;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Persistencia.Contextos;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System.Data.Entity;
    using System.Web;
    using Utilidades.Activadores;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

      

        public static IList<string> Assemblies
        {
            get
            {
                return new List<string>
                {
                    "WebChatApi",
                    "Modelos",
                    "Libreria",
                    "Persistencia",
                    "Persistencia.Test",
                };
            }
        }

        public static IList<Tuple<string, string>> ManuallyWired
        {
            get
            {
                return new List<Tuple<string, string>>()
                {
                    Tuple.Create("IUserStore<Usuario>", "UserStore<Usuario>>"),
                    Tuple.Create("DbContext", "ApplicationDbContext"),
                    Tuple.Create("IAuthenticationManager", "HttpContext.Current.GetOwinContext().Authentication"),
                };
            }
        }
        public DefaultRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            For<IUserStore<Usuario, int>>().Use<UserStore<Usuario, Role, int, UserLogin, UserRole, UserClaim>>();
            //For<Iapplic>().Use(() => System.Web.HttpContext.Current.GetOwinContext().Authentication);
            For<IAuthenticationManager>().Use(() => System.Web.HttpContext.Current.GetOwinContext().Authentication);
            For<DbContext>().Use(() => System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>());
            For<IActivatorWrapper>().Use<ActivatorWrapper>();
            For<IUnitOfWorkHelper>().Use<UnitOfWorkHelper>();

        }
        #endregion
    }
    public class InterfazRegistry : Registry
    {
        public InterfazRegistry()
        {
            this.Scan(x =>
            {
                x.TheCallingAssembly();
               
                x.IncludeNamespaceContainingType<ApiController>();
              //  x.IncludeNamespace("WebChatApi.Controllers");
                 x.IncludeNamespaceContainingType<Controller>();
                 x.With(new ControllerConvention());
                //  x.AssembliesFromApplicationBaseDirectory(assem => assem.FullName.Contains("Controller"));
                x.Assembly("WebChatApi");
                  x.Assembly("Modelos");
                  x.Assembly("Persistencia");
                x.WithDefaultConventions();


            });
           
            // this.For<IControllerBehabior>().Use<ControllerBehabior>();
            For<IAdjuntoViewModelMapper>().Use<AdjuntoViewModelMapper>();
            For<IEstadoViewModelMapper>().Use<EstadoViewModelMapper>();
            For<IUbicacionViewModelMapper>().Use<UbicacionViewModelMapper>();
            For<IPersonaViewModelMapper>().Use<PersonaViewModelMapper>();
            For<IAccionViewModelMapper>().Use<AccionViewModelMapper>();
            For<IModuloViewModelMapper>().Use<ModuloViewModelMapper>();
            For<IModuloAccionViewModelMapper>().Use<ModuloAccionViewModelMapper>();
            For<IModuloUsuarioAccionViewModelMapper>().Use<ModuloUsuarioAccionViewModelMapper>();
            For<IRolViewModelMapper>().Use<RolViewModelMapper>();
            For<IUsuarioViewModelMapper>().Use<UsuarioViewModelMapper>();
            For<ITipoDocumentoViewModelMapper>().Use<TipoDocumentoViewModelMapper>();
            For<IEstadoViewModelMapper>().Use<EstadoViewModelMapper>();
            For<IChatRoomParticipantViewModelMapper>().Use<ChatRoomParticipantViewModelMapper>();
            For<IChatRoomViewModelMapper>().Use<ChatRoomViewModelMapper>();
            For<IMessageViewModelMapper>().Use<MessageViewModelMapper>();
        }
    }
    public class DAORegistry : Registry
    {
        public DAORegistry()
        {

            this.Scan(x =>
            {
                x.AssemblyContainingType<ApplicationDbContext>();
                x.With(new ControllerConvention());
                x.WithDefaultConventions();
               });
            For<IRolDao>().Use<RolDao>();
            For<IAdjuntoDao>().Use<AdjuntoDao>();
            For<IUbicacionDao>().Use<UbicacionDao>();
            For<IPersonaDao>().Use<PersonaDao>();
            For<IAccionDao>().Use<AccionDao>();
            For<IModuloDao>().Use<ModuloDao>();
            For<IModuloAccionDao>().Use<ModuloAccionDao>();
            For<IModuloUsuarioAccionDao>().Use<ModuloUsuarioAccionDao>();

            For<IUsuarioDao>().Use<UsuarioDao>();
            For<ITipoDocumentoDao>().Use<TipoDocumentoDao>();
            For<IEstadoDao>().Use<EstadoDao>();
            For<IErrorLogDao>().Use<ErrorLogDao>();
            For<IChatRoomDao>().Use<ChatRoomDao>();
            For<IChatRoomParticipantDao>().Use<ChatRoomParticipantDao>();
            For<IMessageDao>().Use<MessageDao>();

        }
    }
    public class UtilsRegistry : Registry
    {
        public UtilsRegistry()
        {
            this.For<IActivatorWrapper>()
                .Use<ActivatorWrapper>()
                .OnCreation("", i => i.ObjectCreated += BuildUpEntitiesHandler);
        }

        private void BuildUpEntitiesHandler(object sender, ObjectCreatedEventArgs args)
        {
            ObjectFactory.Container.BuildUp(args.Entity);
        }
    }
}