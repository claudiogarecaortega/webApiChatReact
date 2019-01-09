using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModelMappers.Interfaces
{
    public interface IViewModelMapper<TModel, TViewModel, TCommonModel>
    {
        void Map(TViewModel viewModel, TModel model);
        TViewModel Map(TModel model);
        IEnumerable<TViewModel> Map(IEnumerable<TModel> models);
        void MapCommon(TCommonModel viewModel, TModel model);
        TCommonModel MapCommon(TModel model);
        IEnumerable<TCommonModel> MapCommon(IEnumerable<TModel> models);
    }
}
