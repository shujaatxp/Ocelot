using Confluent.Kafka;
using Sensor.Publisher;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

builder.Services.AddSingleton<IProducer<Null, string>>(x => new
ProducerBuilder<Null, string>(config).Build());

builder.Services.AddSingleton<IWeatherDataPublisher,WeatherDataPublisher>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();
