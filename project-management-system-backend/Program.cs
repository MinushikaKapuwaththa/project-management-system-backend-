using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;
using project_management_system_backend.Controllers;
using project_management_system_backend.Data;
using project_management_system_backend.Repostories;
using static project_management_system_backend.Repostories.DocumentUploaderService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IClientCompanyRepository, ClientCompanyRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentUploaderService, DocumentUploaderService>();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
 .AllowAnyMethod()
 .AllowAnyHeader()
 .SetIsOriginAllowed(origin => true) // allow any origin
.AllowCredentials()); // allow credentialsS

app.UseAuthorization();

app.MapControllers();

app.Run();
