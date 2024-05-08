using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2FK.IO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetInquiriesByAddressController : ControllerBase
    {
       
        // GET <GetInquiriesByAddressController>/5
        [HttpGet("{address}")]
        public ActionResult Get(string address, int skip = 0, int qty = 10, bool mainnet = true, bool verbose = false)
        {

      
                // Regular expression for cryptocurrency address validation
            string pattern = @"^[a-zA-Z0-9][a-km-zA-HJ-NP-Z1-9]{25,34}$";
            if (Regex.IsMatch(address, pattern))
            {
                Wrapper wrapper = new Wrapper();
                string result = "";
                string arguments = "";

                if (mainnet)
                {
                    arguments = "--versionbyte " + wrapper.ProdVersionByte + " --getinquiriesbyaddress --password " + wrapper.ProdRPCPassword + " --url " + wrapper.ProdRPCURL + " --username " + wrapper.ProdRPCUser + " --skip " + skip + " --qty " + qty + " --address " + address;
                    if (verbose) { arguments = arguments + " --verbose"; }
                    result = wrapper.RunCommand(wrapper.ProdCLIPath, arguments);
                }
                else
                {
                    arguments = "--versionbyte " + wrapper.TestVersionByte + " --getinquiriesbyaddress --password " + wrapper.TestRPCPassword + " --url " + wrapper.TestRPCURL + " --username " + wrapper.TestRPCUser + " --skip " + skip + " --qty " + qty + " --address " + address;
                    if (verbose) { arguments = arguments + " --verbose"; }
                    result = wrapper.RunCommand(wrapper.TestCLIPath, arguments);
                }

                return Content(result, "application/json");
            }
            else { return Content("[\"invalid address format\"]", "application/json"); }
        }

       
    }
}
