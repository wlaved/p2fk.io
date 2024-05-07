using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2fk.io.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetObjectByURNController : ControllerBase
    {
       
        // GET <GetObjectByURNController>/5
        [HttpGet("{urn}")]
        public ActionResult Get(string urn, bool mainnet = true)
        {
            
                Wrapper wrapper = new Wrapper();

                string arguments = "";
                string result = "";

                if (mainnet)
                {
                    arguments = "--versionbyte " + wrapper.ProdVersionByte + " --getobjectbyurn --password " + wrapper.ProdRPCPassword + " --url " + wrapper.ProdRPCURL + " --username " + wrapper.ProdRPCUser + " --urn " + urn;
                    result = wrapper.RunCommand(wrapper.ProdCLIPath, arguments);
                }
                else { arguments = "--versionbyte " + wrapper.TestVersionByte + " --getobjectbyurn --password " + wrapper.TestRPCPassword + " --url " + wrapper.TestRPCURL + " --username " + wrapper.TestRPCUser + " --urn " + urn;
                    result = wrapper.RunCommand(wrapper.TestCLIPath, arguments);
                }


                return Content(result, "application/json");
            

        }


    }
}
