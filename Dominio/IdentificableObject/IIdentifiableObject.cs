using System;

namespace Dominio.IdentificableObject
{
    public interface IIdentifiableObjectModel
    {
         int Id { get; set; }
        int UsuarioAlta { get; set; }
        int? UsuarioBaja { get; set; }
        int? UsuarioModificacion { get; set; }
        DateTime FechaAlta { get; set; }
        DateTime? FechaBaja { get; set; }
        DateTime? FechaModificacion { get; set; }
        bool Activo { get; set; }
    }
    public interface IIdentifiableObject
    {
        int Id { get; set; }
       
    }
}
