using BusinessLogicInterfaces.Security;
using Entities.Commons;
using EntitiesInterfaces.Commons;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace BusinessLogic.Security
{
 
    /// Implements a Basic Authentication handler.
    /// This class authenticates users by validating credentials provided in the HTTP Authorization header,
    /// encoded in Base64 format.

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        #region Global Data 

        /// Here you can find instances or global variables.
       
        private IOpenAIAuthBL authorizationBL= new OpenAIAuthBL();
        private IUserDTO userDTO = new UserDTO();
        #endregion

        #region Constructor 

        /// Initializes the Basic Authentication handler.
        /// Configures the handler with specific options, logging mechanisms, and other required dependencies.

        /// <param name="options">Monitors options for the authentication scheme.</param>
        /// <param name="logger">Factory for logging events and messages.</param>
        /// <param name="encoder">Encoder used for handling URL encoding.</param>
        /// <param name="clock">System clock used to retrieve the current time.</param>
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        #endregion

        #region HandleAuthenticateAsync Method

        /// Handles the authentication process.
        /// Verifies the presence of the Authorization header and validates the credentials provided in it.
        /// If successful, returns an authentication result with the user's claims.

        /// <returns>An authentication result, either successful or failed.</returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Check if the "Authorization" header exists
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header not found.");
            }

            try
            {
                // Decode the "Authorization" header and extract the credentials (username and password)
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                var username = credentials[0];
                var password = credentials[1];


                // Validate credentials (example with hardcoded values)      
                userDTO.UserName = username;
                userDTO.Password = password;
                //if (authorizationBL.Get(userDTO))
                //{
                //    return AuthenticateResult.Fail("Invalid username or password.");
                //}

                // Create the claims and identity for the authenticated user
                var claims = new[] {
                    new Claim(ClaimTypes.Name, username)
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization header.");
            }
        }
        #endregion
    }
}
