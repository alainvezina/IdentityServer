using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IdentityServer.InMemory
{
	internal class Clients
	{
		public static IEnumerable<Client> Get()
		{
			return new List<Client> {
			new Client {
				ClientId = "sampleWebAPI",
				ClientName = "Sample Web API",
				AccessTokenLifetime = 3601,
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				Claims = new Claim[]{
					new Claim("role", "Administrators")
				},
				ClientSecrets = new List<Secret> {
					new Secret("mysecret123!1".Sha256())},
				AllowedScopes = new List<string> { "sampleWebAPI.read" }
			}
			};
		}
	}
}
