// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
      var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //.. for test
            Console.WriteLine(Configuration["ConnectionString"]);