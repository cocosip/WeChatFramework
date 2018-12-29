namespace WeChat.Framework.Parser
{
    /// <summary>Json格式的消息转化
    /// </summary>
    public interface IJsonResponseParser
    {
        /// <summary>转化Json格式消息
        /// </summary>
        T ParseResponse<T>(string json)where T : class;
    }
}
