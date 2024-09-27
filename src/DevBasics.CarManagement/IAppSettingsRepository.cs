using System.Threading.Tasks;
using DevBasics.CarManagement.Dependencies;

namespace DevBasics.CarManagement;

public interface IAppSettingsRepository
{
    Task<AppSettingDto> GetAppSettingAsync(string salesOrgIdentifier, CarBrand requestOrigin);
}