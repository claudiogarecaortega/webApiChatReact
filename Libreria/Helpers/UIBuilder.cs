using System;
using System.Linq.Expressions;
using System.Web;
using Libreria.Utils;

namespace Libreria.Helpers
{
    public abstract class UIBuilder : IHtmlString
    {
        public abstract string ToHtmlString();

        protected virtual string GetPropertyName<T, TId>(Expression<Func<T, TId>> expression)
        {
            return ReflectionUtils.Instance.GetPropertyName(expression);
        }
    }
}