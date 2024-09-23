using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Repositories;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using static GradeManagmentSystem_BackEnd.Services.ISubjectTeacherService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppGradesContext>(options => options.UseSqlServer(connection));

// -------- Add Repositories and services ---------//
// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//Assigment
builder.Services.AddScoped<IAssigmentRepository, AssigmentRepository>();
builder.Services.AddScoped<IAssigmentService, AssigmentService>();
//Group Year
builder.Services.AddScoped<IGroupYearRepository, GroupYearRepository>();
builder.Services.AddScoped<IGroupYearService, GroupYearService>();
//Subject Teacher
builder.Services.AddScoped<ISubjectTeacherRepository, SubjectTeacherRepository>();
builder.Services.AddScoped<ISubjectTeacherService, SubjectTeacherService>();


// Student 
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

// Attendant
builder.Services.AddScoped<IAttendantRepository, AttendantRepository>();
builder.Services.AddScoped<IAttendantService, AttendantService>();

// Teacher
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();



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
