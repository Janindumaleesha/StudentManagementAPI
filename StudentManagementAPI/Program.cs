using Microsoft.IdentityModel.Tokens;
using StudentManagementAPI.Helpers;
using StudentManagementAPI.Services.Students;
using StudentManagementAPI.Services.Subjects;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("JWTToken")
    .AddJwtBearer("JWTToken", options => 
    {
        var keyBytes = Encoding.UTF8.GetBytes(ConstantsHelper.Secret);
        var key = new SymmetricSecurityKey(keyBytes);

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = ConstantsHelper.Issuer,
            ValidAudience = ConstantsHelper.Audience,
            IssuerSigningKey = key

        };
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
