using Microsoft.EntityFrameworkCore;
using salesOrderApi.DataAccess;
using salesOrderApi.Handler;
using salesOrderApi.Repository;
using salesOrderApi.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// 1  Connection with Sql server express
const string CONNECTIONNAME = "DefaultConnection";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 2 Add Context to Services of Builder
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));



// Add services to the container.

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
