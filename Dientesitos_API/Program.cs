using Dientesitos_API.Service.CDoctor;
using Dientesitos_API.Service.CPaciente;
using Dientesitos_API.Service.CSede;
using Dientesitos_API.Service.CTratamiento;
using Dientesitos_API.Service.CCita;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Add(new ServiceDescriptor(typeof(IPaciente),
    new PacienteRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IDoctor),
    new DoctorRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ISede),
    new SedeRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ITratamiento),
    new TratamientoRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICita),
    new CitaRepository()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
