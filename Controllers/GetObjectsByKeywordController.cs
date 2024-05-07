using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2fk.io.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetObjectsByKeywordController : ControllerBase
    {
       
        // GET <GetObjectsByKeywordController>/5
        [HttpGet("{keyword}")]
        public ActionResult Get(string keyword, int skip = 0, int qty = -1, bool mainnet = true)
        {

      
            Wrapper wrapper = new Wrapper();
            string result = "";
            string arguments = "";

            if (mainnet)
            {
                arguments = "--versionbyte " + wrapper.ProdVersionByte + " --getobjectsbykeyword --password " + wrapper.ProdRPCPassword + " --url " + wrapper.ProdRPCURL + " --username " + wrapper.ProdRPCUser + " --skip " + skip + " --qty " + qty + " --keyword " + keyword;
                result = wrapper.RunCommand(wrapper.ProdCLIPath, arguments);
            }
            else
            {
                arguments = "--versionbyte " + wrapper.TestVersionByte + " --getobjectsbykeyword --password " + wrapper.TestRPCPassword + " --url " + wrapper.TestRPCURL + " --username " + wrapper.TestRPCUser + " --skip " + skip + " --qty " + qty + " --keyword " + keyword;
                result = wrapper.RunCommand(wrapper.TestCLIPath, arguments);
            }

            return Content(result, "application/json");
        }

       
    }
}
