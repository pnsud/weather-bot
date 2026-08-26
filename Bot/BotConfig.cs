using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace WeatherBot;

// static-класс-хелпер: только методы типа, состояния (полей экземпляра) нет.
internal static class BotConfig
{
    public static string GetToken()
    {
        // Экземпляр ConfigurationBuilder: паттерн «строитель» (цепочка Add... → Build).
        var config = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
            .Build();

        return config["Telegram:BotToken"]
            ?? throw new InvalidOperationException(
                "Задайте токен: dotnet user-secrets set \"Telegram:BotToken\" \"ваш_токен_от_BotFather\"");
    }
}
