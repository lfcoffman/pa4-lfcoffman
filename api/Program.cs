using System;
using pa4_lfcoffman.api.Models;
namespace pa4_lfcoffman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ExerciseUtility exerciseUtility = new ExerciseUtility();
            System.Console.WriteLine(exerciseUtility.GetAllExercises());
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("OpenPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
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

            app.UseCors("OpenPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}