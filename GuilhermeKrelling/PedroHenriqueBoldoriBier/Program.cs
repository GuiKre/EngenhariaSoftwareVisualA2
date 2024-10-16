using PedroHenriqueBoldoriBier.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDbContext ctx) => 
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapGet("/api/funcionario/listar", ([FromServices] AppDbContext ctx) => 
{
    if(ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound();
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha,
    [FromServices] AppDbContext ctx) => 
{
    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("/api/folha/listar", ([FromServices] AppDbContext ctx) => {
    var folhasList = ctx.Folhas.ToList();
    
    if(folhasList is not null){
        return Results.Ok(folhasList);
    }

    return Results.NotFound();
    
});

app.MapGet("/api/folha/buscar/{cpf}/{mes}/{ano}", ([FromRoute] string cpf , int mes , int ano, [FromServices] AppDbContext ctx) =>
{

    Folha? folha = ctx.Folhas.FirstOrDefault(x => x.Mes == mes && x.Ano == ano );


    if (folha == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(folha);
});

app.Run();

