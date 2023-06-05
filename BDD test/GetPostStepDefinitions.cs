using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace BDD_test
{
    [Binding]
    public class GetPostStepDefinitions
    {

        RestClient client = new RestClient("https://jsonplaceholder.typicode.com/posts");
        RestRequest request = new RestRequest("{postid}", Method.Get);
        RestResponse response;

        [Given(@"An endpoint with id value (.*)")]
        public void GivenAnEndpointWithIdValue(int p0)
        {
            request.AddUrlSegment("postid", p0);
        }

        [When(@"A GET request is sent")]
        public void WhenAGETRequestIsSent()
        {
            response = client.Get(request);
        }

        [Then(@"A valid response code is expected")]
        public void ThenAValidResponseCodeIsExpected()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
