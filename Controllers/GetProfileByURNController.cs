using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2fk.io.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetProfileByURNController : ControllerBase
    {
       
        // GET <GetProfileByURNController>/5
        [HttpGet("{urn}")]
        public ActionResult Get(string urn, bool mainnet = true)
        {
            // Regular expression for cryptocurrency address validation
           
                Wrapper wrapper = new Wrapper();

                string arguments = "";
                string result = "";

                if (mainnet)
                {
                    arguments = "--versionbyte " + wrapper.ProdVersionByte + " --getprofilebyurn --password " + wrapper.ProdRPCPassword + " --url " + wrapper.ProdRPCURL + " --username " + wrapper.ProdRPCUser + " --urn " + urn;
                    result = wrapper.RunCommand(wrapper.ProdCLIPath, arguments);
                }
                else { arguments = "--versionbyte " + wrapper.TestVersionByte + " --getprofilebyurn --password " + wrapper.TestRPCPassword + " --url " + wrapper.TestRPCURL + " --username " + wrapper.TestRPCUser + " --urn " + urn;
                    result = wrapper.RunCommand(wrapper.TestCLIPath, arguments);
                }

                return Content(result, "application/json");
           

        }


    }
}
