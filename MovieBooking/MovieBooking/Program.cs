using MovieBooking.Services.BookingService;
using MovieBooking.Services.MovieManagementService;
using MovieBooking.Services.TheatreManagementService;
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddSingleton<IMovieManagementService, MovieManagementService>();
    builder.Services.AddSingleton<IBookingService, BookingService>();
    builder.Services.AddSingleton<ITheatreManagementService,TheatreManagementService>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


