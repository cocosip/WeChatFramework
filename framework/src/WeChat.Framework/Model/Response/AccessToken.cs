using Newtonsoft.Json;

namespace WeChat.Framework.Model
{
    /// <summary>微信每个应用AccessToken实体
    /// </summary>
    public class AccessToken
    {
        /// <summary>微信公众号,App,小程序等获取到的应用的凭证Access_Token
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }

        /// <summary>凭证有效时间，单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
