using System;
using Dominio.Credenciales;
using Modelos.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Modelos.ViewModelMappers.Interfaces;
using Persistencia.Daos.Interfaces;


namespace Modelos.ViewModelMappers
{
    public class AbonoViewModelMapper : ViewModelMapper<Abono, AbonoViewModel, AbonoViewModel>, IAbonoViewModelMapper
    {
        private readonly ITipoAbonoDao _tipoAbonoDao;
        private readonly IEstadoDao _estadoDao;
        public  readonly IMapper _userQueryConfig;
        public AbonoViewModelMapper(ITipoAbonoDao tipoAbonoDao, IEstadoDao estadoDao)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Abono, AbonoViewModel>();
                   

            //    cfg.CreateMap<AbonoViewModel, Abono>()
            //        .ForMember(model => model.Credenciales, opt => opt.Ignore())
            //        .ForMember(model => model.TipoAbono, opt => opt.Ignore())
            //        .ForMember(model => model.Usuario, opt => opt.Ignore())
            //        .ForMember(model => model.Estado, opt => opt.Ignore())
            //        ;

            //});
            //_userQueryConfig = config.CreateMapper();
            _tipoAbonoDao = tipoAbonoDao;
            _estadoDao = estadoDao;
            Mapper.CreateMap<Abono, AbonoViewModel>()
            //.ForMember(model => model.Categorias, opt => opt.Ignore())
            ;
            Mapper.CreateMap<AbonoViewModel, Abono>()
            .ForMember(model => model.Credenciales, opt => opt.Ignore())
            .ForMember(model => model.TipoAbono, opt => opt.Ignore())
            .ForMember(model => model.Usuario, opt => opt.Ignore())
            .ForMember(model => model.Estado, opt => opt.Ignore())
            ;
        }
        public override AbonoViewModel Map(Abono model)
        {
            try
            {
                var viewModel = base.Map(model);
                if (model.Estado != null)
                {
                    viewModel.Estado = model.Estado.Descripcion;
                    viewModel.EstadoId = model.Estado.Id;
                }
                if (model.TipoAbono != null)
                {
                    viewModel.TipoAbono = model.TipoAbono.Descripcion;
                    viewModel.TipoAbonoId = model.TipoAbono.Id;
                }
                return viewModel;
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public override void Map(AbonoViewModel viewModel, Abono model)
        {
            try
            {
                base.Map(viewModel, model);
                this.Set(hospital => model.TipoAbono = hospital, viewModel.TipoAbonoId, _tipoAbonoDao);
                this.Set(hospital => model.Estado = hospital, viewModel.EstadoId, _estadoDao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override IEnumerable<AbonoViewModel> Map(IEnumerable<Abono> models)
        {
            try
            {
                return models.Select(Map);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}