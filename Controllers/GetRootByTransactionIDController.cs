using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


namespace p2fk.io.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetRootByTransactionIDController : ControllerBase
    {

        // GET <GetRootByTransactionIDController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            // Regular expression for cryptocurrency transaction ID validation
            string pattern = @"^[0-9a-fA-F]{64}$";
            
            if (Regex.IsMatch(id, pattern))
            {
                Wrapper wrapper = new Wrapper();

                string arguments = "--versionbyte " + wrapper.VersionByte + " --getrootbytransactionid --password " + wrapper.RPCPassword + " --url " + wrapper.RPCURL + " --username " + wrapper.RPCUser + " --tid " + id;

                string result = "";
                result = wrapper.RunCommand(wrapper.CLIPath, arguments);

                return Content(result, "application/json");
            }
            else { return Content("[\"invalid transaction id format\"]", "application/json"); }
        }





    }
}
