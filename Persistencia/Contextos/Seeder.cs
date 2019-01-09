using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.ChatRooms;
using Dominio.Common;
using Dominio.Personas;
using Dominio.Seguridad;
using Dominio.Usuarios;
using Microsoft.AspNet.Identity;

namespace Persistencia.Contextos
{
    #region Enumeradores

    public enum ModulosEnum
    {

        TipoCredencial
, Educacion
, EmpresaUsuario
, ProfesionalEspecialidad
, Empresa
, Agenda
, Impositivo
, Consultorio
, AspNetUserLogins
, HorarioDisponible
, AspNetUserRoles
, Turno
, TipoAlertaUsuario
, Consulta
, TipoAlerta
, DatosIngreso
, Rol
, Derivacion
, TipoNorificacion
, Especialidad
, TipoNotificacionUsuario
, TipoEspecialidad
, UsuarioAdjunto
, Ubicacion
, UsuarioAlerta
, ProfesionalPrecio
, Alerta
, ProfesionalExperiencia
, UsuarioConfiguracion
, Experiencia
, Configuracion
, ProfesionalPuesto
, UsuarioNotificacion
, Puesto
, Notificacion
, RedesSociales
, PlanFinaciero
, Artista
, PreguntasFrecuentes
, ArtistaAdjunto
, AspNetRoles
, Programacion
, Almacen
, Evento
, Stock
, EventoAdjunto
, StockMovimiento
, ProductoCategoria
, TipoStockMoviento
, Producto
, ModuleAccionMuchas
, DetalleEgreso
, ModuloUsuarioAccionesMuchas
, Egreso
, EgresoDescuento
, Descuento
, EgresoPromocion
, Factura
, ProductoEtiquetas
, DetalleFactura
, UsuarioCredencial
, Pago
, RolTipoAlerta
, Cuenta
, RolTipoNotificaion
, Moneda
, DetallePago
, Promocion
, TipoEgreso
, DetalleIngreso
, IngresoStock
, Accion
, TipoDisponibilidad
, ModuloAccion
, ProductoAdjunto
, Modulo
, Etiqueta
, ModuloUsuarioAccion
, ProductoPrecio
, Usuario
, Proveedor
, AspNetUserClaims
, Escenario
, Credencial
, TipoEntrada
, Abono
, EntradaAdjunto
, Estado
, Entrada
, TipoAbono
, TipoRedSocial
, Adjunto
, PersonalAdjunto
, Estand
, TipoPersonal
, EstandAdjunto
, TipoContacto
, Ingreso
, Paciente
, Persona
, EstadoCivil
, Cliente
, EstadoPaciente
, ClienteAdjunto
, GrupoSanguineo
, Contacto
, HistoriaClinica
, Personal
, __MigrationHistory
, AntecedenteFamiliar
, AdministraProfesional
, Enfermedades
, Profesional
, RelacionFamiliar
, Comentario
, AntecedenteGinecoObstetrico
, GradoEstudio
, HistoriaClinicaAntecedenteNoPatologico
, MensajeContacto
, AntedenteNoPatologico
, TipoAsunto
, HistoriaClinicaAntecedentePatologico
, UsuarioMensajeContacto
, AntedentePatologico
, ProfesionalAdjunto
, Ocupacion
, ProfesionalAfiliacion
, Sexo
, Afiliacion
, TipoDocumento
, ProfesionalEducacion


    }
    public enum eEstadoPaciente
    {
        Internado = 1,
        Terapia = 2,
        Alta = 3,
        EnConsulta = 4,

    }
    public enum TipoDisponiblidad
    {
        Disponible,
        SinStock,
        Descontinuado
    }
    public enum GruposSanguineo
    {
        O,
        AB,
        A
    }
    public enum EstadoCiviles
    {
        Soltero,
        Casado,
        Viudo
    }
    public enum PorductoCategoria
    {
        Folcklore,
        Cumpbia,
        Rock
    }
    public enum Etiquetas
    {
        Nacional,
        Internacional,
        Local
    }
    public enum Escenarios
    {
        Escenario1,
        Escenario2,
        Escenario3
    }
    public enum Estados
    {
        Disponible,
        Reservado,
        Vendido
    }
    public enum Tipoabono
    {
        Cortesia,
        Pago,

    }
    public enum Tipocredencial
    {
        Instransferible,
        Rotativo,
        Interno
    }
    public enum Sexos
    {
        Masculino,
        Femenino,
        Indeterminado
    }
    public enum GradoEducacions
    {
        Bachillerato,
        Universitario,
        Especialiada,
        Maestria,
        Doctorado,
    }
    public enum Especialidades
    {
        Cardiologia,
        Internacio,
        Neurologia
    }
    public enum Padres
    {
        Argentina,
        Bolivia,

    }
    public enum HijosArgentina
    {
        BuenosAires,
        Cordoba,
        Mendoza,
        Tucuman,
        Salta,

    }
    public enum HijosBolivia
    {
        Tarija,
        SantaCruz,
        Lapaz,
        Cochabamana,
        Sucre,

    }
    public enum TipoEspecialidades
    {
        Especialidad,
        SubEspeciadlidad,
        Masterado,

    }
    public enum TipoPersonales
    {
        Administratico,
        Enfermeria,


    }
    public enum Patologicos
    {
        Cardiovasculares,
        Alergicos,
        Diabetes,


    }
    public enum NoPatologicos
    {
        Alcohol,
        Tabaquismo,
        Drogas,


    }
    public enum eMedicos
    {
        Medico1,
        Medico2,
        Medico3,


    }
    public enum ePacientes
    {
        Paciente1,
        Paciente2,
        Paciente3,


    }
    public enum ePersonal
    {
        Personal1,
        Personal2,
        Personal3,


    }
    public enum eEnfermedades
    {
        Diabetes,
        Edema,
        Ulceras,
        Cancer,


    }
    public enum eTipoRelacion
    {
        Padre,
        Madre,
        HErmano,
        Hijo,


    }
    public enum eAlergias
    {
        Camaron,
        Penisilina,
        Mani,
        Paracetamol,


    }
    #endregion

    public class Seeder
    {
        public void Seed()
        {
            using (var context = new ApplicationDbContext())
            {
                using (var transaccion = context.Database.BeginTransaction())
                {

                  
                  
                    #region Acciones
                    if (!context.Accions.Any())
                    {
                        var accion = new Accion
                        {
                            Descripcion = "Ver",
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true

                        };
                        context.Accions.Add(accion);
                        var accion2 = new Accion
                        {
                            Descripcion = "Editar",
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true
                        };
                        context.Accions.Add(accion2);
                        var accion3 = new Accion
                        {
                            Descripcion = "Borrar",
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true
                        };
                        context.Accions.Add(accion3);
                        var accion4 = new Accion
                        {
                            Descripcion = "Crear",
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true
                        };
                        context.Accions.Add(accion4);
                        context.SaveChanges();

                    }


                    #endregion

                    #region Roles

                    if (!context.Rol.Any())
                    {
                        var rol = new Rol
                        {
                            Descripcion = "Admin",
                            Nombre = "Admin",
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true,
                          

                        };
                        context.Rol.Add(rol);
                        var usuarioRol = new Rol
                        {
                            Descripcion = "Usuario",
                            Nombre = "Usuario",
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true,
                          
                        };
                        context.Rol.Add(usuarioRol);
                        context.SaveChanges();
                    }

                    #endregion

                   
                    #region tipoDocumento

                    if (!context.TipoDocumentos.Any())
                    {
                        var tipoDocumento = new TipoDocumento()
                        {
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true,
                            Descripcion = "Dni"
                        };
                        var tipoDocumento2 = new TipoDocumento()
                        {
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true,
                            Descripcion = "Pasaporte"
                        };
                        context.TipoDocumentos.Add(tipoDocumento);
                        context.TipoDocumentos.Add(tipoDocumento2);
                        context.SaveChanges();
                    }

                    #endregion

                  

                 
                    #region sexo

                    if (!context.Sexo.Any())
                    {
                        foreach (var suit in Enum.GetNames(typeof(Sexos)))
                        {
                            var modulo3 = new Sexo()
                            {
                                Descripcion = suit,
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true

                            };
                            context.Sexo.Add(modulo3);
                            context.SaveChanges();
                        }
                    }

                    #endregion

                   
                    #region Estado Civil

                    if (!context.EstadoCivils.Any())
                    {
                        foreach (var suit in Enum.GetNames(typeof(EstadoCiviles)))
                        {
                            var modulo3 = new EstadoCivil()
                            {
                                Descripcion = suit,
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true

                            };
                            context.EstadoCivils.Add(modulo3);
                            context.SaveChanges();
                        }
                    }

                    #endregion
                   
                    #region sexo

                    #region Ubicacion

                    if (!context.Ubicacions.Any())
                    {
                        foreach (var suit in Enum.GetNames(typeof(Padres)))
                        {
                            var modulo3 = new Ubicacion()
                            {
                                Descripcion = suit,
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true

                            };
                            context.Ubicacions.Add(modulo3);

                        }
                        context.SaveChanges();
                        foreach (var suit in Enum.GetNames(typeof(HijosArgentina)))
                        {
                            var modulo3 = new Ubicacion()
                            {
                                Descripcion = suit,
                                UbicacionPadre = context.Ubicacions.FirstOrDefault(k => k.Id == 1),
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true

                            };
                            context.Ubicacions.Add(modulo3);

                        }
                        context.SaveChanges();
                        foreach (var suit in Enum.GetNames(typeof(HijosBolivia)))
                        {
                            var modulo3 = new Ubicacion()
                            {
                                Descripcion = suit,
                                UbicacionPadre = context.Ubicacions.FirstOrDefault(k => k.Id == 2),
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true

                            };
                            context.Ubicacions.Add(modulo3);

                        }
                        context.SaveChanges();
                    }

                    #endregion

                   
                    #endregion
                    if (!context.Modulos.Any())
                    {
                        foreach (var suit in Enum.GetNames(typeof(ModulosEnum)))
                        {
                            var modulo3 = new Modulo
                            {
                                Nombre = suit,
                                Descripcion = suit,
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true

                            };
                            context.Modulos.Add(modulo3);
                            context.SaveChanges();
                        }

                    }

                    if (!context.ModuloAccions.Any())
                    {
                        foreach (var modulo in context.Modulos)
                        {
                            var moduloaccion = new ModuloAccion
                            {
                                Modulo = modulo,
                                Acciones = context.Accions.ToList(),
                                Rol = context.Rol.FirstOrDefault(x => x.Nombre == "Admin"),
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true


                            };
                            context.ModuloAccions.Add(moduloaccion);
                            var moduloaccionUsuario = new ModuloAccion
                            {
                                Modulo = modulo,
                                Acciones = context.Accions.ToList(),
                                Rol = context.Rol.FirstOrDefault(x => x.Nombre == "Usuario"),
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Activo = true


                            };
                            context.ModuloAccions.Add(moduloaccionUsuario);
                        }
                        context.SaveChanges();
                    }
                    if (!context.ChatRooms.Any(x=>x.Name=="unittest"))
                    {
                        var chatroom = new ChatRoom()
                        {
                            Name = "unittest",
                            Description = "unittest",
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true
                        };
                        context.ChatRooms.Add(chatroom);
                       
                        context.SaveChanges();
                    }
                    if (!context.Users.Any(u=>u.UserName== "c@c.com"))
                    {
                        var ra = new Random();
                        PasswordHasher _passwordHasher = new PasswordHasher();
                        var usuario = new Usuario
                        {
                            UserName = "c@c.com",
                            UsuarioRol = context.Rol.FirstOrDefault(o => o.Nombre == "Admin"),
                            Email = "c@c.com",
                            SecurityStamp = Guid.NewGuid().ToString(),
                            LockoutEnabled = true,
                           
                            UltimoAccesso = DateTime.Now,
                            Persona = new Persona()

                            {
                                Nombres = "Administrador",
                                Apellidos = "Administrador",
                                FechaAlta = DateTime.Now,
                                UsuarioAlta = 1,
                                Documento = (ra.Next(741254,96665655)).ToString(),
                           
                                Activo = true
                            },
                            PasswordHash = _passwordHasher.HashPassword("clave123"),
                            FechaAlta = DateTime.Now,
                            UsuarioAlta = 1,
                            Activo = true
                        };
                        // usuario.Persona = new Persona() { Nombres = "", Apellidos = "", FechaNacimiento = DateTime.Now.Date };



                        context.Users.Add(usuario);

                     
                            context.SaveChanges();
                    }

                  
                    context.SaveChanges();
                    transaccion.Commit();
                }
            }
        }
    }

}
