using DotCommon.Serializing;

namespace WeChat.Framework.Parser
{
    /// <summary>Json格式消息转化
    /// </summary>
    public class JsonResponseParser : IJsonResponseParser
    {
        private readonly IJsonSerializer _jsonSerializer;

        /// <summary>Ctor
        /// </summary>
        public JsonResponseParser(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }


        /// <summary>转化Json格式消息
        /// </summary>
        public virtual T ParseResponse<T>(string json)where T : class
        {
            return _jsonSerializer.Deserialize<T>(json);
        }
    }
}
