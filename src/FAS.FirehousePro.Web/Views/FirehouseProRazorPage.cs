using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace FAS.FirehousePro.Web.Views
{
    public abstract class FirehouseProRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected FirehouseProRazorPage()
        {
            LocalizationSourceName = FirehouseProConsts.LocalizationSourceName;
        }
    }
}
