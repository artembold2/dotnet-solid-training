using System.Threading.Tasks;

namespace DevBasics.CarManagement.Dependencies;

internal sealed class AppSettingsRepository : IAppSettingsRepository
{
    public Task<AppSettingDto> GetAppSettingAsync(string salesOrgIdentifier, CarBrand requestOrigin)
    {
        return Task.FromResult(new AppSettingDto
        {
            SoldTo = "SoldTo01"
        });
    }
}