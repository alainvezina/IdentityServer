using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer.InMemory
{
	internal class Resources
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource> {
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
			new IdentityResources.Email(),
			new IdentityResource {
				Name = "role",
				UserClaims = new List<string> {"role"}
			}
		};
		}

		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource> {
			new ApiResource {
				Name = "sampleWebAPI",
				DisplayName = "Sample Web API",
				Description = "Sample Web API Access",
				UserClaims = new List<string> {"role"},
				ApiSecrets = new List<Secret> {new Secret("mysecret123!".Sha256())},
				Scopes = new List<Scope> {
					new Scope("sampleWebAPI.read"),
					new Scope("sampleWebAPI.write")
				}
			}
		};
		}
	}
}
