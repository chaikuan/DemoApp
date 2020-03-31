using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string secret = "abcd";//秘钥不要泄露


            var token = Encode(secret);
            Console.WriteLine(token);
            Console.WriteLine("----------------------------------");
            var json = Decode(secret,token);
            Console.WriteLine(json);
        }
        /// <summary>
        /// Jwt 加密
        /// </summary>
        /// <returns></returns>
        public static string Encode(string secret)
        { 
            var payload = new Dictionary<string, object>
            {
                { "UserId",123},
                {"UserName","admin" }
            };

            // 加一个过期时间
            payload.Add("timeOut", DateTime.Now.AddDays(1));

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, secret); 

            // token的值： eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VySWQiOjEyMywiVXNlck5hbWUiOiJhZG1pbiJ9.DErsX4o_WfxEw80gHSgjcfDAVCfV5WulmDb34QHpo70
            // token中有两个点将token分割为三部分，第一部分对应header,第二部分对应的是明文，第三部分是校验部分
          
            return token;
        }

        /// <summary>
        /// Jwt 解密
        /// </summary>
        /// <returns></returns>
        public static  Dictionary<string, object> Decode(string secret,string token)
        { 
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                var json = decoder.Decode(token, secret, verify: true);
                var payload = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                // 去除超时时间
                if ((DateTime)payload["timeOut"] < DateTime.Now)
                    throw new Exception("登录超时，请重新登录");
                payload.Remove("timeOut");

                return payload;
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                throw;
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("签名验证失败，数据可能被篡改");
                throw;
            }
        }
    }
}
