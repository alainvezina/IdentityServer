using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
	internal class IdentityServerConfigurations
	{
		/// <summary>
		///  
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<Client> GetClients()
		{
			return new List<Client> {
			new Client {
				ClientId = "sampleWebAPI",
				ClientName = "Sample Web API",
				AccessTokenLifetime = 3601,
				AllowOfflineAccess = true,
				RefreshTokenUsage = TokenUsage.OneTimeOnly,
				AbsoluteRefreshTokenLifetime = 36011,
				UpdateAccessTokenClaimsOnRefresh = true,
				AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
				Claims = new Claim[]{
					new Claim("role", "Administrators")
				},
				ClientSecrets = new List<Secret> {
					new Secret("mysecret123!1".Sha256())},
				AllowedScopes = new List<string> { "sampleWebAPI.read" }
			}
			};
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
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
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
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

		public static List<TestUser> GetUsers()
		{
			return new List<TestUser> {
			new TestUser {

				SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
				Username = "jim",
				Password = "mysecret123!",
				Claims = new List<Claim> {
					new Claim(IdentityModel.JwtClaimTypes.Email, "scott@scottbrady91.com"),
					new Claim(IdentityModel.JwtClaimTypes.Role, "admin")
				}
			}
		};
		}



	}
}
