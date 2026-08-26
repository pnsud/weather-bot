using System.Text.Json.Serialization;

namespace WeatherBot; // пространство имён — группирует типы бота

// DTO (data class): только данные ответа API, без логики.
internal sealed class GeoSearchResponse
{
    // Автосвойство: get/set. ? — значение может быть null.
    public List<GeoResult>? Results { get; set; }
}

internal sealed class GeoResult
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

internal sealed class ForecastResponse
{
    public CurrentWeather? Current { get; set; }
}

internal sealed class CurrentWeather
{
    // Атрибут: имя поля в JSON не совпадает с именем свойства.
    [JsonPropertyName("temperature_2m")]
    public double Temperature2M { get; set; }
}
