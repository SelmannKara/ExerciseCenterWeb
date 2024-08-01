
using ExerciseCenter_API.Mapping;
using ExerciseCenter_API.Models;
using ExerciseCenter_API.Repositories.BlogPostsRepository;
using ExerciseCenter_API.Repositories.ServicesRepository;
using ExerciseCenter_API.Repositories.TestimonialsRepository;
using ExerciseCenter_API.Repositories.WhoWeAreRepository;
using ExerciseCenter_API.Services.BlogPostsService;
using ExerciseCenter_API.Services.ServicesService;
using ExerciseCenter_API.Services.TestimonialsService;
using ExerciseCenter_API.Services.WhoWeAreService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();

builder.Services.AddScoped<IWhoWeAreRepository, WhoWeAreRepository>();
builder.Services.AddScoped<IWhoWeAreService, WhoWeAreService>();

builder.Services.AddScoped<IBlogPostsRepository, BlogPostsRepository>();
builder.Services.AddScoped<IBlogPostsService, BlogPostsService>();

builder.Services.AddScoped<ITestimonialsRepository, TestimonialsRepository>();
builder.Services.AddScoped<ITestimonialsService, TestimonialsService>();


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
