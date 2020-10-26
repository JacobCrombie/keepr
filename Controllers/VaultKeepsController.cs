using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vaultKeepServ;

    public VaultKeepsController(VaultKeepsService vaultKeepServ)
    {
      _vaultKeepServ = vaultKeepServ;
    }

  }
}