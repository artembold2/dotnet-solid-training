using System;

namespace DevBasics.CarManagement;

public class ToyotaRegistrationNumberGenerator : ICarRegistrationNumberGenerator
{
    public RegistrationInfo Generated(string endCustomerRegistrationReference, string registrationRegistrationId)
    {
        if (string.IsNullOrWhiteSpace(endCustomerRegistrationReference))
        {
            return new RegistrationInfo(endCustomerRegistrationReference, registrationRegistrationId);
        }

        const int maxLength = 32;

        string endCustomerRegistrationReferenceShort = endCustomerRegistrationReference.Length > 23
            ? endCustomerRegistrationReference.Substring(0, 23)
            : endCustomerRegistrationReference;

        Guid uniqueValue = Guid.NewGuid();
        string uniqueValueBase64 = Convert.ToBase64String(uniqueValue.ToByteArray());

        // Remove unnecessary characters from base64 string.
        uniqueValueBase64 = uniqueValueBase64.Replace("=", string.Empty);
        uniqueValueBase64 = uniqueValueBase64.Replace("+", string.Empty);
        uniqueValueBase64 = uniqueValueBase64.Replace("/", string.Empty);
        string uniqueValueBase64Short = uniqueValueBase64.Substring(0, 8);

        string depRegistrationNumber = $"{endCustomerRegistrationReferenceShort}-{uniqueValueBase64Short}";

        return new RegistrationInfo(endCustomerRegistrationReference, depRegistrationNumber.Length > maxLength ? depRegistrationNumber.Substring(0, maxLength) : depRegistrationNumber);
    }
}