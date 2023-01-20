using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShoeStore.Application.Interfaces.Servises
{
	public interface IJwtTokenGenerator
	{
		public JwtSecurityToken GenerateJwtToken(List<Claim> claims);
	}
}