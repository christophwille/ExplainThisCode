using System;

namespace OpenAI.ApiClients
{
    public partial class OpenAIApiClient
    {
        public string ApiKey { get; set; }

        protected Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiKey);

            return Task.FromResult(requestMessage);
        }
    }
}
