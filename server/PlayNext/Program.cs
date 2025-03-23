using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PlayNextServer;
using PlayNextServer.Services;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins", builder =>
	{
		builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidIssuer = Configuration["Jwt:Issuer"],
			ValidAudience = Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
		};
	});

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Настраиваем маршруты и Middleware
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // Автоматически подключает контроллеры

app.UseCors("AllowAllOrigins");

app.Run(); // Запускаем сервер

#region Igdb
//var configuration = new ConfigurationBuilder()
//    .AddUserSecrets<Program>()
//    .Build();

//AppDbContext context = new AppDbContext();

//var igdb = new IgdbApi();
//await igdb.Authorize(configuration["igdbClientId"], configuration["igdbClientSecret"]);

//int offset = 100;

//var existingGameIds = await context.Games.Select(c => c.Id).ToHashSetAsync();
//while(true)
//{
//    var collections = await igdb.UploadAll<Website>(Urls.GetWebsites, Urls.MaxLimit, offset, 400);

//    if (collections is null || collections.Count == 0)
//    {
//        break;
//    }

//    foreach (var entity in collections)
//    {
//        if (entity.GameId.HasValue && !existingGameIds.Contains(entity.GameId.Value))
//        {
//            entity.GameId = null; // Убираем некорректный CoverId сразу
//        }

//        var find = await context.Websites.AsNoTracking().FirstOrDefaultAsync(c => c.Id == entity.Id);
//        if (find is null)
//        {
//            await context.Websites.AddAsync(entity);
//        }
//    }
//    await context.SaveChangesAsync();
//    context.ChangeTracker.Clear();

//    /*while (true) // Цикл, пока не удастся сохранить изменения
//    {
//        try
//        {

//        }
//        /*catch (DbUpdateException e) when (e.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
//        {
//            Match match = Regex.Match(pgEx.Detail, @"\((\d+)\)");

//            if (match.Success)
//            {
//                int coverId = int.Parse(match.Groups[1].Value);
//                var game = collections.FirstOrDefault(g => g.CoverId == coverId);
//                game.CoverId = null;
//                await context.SaveChangesAsync();
//                context.ChangeTracker.Clear();
//                Console.WriteLine(game.Id + " game set cover id 0.");
//            }
//        }#1#
//        catch (DbUpdateException e)
//        {
//             Находим PostgresException в цепочке исключений
//            var pgEx = e.GetBaseException() as PostgresException;

//            if (pgEx != null && pgEx.SqlState == "23503")
//            {
//                Match match = Regex.Match(pgEx.Detail, @"\((\d+)\)");

//                if (match.Success)
//                {
//                    int coverId = int.Parse(match.Groups[1].Value);
//                    var game = collections.FirstOrDefault(g => g.CoverId == coverId);

//                    if (game != null)
//                    {
//                        game.CoverId = null;
//                        context.Update(game);
//                        Console.WriteLine($"{game.Id} game set cover id to null.");
//                    }
//                }
//            }
//            else
//            {
//                Console.WriteLine($"Ошибка базы данных: {e.Message}");
//                throw;
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
//            throw;
//        }*/

//        Console.WriteLine(Urls.MaxLimit + " обьектов сохранено. " + offset);
//        offset += collections.Count;

//}
#endregion

#region Steam

/*var steamApi = new SteamApi(configuration["steamApiKey"]);*/

#endregion



