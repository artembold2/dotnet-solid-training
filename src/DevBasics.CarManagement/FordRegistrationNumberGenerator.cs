﻿namespace DevBasics.CarManagement;

public class FordRegistrationNumberGenerator : ICarRegistrationNumberGenerator
{
    public RegistrationInfo Generated(string endCustomerRegistrationReference, string registrationRegistrationId)
    {
        return new RegistrationInfo(endCustomerRegistrationReference,
            string.IsNullOrWhiteSpace(endCustomerRegistrationReference)
                ? registrationRegistrationId
                : endCustomerRegistrationReference);
    }
}