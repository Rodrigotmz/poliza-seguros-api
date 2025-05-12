using Entities.Models;
using Entities.DTOs;
using Entities.Services;

namespace Helpers
{
    public static class PolicyFactory
    {
        public static Client CreateNewClient(CreatePolicyDTO clientRequest)
        {
            return new Client
            {
                Id = clientRequest.Client.Id,
                FirstName = clientRequest.Client.FirstName,
                LastNamePaternal = clientRequest.Client.LastNamePaternal,
                LastNameMaternal = clientRequest.Client.LastNameMaternal,
                Age = clientRequest.Client.Age,
                Gender = clientRequest.Client.Gender,
                PhoneNumber = clientRequest.Client.PhoneNumber,
                CountryId = clientRequest.Client.CountryId,
                UsersId = clientRequest.Client.UsersId
            };
        }
        public static Policy CreateNewPolicy(CreatePolicyDTO clientRequest, Client client)
        {
            string policyNumber = GetPolicyIds.GetPolicyId();
            return new Policy
            {
                PolicyNumber = policyNumber,
                PolicyTypeId = clientRequest.PolicyTypeId,
                StartDate = clientRequest.StartDate,
                EndDate = clientRequest.EndDate,
                PremiumAmount = clientRequest.PremiumAmount,
                Status = clientRequest.Status,
                Client = client
            };

        }
    }
}
