using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot;

var token = BotConfig.GetToken(); // вызов static-метода

var tgBotClient = new TelegramBotClient(token);

var me = await tgBotClient.GetMe();
Console.WriteLine($"Id: {me.Id}, bot name: {me.FirstName}.");