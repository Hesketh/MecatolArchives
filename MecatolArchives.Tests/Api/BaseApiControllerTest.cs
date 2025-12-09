using Aspire.Hosting;

namespace MecatolArchives.Tests.Api;

public class BaseApiControllerTest : IAsyncLifetime
{
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(2);

    public DistributedApplication App { get; private set; } = null!;
    public ApiService.Client.MecatolArchivesApiClient ApiClient { get; private set; } = null!;
    public CancellationToken CancellationToken { get; private set; } = new CancellationTokenSource(DefaultTimeout).Token;

    public async Task InitializeAsync()
    {
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.MecatolArchives_AppHost>(["testing"], CancellationToken);

        App = await appHost.BuildAsync(CancellationToken).WaitAsync(DefaultTimeout, CancellationToken);
        await App.StartAsync(CancellationToken).WaitAsync(DefaultTimeout, CancellationToken);

        var httpClient = App.CreateHttpClient("apiservice");
        await App.ResourceNotifications.WaitForResourceHealthyAsync("apiservice", CancellationToken).WaitAsync(DefaultTimeout, CancellationToken);

        ApiClient = new ApiService.Client.MecatolArchivesApiClient(httpClient);
    }

    public async Task DisposeAsync()
    {
        await App.DisposeAsync();
    }
}
