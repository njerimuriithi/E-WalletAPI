using E_WalletAPI.Controllers;
using E_WalletAPI.DataDbContext;
using E_WalletAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
                                    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(); 
//builder.Services.AddDbContext<TransactionDbContext>(options => options.UseInMemoryDatabase("TransactionList"));
builder.Services.AddDbContext<TransactionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<DbContext>(opt =>
//    opt.UseInMemoryDatabase("DailyList"));
//builder.Services.AddSingleton<IWallet,DailyTransactionRepo>();

var app = builder.Build();
app.UseCors(option =>
{
    option.AllowAnyOrigin().AllowAnyHeader().AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapDailyTransactionsEndpoints();

app.Run();
