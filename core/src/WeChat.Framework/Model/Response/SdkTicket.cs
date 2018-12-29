using Newtonsoft.Json;

namespace WeChat.Framework.Model
{

    /// <summary>微信每个应用Sdk-Ticket
    /// </summary>
    public class SdkTicket
    {
        /// <summary>错误代码
        /// </summary>
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        /// <summary>错误信息
        /// </summary>
        [JsonProperty("errmsg")]
        public int ErrMsg { get; set; }

        /// <summary>临时票据 ticket
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        /// <summary>临时票据有效时间，单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>类型
        /// </summary>
        public string Type { get; set; }

    }
}
