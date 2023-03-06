using AutoMapper;
using LexiconLMS.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LexiconLMS.Server.Controllers
{
    public class OidcConfigurationController : Controller
    {
        private readonly ILogger<OidcConfigurationController> _logger;

        //private readonly IMapper _mapper;
        //private readonly UserManager<ApplicationUser> _applicationUserManager;

        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> logger
            /*IMapper mapper, *//*UserManager<ApplicationUser> applicationUserManager*/)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            _logger = logger;
            //_mapper = mapper;
            //_applicationUserManager = applicationUserManager;
        }

        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(parameters);
        }
    }
}