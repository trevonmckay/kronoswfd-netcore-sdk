using Newtonsoft.Json.Converters;

namespace Kronos.WFD.Client.Serialization
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
