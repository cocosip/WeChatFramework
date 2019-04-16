using Abp.Domain.Entities.Auditing;
using DotCommon.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Framework.Model
{

    /// <summary>AbpAccessToken
    /// </summary>
    [AutoMap(typeof(AccessTokenModel))]
    [Table("AbpAccessTokens")]
    public class AbpAccessToken : CreationAuditedEntity
    {
        /// <summary>AppId
        /// </summary>
        [Required]
        [StringLength(50)]
        public string AppId { get; set; }

        /// <summary>Token
        /// </summary>
        [Required]
        [StringLength(1024)]
        public string Token { get; set; }

        /// <summary>过期时间
        /// </summary>
        [Required]
        public int ExpiredIn { get; set; }

        /// <summary>最后修改时间
        /// </summary>
        [Required]
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
    }
}
