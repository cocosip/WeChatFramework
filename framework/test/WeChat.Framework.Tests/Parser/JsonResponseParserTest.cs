using DotCommon.Serializing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using WeChat.Framework.Model;
using WeChat.Framework.Parser;
using Xunit;

namespace WeChat.Framework.Tests.Parser
{
    public class JsonResponseParserTest : TestBase
    {
        [Fact]
        public void JsonSerializerType_Test()
        {
            var jsonSerializer = Provider.GetService<IJsonSerializer>();
            var newtonsoftJsonSerializerType = typeof(DotCommon.Json4Net.NewtonsoftJsonSerializer);
            Assert.Equal(newtonsoftJsonSerializerType, jsonSerializer.GetType());
        }

        [Fact]
        public void ParseResponse_Test()
        {
            var jsonResponseParser = Provider.GetService<IJsonResponseParser>();
            var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"ticket\":\"-p3A5zVP95IuafPhzA6lRR95_F9nZEBfJ_n4E9t8ZFWKJTDPOwccVQhHCwDBmvLkayF_jh-m9HOExhumOziDWA\", \"expires_in\":7200}";
            var sdkTicket = jsonResponseParser.ParseResponse<SdkTicket>(json);

            Assert.Equal("-p3A5zVP95IuafPhzA6lRR95_F9nZEBfJ_n4E9t8ZFWKJTDPOwccVQhHCwDBmvLkayF_jh-m9HOExhumOziDWA", sdkTicket.Ticket);

            Assert.Equal(0, sdkTicket.ErrCode);
            Assert.Equal("ok", sdkTicket.ErrMsg);
            Assert.Equal(7200, sdkTicket.ExpiresIn);
            Assert.Null(sdkTicket.Type);


            Assert.Throws<JsonReaderException>(() =>
            {
                jsonResponseParser.ParseResponse<SdkTicket>("xxxxxx");
            });
        }
    }
}
