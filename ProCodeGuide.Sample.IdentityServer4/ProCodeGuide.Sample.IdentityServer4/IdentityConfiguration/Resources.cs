using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Sample.IdentityServer4.IdentityConfiguration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };
        }

        //Les ressources d'API sont utilisées pour définir l'API que le serveur d'identité protège, c'est-à-dire que l'API est sécurisée à l'aide d'un serveur d'identité
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
            new ApiResource
            {
                Name = "weatherApie",
                DisplayName = "Weather Api",
                Description = "Allow the application to access Weather Api on your behalf",
                Scopes = new List<string> { "weatherApi.read", "weatherApi.write"},
                ApiSecrets = new List<Secret> {new Secret("ProCodeGuide".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };
        }
    }
}
