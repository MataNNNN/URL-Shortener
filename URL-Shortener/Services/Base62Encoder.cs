using System.Text;

namespace UrlShortener.Services
{
    public class Base62Encoder
    {
        private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Encode(long number)
        {
            if (number == 0) return Alphabet[0].ToString();

            var builder = new StringBuilder();
            while (number > 0)
            {
                builder.Insert(0, Alphabet[(int)(number % 62)]);
                number /= 62;
            }
            return builder.ToString();
        }
    }
}
