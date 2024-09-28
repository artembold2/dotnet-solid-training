namespace DevBasics.CarManagement.RegistrationNumberGenerators;

public interface ICarRegistrationNumberGenerator
{
    RegistrationInfo Generated(string endCustomerRegistrationReference, string registrationRegistrationId);
}