using CrossCutting.Authentication;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace Tests.CloseFriends
{
    public class CloseFriendsTests
    {
        const string urlAPI = "http://localhost:22761/api/";

        [Fact]
        public void APIAuthentication_Fail()
        {
            bool authentication = false;
            string userId = "user1";
            string accessKey = "53nh@123898*";

            authentication = Authentication(authentication, userId, accessKey);

            Assert.False(authentication);
        }

        [Fact]
        public void APIAuthentication_Sucess()
        {
            bool authentication = false;
            string userId = "user1";
            string accessKey = "53nh@123*";

            authentication = Authentication(authentication, userId, accessKey);

            Assert.True(authentication);
        }

        private static bool Authentication(bool authentication, string userId, string accessKey)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respToken = client.PostAsync(
                    urlAPI + "authentication", new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            UserID = userId,
                            AccessKey = accessKey
                        }), System.Text.Encoding.UTF8, "application/json")).Result;

                string content = respToken.Content.ReadAsStringAsync().Result;

                if (respToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Token token = JsonConvert.DeserializeObject<Token>(content);
                    authentication = token.Authenticated;
                }
            }

            return authentication;
        }
    }
}
