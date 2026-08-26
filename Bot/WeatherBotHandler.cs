using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot;

// Primary constructor: параметр weather — и аргумент конструктора, и поле экземпляра.
// Композиция: handler «имеет» WeatherService, а не наследует его.
internal sealed class WeatherBotHandler(WeatherService weather)
{
    // ITelegramBotClient — интерфейс (абстракция клиента Telegram).
    public async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        if (update.Message is not { Text: { } text, Chat: var chat })
            return;

        Console.WriteLine($"Received message: '{text}'");

        if (text is "/start")
        {
            await bot.SendMessage(
                chatId: chat.Id,
                text: "Выберите город или напишите свой:",
                replyMarkup: CityKeyboard.Markup,
                cancellationToken: token);
            return;
        }

        try
        {
            var city = CityKeyboard.ToQuery(text);
            var temperature = await weather.GetTemperatureAsync(city, token);

            await bot.SendMessage(
                chatId: chat.Id,
                text: $"{city}: {temperature}",
                replyMarkup: CityKeyboard.Markup,
                cancellationToken: token);
        }
        catch (Exception ex) // базовый класс всех исключений
        {
            Console.WriteLine(ex.Message);

            await bot.SendMessage(
                chatId: chat.Id,
                text: $"Не удалось получить погоду для «{text}». Попробуйте другой город.",
                replyMarkup: CityKeyboard.Markup,
                cancellationToken: token);
        }
    }

    public Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken token)
    {
        Console.WriteLine(exception.Message);
        return Task.CompletedTask;
    }
}
