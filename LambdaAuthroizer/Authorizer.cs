using Amazon.Lambda.APIGatewayEvents;
using System.IdentityModel.Tokens.Jwt;

namespace LambdaAuthroizer;

public class Authorizer
{
    public async Task<APIGatewayCustomAuthorizerResponse> Auth(APIGatewayCustomAuthorizerRequest request)
    {
        var response = new APIGatewayCustomAuthorizerResponse();
        var idToken = request.AuthorizationToken;
        var idTokenDetails = new JwtSecurityToken(jwtEncodedString: idToken);

        var kid = idTokenDetails.Header["kid"].ToString();
        var issuer = idTokenDetails.Claims.First(x => x.Type == "iss").Value;
        var audience = idTokenDetails.Claims.First(x => x.Type == "aud").Value;


        return response;
    }
}
