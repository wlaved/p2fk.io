using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2fk.io.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetObjectByAddressController : ControllerBase
    {
       
        // GET <GetObjectByAddressController>/5
        [HttpGet("{address}")]
        public ActionResult Get(string address)
        {
            // Regular expression for cryptocurrency address validation
            string pattern = @"^[a-zA-Z0-9][a-km-zA-HJ-NP-Z1-9]{25,34}$";
            if (Regex.IsMatch(address, pattern))
            {
                Wrapper wrapper = new Wrapper();

                string cliPath = "C:\\SUP\\SUP.exe"; // Replace with the actual path to SUP.EXE
                string arguments = "--versionbyte " + wrapper.VersionByte + " --getobjectbyaddress --password " + wrapper.RPCPassword + " --url " + wrapper.RPCURL + " --username " + wrapper.RPCUser + " --address " + address;

                string result = "";
                
                result = wrapper.RunCommand(cliPath, arguments);

                return Content(result, "application/json");
            }
            else { return Content("[\"invalid address format\"]", "application/json"); }

        }


    }
}
