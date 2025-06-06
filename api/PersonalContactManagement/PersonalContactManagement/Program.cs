
using PersonalContactManagement.Domain.IServe;
using PersonalContactManagement.Domain.Serve;
using PersonalContactManagement.EntityFrameCore.Config;

namespace PersonalContactManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Sqlite Context
            builder.Services.AddDbContext<MyDbContext>();

            // Add services to the container.
            // �����־���񣨱������þ����ṩ������Console/Debug/�ļ��ȣ�
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();   // ���������̨
                loggingBuilder.AddDebug();      // ��������Դ���
            });
            builder.Services.AddScoped<IContactServe, ContactServe>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ȷ�����ݿⴴ����Ǩ��
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
