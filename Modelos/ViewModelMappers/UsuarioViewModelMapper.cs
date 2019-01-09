using Dominio.Usuarios;
using Modelos.ViewModels;
using AutoMapper;
using Modelos.ViewModelMappers.Interfaces;



namespace Modelos.ViewModelMappers
{
    public class UsuarioViewModelMapper : ViewModelMapper<Usuario, UsuarioViewModel, UsuarioViewModel>, IUsuarioViewModelMapper
    {
       
        public UsuarioViewModelMapper()
        {
          
            Mapper.CreateMap<Usuario, UsuarioViewModel>()
            //.ForMember(model => model., opt => opt.Ignore())
            ;
            Mapper.CreateMap<UsuarioViewModel, Usuario>()
            .ForMember(model => model.Modulos, opt => opt.Ignore())
            .ForMember(model => model.Persona, opt => opt.Ignore())
            ;
        }
        public override UsuarioViewModel Map(Usuario model)
        {
            base.Map(model);
            var viewModel = new UsuarioViewModel
            {
                Nombres = model.NombreCompleto(),
                Usuario = model.UserName,
                Correo = model.Email
            }; 
           
            viewModel.Id = model.Id;
            if (model.Persona != null)
            {
                viewModel.Apellidos = model.Persona.Apellidos;
                viewModel.NombreCompletoDocumento = model.Persona.ObtenerNombreCompletoDocumento();
            }
            
            if (model.UsuarioRol != null)
            {
                viewModel.RolDescripcion = model.UsuarioRol.Descripcion;
                viewModel.RolId = model.UsuarioRol.Id;
            }
            return viewModel;
        }

        public override void Map(UsuarioViewModel viewModel, Usuario model)
        {
            base.Map(viewModel, model);
        }

    }
}