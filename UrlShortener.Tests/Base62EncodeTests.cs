using UrlShortener.Services;

namespace UrlShortener.Tests
{
    public class Base62EncodeTests
    {
        [Fact]
        public void Encode_One()
        {
            var result = Base62Encoder.Encode(1);

            Assert.Equal("1", result);
        }

        [Fact]
        public void Encode_Ten()
        {
            var result = Base62Encoder.Encode(10);

            Assert.Equal("a", result);
        }

        [Fact]
        public void Encode_NintyNine()
        {
            var result = Base62Encoder.Encode(99);

            Assert.Equal("1B", result);
        }
    }
}
