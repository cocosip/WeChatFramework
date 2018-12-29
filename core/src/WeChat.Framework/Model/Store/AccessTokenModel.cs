using System;

namespace WeChat.Framework.Model
{
    /// <summary>微信应用AccessToken 存储Model实体
    /// </summary>
    public class AccessTokenModel
    {
        /// <summary>AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>过期时间
        /// </summary>
        public int ExpiredIn { get; set; }

        /// <summary>最后修改时间
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>在某个时间下,是否过期
        /// </summary>
        public bool IsExpired(DateTime expiredTime)
        {
            var totalSeconds = (expiredTime - LastModifiedTime).TotalSeconds;
            if (totalSeconds > ExpiredIn)
            {
                return true;
            }
            return false;
        }

        /// <summary>Override ToString
        /// </summary>
        public override string ToString()
        {
            return $"[AppId:{AppId},Token:{Token},ExpiredIn:{ExpiredIn},LastModifiedTime:{LastModifiedTime.ToString("yyyy-MM-dd HH:mm:ss")}]";
        }
    }
}
