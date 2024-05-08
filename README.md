# p2fk.io
p2fk.io is a simple .NET API wrapper allowing developers to interact with the Sup!? CLI via the traditional web.



# How to Sync Sup!?
The latest release of Sup!? with CLI can be found here: https://github.com/embiimob/SUP

1. 1. create a folder C:\SUP and unzip the latest release into it.
2. run SUP.EXE,  click the 🗝️ icon, launch and sync both bitcoin wallets.


NOTICE: You must update the Wrapper.cs file if you wish to use something other then the following default values 

# defaults:

        //default mainnet connection info
        public string ProdCLIPath = @"C:\SUP\SUP.exe"; // Replace with the actual path to SUP.EXE
        public string ProdVersionByte = @"0"; // Replace with the actual version byte
        public string ProdRPCURL = @"http://127.0.0.1:8332";
        public string ProdRPCUser = "good-user";
        public string ProdRPCPassword = "better-password";

        //default testnet connection info
        public string TestCLIPath = @"C:\SUP\SUP.exe"; // Replace with the actual path to SUP.EXE
        public string TestVersionByte = @"111"; // Replace with the actual version byte
        public string TestRPCURL = @"http://127.0.0.1:18332";
        public string TestRPCUser = "good-user";
        public string TestRPCPassword = "better-password";


Requires ASP.NET Core Windows Hosting Bundle. ( install after IIS )
https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.4-windows-hosting-bundle-installer 