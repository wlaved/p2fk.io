using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p2fk.io.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetRootByTransactionIDController : ControllerBase
    {

        // GET api/<GetRootByTransactionIDController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {

            string cliPath = "C:\\SUP\\SUP.exe"; // Replace with the actual path to SUP.EXE
            string arguments = "--versionbyte 111 --getrootbytransactionid --password better-password --url http://127.0.0.1:18332 --username good-user --tid "+ id ;

            string result = ""; 
            result = RunCLICommand(cliPath, arguments);


            return result;
        }



        private string RunCLICommand(string executablePath, string arguments)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = executablePath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                StandardOutputEncoding = Encoding.UTF8, // Set the standard output encoding to UTF-8
                StandardErrorEncoding = Encoding.UTF8   // Set the standard error encoding to UTF-8

            };

            using (Process process = new Process { StartInfo = processStartInfo })
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    return $"Error: {error}";
                }

                return output;
            }
        }

    }
}
