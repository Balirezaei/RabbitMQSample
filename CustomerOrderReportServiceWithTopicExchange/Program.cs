using CommonRabbitMQTools;
using CustomerOrderReportServiceWithTopicExchange;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConnectionProvider>(new RabbitMQConnectionProvider("amqp://guest:guest@localhost:5672"));

//The Rout key for adding to exchange is "order.created"
// In 'Topic' Exchange send messages with Pattern match "order.*"

builder.Services.AddSingleton<ISubscriber>(x => new RabbitMqSubscriber(x.GetService<IConnectionProvider>(),
        "order_exchange",
        "ordert_queue",
        "order.*",
        ExchangeType.Topic));

builder.Services.AddSingleton<IInMemoryDb, InMemoryDb>();
builder.Services.AddHostedService<ServiceHostSubcriber>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
