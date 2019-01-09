using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Libreria.Helpers
{
    public class AutocompleteBuilder<TModel, TId> : UIBuilder
    {
        protected string Action;
        protected string AditionalParametersFunction;
        protected string AditionalFunctionParameter;
        protected string Controller;
        protected string DefaultDescription;
        protected string MensajeSinResultados="No se encontraron resultados";
        protected object DefaultId;
        protected Expression<Func<TModel, object>> Expression;
        protected HtmlHelper<TModel> Helper;
        protected Expression<Func<TModel, TId>> IdExpression;
        protected string IdField;
        protected bool UseStyle;
        protected bool HasValidationMessage;
        protected string TextProperty;
        protected string ValueProperty;
        protected string StyleClass;

        public AutocompleteBuilder(HtmlHelper<TModel> helper, Expression<Func<TModel, object>> ex)
        {
            Helper = helper;
            Expression = ex;
        }

        public virtual AutocompleteBuilder<TModel, TId> Id(Expression<Func<TModel, TId>> ex)
        {
            IdField = GetPropertyName(ex);
            IdExpression = ex;
            return this;
        }

        public virtual AutocompleteBuilder<TModel, TId> Source(string action, string controller)
        {
            Action = action;
            Controller = controller;
            return this;
        }

        public virtual AutocompleteBuilder<TModel, TId> ValueField<T>(Expression<Func<T, object>> ex)
        {
            ValueProperty = GetPropertyName(ex);
            return this;
        }

        public virtual AutocompleteBuilder<TModel, TId> TextField<T>(Expression<Func<T, object>> ex)
        {
            TextProperty = GetPropertyName(ex);
            return this;
        }

        public virtual AutocompleteBuilder<TModel, TId> AditionalParameters(string functionName)
        {
            AditionalParametersFunction = functionName + "()";
            return this;
        }

        public virtual AutocompleteBuilder<TModel, TId> AditionalFunction(string functionName)
        {
            AditionalFunctionParameter = functionName + "(ui)";
            return this;
        }
        public virtual AutocompleteBuilder<TModel, TId> MensajeSinResultado(string mensaje)
        {
            MensajeSinResultados = mensaje;
            return this;
        }
        public virtual AutocompleteBuilder<TModel, TId> Style(bool useStyle)
        {
            UseStyle = useStyle;
            return this;
        }
        public virtual AutocompleteBuilder<TModel, TId> SetStyle(string style)
        {
            StyleClass = style;
            return this;
        }
      
        public override string ToHtmlString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Helper.PersonalSEditorFor(Expression,StyleClass,null, DefaultDescription));

            stringBuilder.Append("<div class='form-group'>");
            if (DefaultId != null)
                stringBuilder.Append(Helper.HiddenFor(IdExpression, new {@Value = DefaultId,
                    @class = UseStyle ? StyleClass : "form-control",@autocomplete= "user-password"
                }));
            else
                stringBuilder.Append(Helper.HiddenFor(IdExpression));

            stringBuilder.Append(Helper.ValidationMessage(IdField, new {@class = "help-block"}));
            stringBuilder.Append(GetAjax());
            stringBuilder.Append("</div>");

            return stringBuilder.ToString();
        }

        protected virtual string GetAjax()
        {
            var prefix = "";

            if (!string.IsNullOrEmpty(Helper.ViewData.TemplateInfo.HtmlFieldPrefix))
            {
                prefix = Helper.ViewData.TemplateInfo.HtmlFieldPrefix + "_";
            }

            return string.Format(@"
								<script type=""text/javascript"">
									$(""#{7}{0}"").autocomplete({{
                                        source: function (request, response) {{
                                            $.getJSON(""{1}{2}/{3}"", {8},
                                                    function (result) {{
                                                        if(!result.length){{
                                                            var result = [
                                                                {{
                                                                label: '{10}', 
                                                                value: response.term
                                                                }}
                                                                ];
                                                                response(result);
                                                        }}
                                                         else
                                                         {{
                                                        response($.map(result, function (item) {{
                                                            return {{ label: item.{4}, value: item.{4}, id: item.{5} }};
                                                        }}));
                                                        }}
                                                    }});
                                        }},
                                        formartItem: function (item) {{
                                            return item.{4};
                                        }},
                                        delay: 2,
                                        minLength: 2,
                                        dataType: ""json"",
                                        select: function (event, ui) {{
                                            $('#{7}{6}').val(ui.item.id);
                                            $('#{7}{6}').change();
                                                          {9};
                                                
                                                            
                                        }}
                                    }});
                                    $(""#{7}{0}"").keyup(function (){{
                                        if($(this).val() == '')
                                            $('#{7}{6}').val('');
                                            $('#{7}{6}').change();
                                    }});
                                </script>", GetPropertyName(Expression), UriHelper.Instance.GetUrlAbsoluta(), Controller,
                Action,
                TextProperty, ValueProperty, IdField, prefix, GetParameters(),GetFunction(),MensajeSinResultados);
        }

        private string GetParameters()
        {
            if (string.IsNullOrEmpty(AditionalParametersFunction))
                return "{ texto: request.term }";

            return string.Format(@"(function() {{
										var parameter = eval('{0}');
										parameter['texto'] = request.term;
										return parameter;
									}})()", AditionalParametersFunction);
        }
        private string GetFunction()
        {
            if (string.IsNullOrEmpty(AditionalFunctionParameter))
                return "";

            return AditionalFunctionParameter;
            //return string.Format(@"(function() {{
				//						{0}
					//				}})()", AditionalParametersFunction);
        }
    }
}