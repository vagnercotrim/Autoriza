using System;

namespace Autoriza.Infra
{
    public class Randomize
    {
        private readonly Random random = new Random();
        private readonly String characters = "1234567890abdcefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public String Generate(int size)
        {
            return Generate(characters, size);
        }

        public String Generate(String chars, int size)
        {
            char[] buffer = new char[size];
            for (int i = 0; i < size; i++)
                buffer[i] = chars[random.Next(chars.Length)];
            return new string(buffer);
        }

    }
}