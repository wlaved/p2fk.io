using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2fk.io.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetPublicAddressByKeywordController : ControllerBase
    {

        // GET <GetPublicAddressByKeywordController>/5
        [HttpGet("{keyword}")]
        public ActionResult Get(string keyword, bool mainnet = true)
        {
           
                Wrapper wrapper = new Wrapper();

                string arguments = "";
                string result = "";

                if (mainnet)
                {
                    arguments = "--versionbyte " + wrapper.ProdVersionByte + " --getpublicaddressbykeyword --keyword " + keyword;
                    result = wrapper.RunCommand(wrapper.ProdCLIPath, arguments);
                }
                else { arguments = "--versionbyte " + wrapper.TestVersionByte + " --getpublicaddressbykeyword --keyword " + keyword;
                    result = wrapper.RunCommand(wrapper.TestCLIPath, arguments);
                }


                return Content(result, "application/json");
            

        }


    }
}
