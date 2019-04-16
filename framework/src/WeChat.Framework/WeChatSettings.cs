namespace WeChat.Framework
{
    /// <summary>微信设置
    /// </summary>
    public static class WeChatSettings
    {

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
            /// <summary>获取AccessTokenUrl地址
            /// </summary>
            public const string AccessTokenUrl = "https://api.weixin.qq.com/cgi-bin/token";

            /// <summary>获取SdkTicketUrl地址
            /// </summary>
            public const string SdkTicketUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
        }
    }
}
