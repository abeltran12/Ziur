namespace ZiurSoftware.Client;

public class AuthTokenHandler : DelegatingHandler
{
    private const string Token = "ae8bad44-7348-11ee-b962-0242ac120002";

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

        return base.SendAsync(request, cancellationToken);
    }
}