using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;


namespace P2FK.IO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetRootByTransactionIDController : ControllerBase
    {

        // GET <GetRootByTransactionIDController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id, bool mainnet = true, bool verbose = false)
        {
            // Regular expression for cryptocurrency transaction ID validation
            string pattern = @"^[0-9a-fA-F]{64}$";
            
            if (Regex.IsMatch(id, pattern))
            {
                Wrapper wrapper = new Wrapper();

                string result = "";
                string arguments = "";

                if (mainnet)
                {
                    arguments = "--versionbyte " + wrapper.ProdVersionByte + " --getrootbytransactionid --password " + wrapper.ProdRPCPassword + " --url " + wrapper.ProdRPCURL + " --username " + wrapper.ProdRPCUser +" --tid " + id;
                    if (verbose) { arguments = arguments + " --verbose"; }
                    result = wrapper.RunCommand(wrapper.ProdCLIPath, arguments);
                }
                else
                {
                    arguments = "--versionbyte " + wrapper.TestVersionByte + " --getrootbytransactionid --password " + wrapper.TestRPCPassword + " --url " + wrapper.TestRPCURL + " --username " + wrapper.TestRPCUser + " --tid " + id;
                    if (verbose) { arguments = arguments + " --verbose"; }
                    result = wrapper.RunCommand(wrapper.TestCLIPath, arguments);
                }

                return Content(result, "application/json");
            }
            else { return Content("[\"invalid transaction id format\"]", "application/json"); }
        }





    }
}
