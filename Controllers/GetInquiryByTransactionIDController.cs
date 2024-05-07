using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2fk.io.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetInquiryByTransactionIDController : ControllerBase
    {

        // GET <GetInquiryByTransactionIDController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id, bool mainnet = true, bool verbose = false)
        {
            // Regular expression for cryptocurrency address validation
            string pattern = @"^[0-9a-fA-F]{64}$";
            if (Regex.IsMatch(id, pattern))
            {
                Wrapper wrapper = new Wrapper();

                string arguments = "";
                string result = "";

                if (mainnet)
                {
                    arguments = "--versionbyte " + wrapper.ProdVersionByte + " --getinquirybytransactionid --password " + wrapper.ProdRPCPassword + " --url " + wrapper.ProdRPCURL + " --username " + wrapper.ProdRPCUser + " --tid " + id;
                    if (verbose) { arguments = arguments + " --verbose"; }
                    result = wrapper.RunCommand(wrapper.ProdCLIPath, arguments);
                }
                else { arguments = "--versionbyte " + wrapper.TestVersionByte + " --getinquirybytransactionid --password " + wrapper.TestRPCPassword + " --url " + wrapper.TestRPCURL + " --username " + wrapper.TestRPCUser + " --tid " + id;
                    if (verbose) { arguments = arguments + " --verbose"; }
                    result = wrapper.RunCommand(wrapper.TestCLIPath, arguments);
                }
              

                return Content(result, "application/json");
            }
            else { return Content("[\"invalid transaction id format\"]", "application/json"); }

        }


    }
}
