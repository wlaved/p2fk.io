using System.Diagnostics;
using System.Reflection;
using System.Text;
using static System.Net.WebRequestMethods;

namespace p2fk.io
{
    public class Wrapper
    {
        public string CLIPath = @"C:\SUP\SUP.exe"; // Replace with the actual path to SUP.EXE
        public string VersionByte = @"111"; // Replace with the actual version byte
        public string RPCURL = @"http://127.0.0.1:18332";
        public string RPCUser = "good-user";
        public string RPCPassword = "better-password";

        public string RunCommand(string executablePath, string arguments)
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
