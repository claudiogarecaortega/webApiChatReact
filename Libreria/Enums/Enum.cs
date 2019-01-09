using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Enums
{
    public enum EntidadesAuditables
    {
        [EnumMember(Value = "Producto")]
        Producto ,
        [EnumMember(Value = "code")]
        Email ,
        [EnumMember(Value = "dadas")]
        Direccion,
    }

    public enum EnumTipoRedSocial
    {
      Facebook=1,
      Google=2,
      Linkedin=3,
      Twiter=4,
        Youtube=5
    }
    public enum EnumTipoAlerta
    {
        Creacion = 1,
        Eliminacion = 2,
        Edicion = 3,
        Asingnacion = 4,
        VotacionPositiva = 5,
        VotacionNegativa = 6,
    }
    public enum EmunRedesSociales
    {
        Facebook = 1,
        Twiter = 2,
        Linkedin = 3,
        Google=4
    }
    //EstadosEnum
    public enum EnumEstadoPaciente
    {
        Internado = 1,
        Terapia = 2,
        Alta = 3,
        EnConsulta = 4,

    }
    public enum EnumTipoSangre
    {
        O = 1,
        AB = 2,
        A = 3,

    }
    public enum EnumEstadoCivil
    {
        Soltero = 1,
        Casado = 2,
        Viudo = 3,

    }
    public enum EnumEspecialidades
    {
        Cardiologia = 1,
        Internacion = 2,
        Neurocirugia = 3,
        
    }

   
}
