using OrdemServico.Infra.Database;
using OrdemServico.Service;
using OrdemServico.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddOrdemServicoDatabaseServiceModule(builder.Configuration);
builder.Services.AddOrdemServicoServiceModule();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(op =>
{
    op.SwaggerEndpoint("/openapi/v1.json", "Ordem de Servico Api");
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
