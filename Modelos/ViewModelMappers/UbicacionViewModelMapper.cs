using Dominio.Common;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Daos.Interfaces;


namespace Modelos.ViewModelMappers
{
    public class UbicacionViewModelMapper : ViewModelMapper<Ubicacion, UbicacionViewModel, UbicacionViewModel>, IUbicacionViewModelMapper
    {
        private readonly IUbicacionDao _ubicacionDao;

        public UbicacionViewModelMapper(IUbicacionDao ubicacionDao)
        {
            _ubicacionDao = ubicacionDao;
            Mapper.CreateMap<Ubicacion, UbicacionViewModel>()
			//.ForMember(model => model.Categorias, opt => opt.Ignore())
			;
            Mapper.CreateMap<UbicacionViewModel, Ubicacion>()
			.ForMember(model => model.UbicacionPadre
            , opt => opt.Ignore())
			;
        }
		  public override UbicacionViewModel Map(Ubicacion model)
        {
            var viewModel = base.Map(model);
            viewModel.Descripcion = model.Descripcion;
            viewModel.DescripcionCompleta = model.DescripcionCompleta();
            if (model.UbicacionPadre != null)
            {
                viewModel.UbicacionPadre = model.UbicacionPadre.DescripcionCompleta();
                viewModel.UbicacionPdreId = model.UbicacionPadre.Id;
            }
            return viewModel;
        }

        public override void Map(UbicacionViewModel viewModel, Ubicacion model)
        {
            base.Map(viewModel, model);
            this.Set(ubication => model.UbicacionPadre = ubication, viewModel.UbicacionPdreId, _ubicacionDao);


            //this.Set(hospital => model.UserContact = hospital, viewModel.ContactId, UserExtendedDao);
        }

        public override IEnumerable<UbicacionViewModel> Map(IEnumerable<Ubicacion> models)
        {
            return models.Select(Map);
        }
    }
}