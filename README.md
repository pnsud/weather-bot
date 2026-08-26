<h1 align="center">Weather Telegram Bot</h1>

<p align="center">
  Консольный бот на C#: температура по названию города или по кнопке.
</p>

<p align="center">
    <a href="https://dotnet.microsoft.com/download"><img src="https://img.shields.io/badge/SDK-C%23-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET SDK · C#"></a>
    <a href="https://core.telegram.org/bots"><img src="https://img.shields.io/badge/Telegram-Bot_API-26A5E4?style=flat-square&logo=telegram&logoColor=white" alt="Telegram Bot"></a>
    <a href="https://open-meteo.com/"><img src="https://img.shields.io/badge/Open--Meteo-Weather_API-0EA5E9?style=flat-square" alt="Open-Meteo"></a>
    <a href="https://stepik.org/lesson/1253156/step/1"><img src="https://img.shields.io/badge/Stepik-урок_бота-39C16C?style=flat-square" alt="Stepik"></a>
</p>

## О проекте

Приложение на [.NET 10](https://dotnet.microsoft.com/download) поднимает Telegram-бота через long polling. Пользователь пишет его текстом — бот отвечает текущей температурой из [Open-Meteo](https://open-meteo.com/) (геокодинг + прогноз). Токен в репозиторий не попадает: он читается из [User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets).

### Откуда взялся код

База — учебный шаг курса **«C# для начинающих. С нуля до первых проектов»** на Stepik: [Разработка Telegram-бота](https://stepik.org/lesson/1253156/step/1)

Дальше репозиторий живёт уже не как сдача урока, а как **своя песочница**

## Зависимости

| Пакет                                                                                                                           | Версия |
| ------------------------------------------------------------------------------------------------------------------------------- | ------ |
| [Telegram.Bot](https://www.nuget.org/packages/Telegram.Bot)                                                                     | 22.7.2 |
| [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets) | 9.0.8  |

## Что дальше

Cобственные хотелки: удобство, архитектура, фичи бота.
Список не фиксирован и будет меняться по мере идей.

- [x] Начало проекта
- [x] Механизм для работы с пользовательскими секретами
- [x] Реализация кнопок
- [] Добавление БД
- [] Вывод популярных городов
