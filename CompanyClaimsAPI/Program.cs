namespace CompanyClaimsAPI

    {
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
   
            }
            finally
            {

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(builder =>
                    {

                    })
                   .ConfigureWebHostDefaults(webBuilder =>
                   {

                       webBuilder.UseStartup<Startup>();

                   });
    }


}