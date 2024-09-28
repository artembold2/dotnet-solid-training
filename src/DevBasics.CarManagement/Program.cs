using AutoMapper;
using DevBasics.CarManagement.Dependencies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DevBasics.CarManagement;

internal sealed class Program
{
    internal static async Task Main()
    {
        var serviceCollection = new ServiceCollection();

        var model = new CarRegistrationModel();
        var configuration = new MapperConfiguration(cfg => model.CreateMappings(cfg));
        var mapper = configuration.CreateMapper();

        serviceCollection.AddSingleton(mapper);
        serviceCollection.AddSingleton<IBulkRegistrationService, BulkRegistrationServiceMock>();
        serviceCollection.AddSingleton<ILeasingRegistrationRepository, LeasingRegistrationRepository>();
        serviceCollection.AddSingleton<ICarRegistrationRepository, CarRegistrationRepository>();
        serviceCollection.AddSingleton<CarManagementSettings>();
        serviceCollection.AddSingleton<HttpHeaderSettings>();
        serviceCollection.AddSingleton<IKowoLeasingApiClient, KowoLeasingApiClientMock>();
        serviceCollection.AddSingleton<ITransactionStateService, TransactionStateServiceMock>();
        serviceCollection.AddSingleton<IRegistrationDetailService, RegistrationDetailServiceMock>();
        serviceCollection.AddSingleton<IAppSettingsRepository, AppSettingsRepository>();
        serviceCollection.AddSingleton<CarManagementService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var service = serviceProvider.GetService<CarManagementService>();
        
        var registerCarsModel = new RegisterCarsModel
        {
            CompanyId = "Company",
            CustomerId = "Customer",
            VendorId = "Vendor",
            Cars = new List<CarRegistrationModel>
            {
                new CarRegistrationModel
                {
                    CompanyId = "Company",
                    CustomerId = "Customer",
                    VehicleIdentificationNumber = Guid.NewGuid().ToString(),
                    DeliveryDate = DateTime.Now.AddDays(14).Date,
                    ErpDeliveryNumber = Guid.NewGuid().ToString()
                }
            }
        };
        var result = await service.RegisterCarsAsync(
            registerCarsModel,
            false,
            new Claims());
    }
}