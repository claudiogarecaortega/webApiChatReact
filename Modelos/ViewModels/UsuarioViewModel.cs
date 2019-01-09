using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.IdentificableObject;
using Dominio.Personas;
using Libreria.Resource;

namespace Modelos.ViewModels

{ 
    public class UsuarioViewModel :IIdentifiableObject
    {
		public int Id { get; set; }
        public string Nombres { get; set; }
        public string NombreCompletoDocumento { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Apellidos { get; set; }
        public string Titulo { get; set; }
        public string Desripccion { get; set; }
        public string RolDescripcion { get; set; }
        public int RolId { get; set; }
        public string Imagen { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Estado { get; set; }

        public bool Administrador { get; set; }
        public int UsuarioAlta { get; set; }
        public int? UsuarioBaja { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? UltimoAccesso { get; set; }
        public bool Activo { get; set; }
        public bool Aprobado { get; set; }
        public bool TieneImagen { get; set; }
        public bool ActulizarPerfil { get; set; }
        public string ImagenPerfil { get; set; }
        public string ExtencionImagen { get; set; }
        public string ImagenPath { get; set; }
        public string Descripcion { get; set; }
        public int TipoUsuario { get; set; }
       
        public PersonaViewModel PersonaViewModel { get; set; }

        
    }

    public class EmpresaUsuarioSetViewModel
    {
        public int IdEmpresa { get; set; }
        public string Descricpcion { get; set; }
    }
}