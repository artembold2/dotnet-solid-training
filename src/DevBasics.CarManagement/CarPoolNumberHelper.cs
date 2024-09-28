using DevBasics.CarManagement.Dependencies;
using System;
using System.Collections.Generic;
using DevBasics.CarManagement.RegistrationNumberGenerators;

namespace DevBasics.CarManagement;

public static class CarPoolNumberHelper
{
    private static readonly Dictionary<CarBrand, ICarRegistrationNumberGenerator> Strategy = new()
    {
        {CarBrand.Ford, new FordRegistrationNumberGenerator()},
        {CarBrand.Toyota, new ToyotaRegistrationNumberGenerator()}
    };

    public static void Generate(CarBrand requestOrigin, string endCustomerRegistrationReference, out string registrationRegistrationId, out string registrationNumber)
    {
        registrationRegistrationId = GenerateRegistrationRegistrationId();
        registrationNumber = string.Empty;

        if (Strategy.TryGetValue(requestOrigin, out var generator))
        {
            var info = generator.Generated(endCustomerRegistrationReference, registrationRegistrationId);
            registrationNumber = info.RegistrationNumber;
            registrationRegistrationId = info.RegistrationRegistrationId;
        }
        else
            throw new ArgumentOutOfRangeException(nameof(requestOrigin), requestOrigin, null);
    }

    public static string GenerateRegistrationRegistrationId()
    {
        return DateTime.Now.Ticks.ToString();
    }
}