using DevBasics.CarManagement.Dependencies;
using System.Threading.Tasks;

namespace DevBasics.CarManagement;

public abstract class BaseService
{
    public CarManagementSettings Settings { get; set; }

    public HttpHeaderSettings HttpHeader { get; set; }

    public IKowoLeasingApiClient ApiClient { get; set; }

    protected BaseService(
        CarManagementSettings settings,
        HttpHeaderSettings httpHeader,
        IKowoLeasingApiClient apiClient)
    {
        Settings = settings;
        HttpHeader = httpHeader;
        ApiClient = apiClient;
    }

    public abstract Task<RequestContext> InitializeRequestContextAsync();
}