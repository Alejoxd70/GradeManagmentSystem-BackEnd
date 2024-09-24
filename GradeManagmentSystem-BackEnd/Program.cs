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
//Grade
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
//Group
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupService, GroupService>();
//Subject
builder.Services.AddScoped<ISubjectRepository,  SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
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

//Permission
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

//PermissionUserType
builder.Services.AddScoped<IPermissionUserTypeRepository, PermissionUserTypeRepository>();
builder.Services.AddScoped<IPermissionUserTypeService, PermissionUserTypeService>();

//UserType
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();





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
