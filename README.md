# p2fk.io
p2fk.io is a simple .NET API wrapper allowing developers to interact with the Sup!? CLI via the traditional web.



# How to Sync Sup!?
The latest release of Sup!? with CLI can be found here: https://github.com/embiimob/SUP

1. create a folder C:\SUP and unzip the latest release into it.
2. run SUP.EXE,  click the 🗝️ icon, launch and sync both bitcoin wallets.


NOTICE: Update the Wrapper.cs file if you wish to use something other then the following default values 

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


NOTICE: Update Program.cs if you wish to use images other then what is defaulted or change the titles

# defaults:

        //removes the /swagger/ from the path
        options.RoutePrefix = string.Empty;

        //update to incude your own api and version
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "P2FK.IO V1");

        //update to incude your own api 
        options.DocumentTitle = "p2fk.io";

        options.DisplayRequestDuration();

        //update to use your own images and favicons
        options.HeadContent = @"
        <link rel=""apple-touch-icon"" sizes=""180x180"" href=""./apple-touch-icon.png"" />
        <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""./favicon-32x32.png"" />
        <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""./favicon-16x16.png"" />
        <style>
            .swagger-ui img  {
                content: url('./HugPuddle.jpg');
                width: 50px;
                height: auto;
            }
        </style>";


        //added because large json output styling slows down the swagger ui
        options.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
         {
             ["activated"] = false
         };



Requires ASP.NET Core Windows Hosting Bundle. ( install after IIS )

https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.4-windows-hosting-bundle-installer 