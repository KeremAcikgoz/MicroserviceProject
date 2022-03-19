using CustomerAPI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderAPI.Models
{
    public class OrderConverter : JsonConverter<Address>
    {
        public override Address Read(ref Utf8JsonReader reader, Type typeToConvert,
    JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                // You can either return this, or a null object if you prefer
                return null;
            }

            return JsonSerializer.Deserialize<Address>(ref reader);
        }

        public override void Write(Utf8JsonWriter writer, Address value,
            JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
