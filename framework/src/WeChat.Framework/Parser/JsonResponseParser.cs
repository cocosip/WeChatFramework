using DotCommon.Serializing;
using Microsoft.Extensions.Logging;
using System;

namespace WeChat.Framework.Parser
{
    /// <summary>Json格式消息转化
    /// </summary>
    public class JsonResponseParser : IJsonResponseParser
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly ILogger _logger;

        /// <summary>Ctor
        /// </summary>
        public JsonResponseParser(ILoggerFactory loggerFactory, IJsonSerializer jsonSerializer)
        {
            _logger = loggerFactory.CreateLogger(WeChatSettings.LoggerName);
            _jsonSerializer = jsonSerializer;
        }


        /// <summary>转化Json格式消息
        /// </summary>
        public virtual T ParseResponse<T>(string json) where T : class
        {
            try
            {
                return _jsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("微信ParseResponse失败,返回数据为:{0},无法转化为类型:{1},Ex:{2}", json, typeof(T), ex.Message);
                throw;
            }
        }
    }
}
