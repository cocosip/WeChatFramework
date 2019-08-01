namespace WeChat.Framework
{
    /// <summary>微信设置
    /// </summary>
    public static class WeChatSettings
    {
        /// <summary>日志名称
        /// </summary>
        public const string LoggerName = "WeChatFrameworkLogger";

        /// <summary>微信SdkTicket类型
        /// </summary>
        public static class SdkTicketType
        {
            /// <summary>微信App扫码登录
            /// </summary>
            public const string AppScanLogin = "2";

            /// <summary>Js-sdk配置文件权限
            /// </summary>
            public const string JsApi = "jsapi";
        }

        /// <summary>微信Url地址
        /// </summary>
        public static class WeChatUrls
        {
            /// <summary>基础Url地址
            /// </summary>
            public const string BaseUrl = "https://api.weixin.qq.com";

            /// <summary>获取AccessToken的地址片段
            /// </summary>
            public const string AccessTokenResource = "/cgi-bin/token";

            /// <summary>获取SdkTicketUrl地址片段
            /// </summary>
            public const string SdkTicketResource = "/cgi-bin/ticket/getticket";
        }
    }
}
