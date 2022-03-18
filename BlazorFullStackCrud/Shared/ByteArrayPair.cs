using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public struct ByteArrayPair
    {
        public ByteArrayPair(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public byte[] PasswordHash { get; }
        public byte[] PasswordSalt { get; }
    }
}
