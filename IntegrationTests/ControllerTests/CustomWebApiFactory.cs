//using BL.Interfaces;
//using DAL.Interface;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.Extensions.DependencyInjection;
//using Moq;
//using notesApi;

//namespace IntegrationTests.ControllerTests;
//public class CustomWebApiFactory : WebApplicationFactory<Startup>
//{
//    public Mock<INoteRepository> noteRepositoryMock { get; }
//    public Mock<IServiceNote> noteServiceMock { get; }

//    public CustomWebApiFactory()
//    {
//        noteServiceMock = new Mock<IServiceNote>();
//        noteRepositoryMock = new Mock<INoteRepository>();
//    }

//    protected override void ConfigureWebHost(IWebHostBuilder builder)
//    {
//        base.ConfigureWebHost(builder);

//        builder.ConfigureTestServices(services =>
//        {
//            services.AddSingleton(noteRepositoryMock.Object);
//            services.AddSingleton(noteServiceMock.Object);
//        });
//    }
//}
