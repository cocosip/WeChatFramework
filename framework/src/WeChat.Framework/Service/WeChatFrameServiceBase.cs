using DotCommon.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using WeChat.Framework.Parser;

namespace WeChat.Framework.Service
{
    /// <summary>抽象Service基类
    /// </summary>
    public abstract class WeChatFrameServiceBase
    {
        /// <summary>Provider
        /// </summary>
        protected IServiceProvider Provider { get; }

        /// <summary>Logger
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>Json格式消息转化
        /// </summary>
        protected IJsonResponseParser JsonResponseParser { get; }

        /// <summary>Http请求客户端
        /// </summary>
        protected IRestClient Client { get; }

        /// <summary>Ctor
        /// </summary>
        protected WeChatFrameServiceBase(IServiceProvider provider, ILoggerFactory loggerFactory)
        {
            Provider = provider;
            Logger = loggerFactory.CreateLogger(WeChatSettings.LoggerName);

            //其他
            JsonResponseParser = Provider.GetService<IJsonResponseParser>();
            Client = new RestClient(WeChatSettings.WeChatUrls.BaseUrl);
        }

        /// <summary>格式化日志
        /// </summary>
        protected string ParseLog(string appId, string methodName, string content)
        {
            return string.Format("微信AppId:{0},调用方法:{1}。{2}", appId, methodName, content);
        }

    }
}
