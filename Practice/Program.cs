using Microsoft.EntityFrameworkCore;
using Practice;
using Practice.DAO;
using Practice.Data;
using Practice.Models;

string allowedOrigin = "allowedOrigin";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>().AddMutationType<Mutation>()
    .AddProjections().AddFiltering().AddSorting().AddInMemorySubscriptions();
builder.Services.AddCors(option =>
{
    option.AddPolicy("allowedOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
// app.UseCors(x => x
//     .AllowAnyMethod()
//     .AllowAnyHeader()
//     .SetIsOriginAllowed(origin => true)
//     .AllowCredentials());

app.UseCors(allowedOrigin);
app.UseWebSockets();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DBContext>();
    dbContext.Database.EnsureCreated();
    DataSeeder.SeedData(dbContext);
}
app.MapGraphQL("/graphql");

app.Run();