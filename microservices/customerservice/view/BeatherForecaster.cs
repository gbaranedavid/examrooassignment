using Amazon.DynamoDBv2.DataModel;
namespace signupservice.View{

[DynamoDBTable("BeatherForecastDetails")]
public class BeatherForecast
{
    [DynamoDBHashKey]
    public DateOnly Date { get; set; }
    [DynamoDBRangeKey]
    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
}
