using Telegram.Bot.Types.ReplyMarkups;

namespace WeatherBot;

// static-класс: нельзя создать экземпляр (new CityKeyboard()), только тип со статическими членами.
internal static class CityKeyboard
{
    // Константы: значения известны на этапе компиляции.
    public const string Moscow = "Москва";
    public const string Spb = "Питер";
    public const string Sochi = "Сочи";

    // Статическое свойство: одно на весь тип. new ... — создание экземпляра ReplyKeyboardMarkup.
    public static ReplyKeyboardMarkup Markup { get; } = new(
        new KeyboardButton[][]
        {
            [Moscow, Spb, Sochi]
        })
    {
        ResizeKeyboard = true
    };

    // Статический метод: вызывается как CityKeyboard.ToQuery(...), без объекта.
    public static string ToQuery(string text) => text switch
    {
        Moscow => "Москва",
        Spb => "Санкт-Петербург",
        Sochi => "Сочи",
        _ => text.Trim()
    };
}
