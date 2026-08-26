using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;

namespace WeatherBot;

// Класс. sealed — от него нельзя наследовать.
// : IDisposable — реализация интерфейса (контракт: обязан быть Dispose).
internal sealed class WeatherService : IDisposable
{
    // static + readonly: одно общее поле на весь тип, не на экземпляр.
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    // Поле экземпляра. private — инкапсуляция, снаружи класса не видно.
    private readonly HttpClient _http = new();

    // Публичный метод экземпляра. async — возвращает Task, не блокирует поток.
    public async Task<string> GetTemperatureAsync(string cityName, CancellationToken token)
    {
        var (lat, lon) = await GetCoordinatesAsync(cityName, token);

        var latStr = lat.ToString("0.00", CultureInfo.InvariantCulture);
        var lonStr = lon.ToString("0.00", CultureInfo.InvariantCulture);

        var url =
            $"https://api.open-meteo.com/v1/forecast?latitude={latStr}&longitude={lonStr}&current=temperature_2m";

        var forecast = await _http.GetFromJsonAsync<ForecastResponse>(url, JsonOptions, token)
            ?? throw new InvalidOperationException("Пустой ответ прогноза");

        var temp = forecast.Current?.Temperature2M
            ?? throw new InvalidOperationException("В ответе нет температуры");

        return $"{temp} °C";
    }

    // private-метод: деталь реализации, снаружи не вызывается.
    private async Task<(double Lat, double Lon)> GetCoordinatesAsync(string cityName, CancellationToken token)
    {
        var url =
            $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(cityName)}&count=1&language=ru&format=json";

        var geo = await _http.GetFromJsonAsync<GeoSearchResponse>(url, JsonOptions, token);

        var place = geo?.Results?.FirstOrDefault()
            ?? throw new InvalidOperationException($"Город не найден: {cityName}");

        return (place.Latitude, place.Longitude);
    }

    // Метод интерфейса IDisposable: освобождает HttpClient.
    public void Dispose() => _http.Dispose();
}
