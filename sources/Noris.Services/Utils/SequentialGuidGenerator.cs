using System;
using System.Security.Cryptography;


namespace Noris.Services.Utils
{
    public enum SequentialGuidType
    {
        SequentialAsString,
        SequentialAsBinary,
        SequentialAtEnd
    }

    /// <summary>
    /// Generator of unique sequence for Guid type on aplication side (not database side)
    /// </summary>
    public class SequentialGuidGenerator
    {
        private readonly RNGCryptoServiceProvider _rng;
        private readonly long _initialTick = new DateTime(2000, 01, 01).Ticks;

        public SequentialGuidGenerator()
        {
            _rng = new RNGCryptoServiceProvider();
        }

        public Guid NewGuid(SequentialGuidType guidType)
        {
            var randomBytes = new byte[10];
            _rng.GetBytes(randomBytes);

            var timestamp = (DateTime.UtcNow.Ticks - _initialTick) / 10000L;
            var timestampBytes = BitConverter.GetBytes(timestamp);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestampBytes);
            }

            var guidBytes = new byte[16];

            switch (guidType)
            {
                case SequentialGuidType.SequentialAsString:
                case SequentialGuidType.SequentialAsBinary:
                    Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
                    Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);

                    if (guidType == SequentialGuidType.SequentialAsString
                        && BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(guidBytes, 0, 4);
                        Array.Reverse(guidBytes, 4, 2);
                    }
                    break;

                case SequentialGuidType.SequentialAtEnd:
                    Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
                    Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);
                    break;
            }

            return new Guid(guidBytes);
        }
    }
}
