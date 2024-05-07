using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

  app.UseSwagger();
  app.UseSwaggerUI(options =>
    {

        options.DocumentTitle = "p2fk.io";
        options.DisplayRequestDuration();

        options.HeadContent = @"
        <style>
            .swagger-ui img  {
                content: url('https://avatars.githubusercontent.com/u/6278955?s=400&v=4');
                width: 50px;
                height: auto;
            }
        </style>";



        //added because large json output styling slows down the swagger ui
        options.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
         {
             ["activated"] = false
         };


    }
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
