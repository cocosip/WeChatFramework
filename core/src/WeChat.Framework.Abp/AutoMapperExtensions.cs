using AutoMapper;
using DotCommon.AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using WeChat.Framework.Model;

namespace WeChat.Framework
{
    /// <summary>Abp扩展存储时,AutoMapper映射
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>创建快捷支付Abp扩展自动映射
        /// </summary>
        public static void CreateWeChatFrameworkMaps(this IMapperConfigurationExpression configuration)
        {
            var assemblies = new List<Assembly>()
            {
                typeof(AbpAccessToken).Assembly
            };
            AutoAttributeMapperHelper.CreateAutoAttributeMappings(assemblies, configuration);
        }
    }
}
