using FitnessAppDemo.Auth.Models;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace FitnessAppDemo.Auth
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources() =>
            new ApiResource[]
            {
                new ApiResource("fitnessApp", "Fitness App")
            };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope> { new ApiScope("companyApi", "CompanyEmployee API") };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "fitnessApp",
                    ClientSecrets = new [] { new Secret("fitSecret".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, "companyApi" }
                 }
            };

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(),
                    Username = "user",
                    Password = "user".Sha256()
                }
            };
        }
    }
}
