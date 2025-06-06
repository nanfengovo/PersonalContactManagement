
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
            // 添加日志服务（必须配置具体提供程序，如Console/Debug/文件等）
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();   // 输出到控制台
                loggingBuilder.AddDebug();      // 输出到调试窗口
            });
            builder.Services.AddScoped<IContactServe, ContactServe>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 确保数据库创建和迁移
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
