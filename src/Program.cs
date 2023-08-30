using SuperPets.Data;
using SuperPets.Endpoints.Animals;
using SuperPets.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionString:SuperPetsDB"]);
builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.MigrationInitialization(app);

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseCors(builder => builder.AllowAnyHeader());
app.UseCors(builder => builder.AllowAnyMethod());

app.MapMethods(AnimalPost.Template, AnimalPost.Methods, AnimalPost.Handle);
app.MapMethods(AnimalGet.Template, AnimalGet.Methods, AnimalGet.Handle);
app.MapMethods(AnimalGetById.Template, AnimalGetById.Methods, AnimalGetById.Handle);
app.MapMethods(AnimalPut.Template, AnimalPut.Methods, AnimalPut.Handle);
app.MapMethods(AnimalDelete.Template, AnimalDelete.Methods, AnimalDelete.Handle);

app.Run();
