namespace Demo.Environment.Vars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();



                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                var environment = builder.Configuration["ASPNETCORE_ENVIRONMENT"];
                logger.LogInformation($"Inside IsDevelopment() ASPNETCORE_ENVIRONMENT: {environment}");

                app.MapOpenApi();
            }

           
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}