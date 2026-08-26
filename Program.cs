using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using WeatherBot;

var token = BotConfig.GetToken(); // вызов static-метода, без new

// new — создание экземпляра класса. using — вызов Dispose() в конце (IDisposable).
using var weather = new WeatherService();

// Экземпляр handler; в конструктор передаём зависимость weather (композиция).
var handler = new WeatherBotHandler(weather);

var bot = new TelegramBotClient(token); // экземпляр клиента Telegram
using var cts = new CancellationTokenSource();

bot.StartReceiving(
    updateHandler: handler.HandleUpdateAsync, // метод экземпляра как делегат
    errorHandler: handler.HandleErrorAsync,
    receiverOptions: new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() },
    cancellationToken: cts.Token);

Console.WriteLine("Start Weather Telegram bot");
Console.ReadLine();
cts.Cancel();