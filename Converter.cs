using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace MyNamespace
{
    static class Converter
    {
        public static byte[] ConvertHexStringToBytesArray(string hexString, bool reverseOutput = false)
        {
            List<byte> myBytes = new List<byte>();
            hexString = hexString.Replace("0x", "");

            while (hexString.Length > 0)
            {
                string s;
                if (hexString.Length > 1)
                {
                    s = hexString.Substring(hexString.Length - 2, 2);
                    hexString = hexString.Substring(0, hexString.Length - 2);
                }
                else
                {
                    s = hexString;
                    hexString = "";
                }
                byte b;
                if (convertStringByteHexToByte(s, out b) == true)
                {
                    myBytes.Add(b);
                }
                else break;
            }

            if (reverseOutput)
            {
                myBytes.Reverse();
            }
            return myBytes.ToArray();
        }

        public static byte[] ConvertHexStringToBytesArray(string hexString, int nofBytesToReturn, bool reverseOutput = false)
        {
            byte[] convertedBytes = ConvertHexStringToBytesArray(hexString);

            if (convertedBytes.Length == 0) return convertedBytes;

            byte[] bytesToReturn = new byte[nofBytesToReturn];
            int numBytesInForLoop = convertedBytes.Length > nofBytesToReturn ? nofBytesToReturn : convertedBytes.Length;
            for(int i=0; i<numBytesInForLoop; i++)
            {
                bytesToReturn[i] = convertedBytes[i];
            }
            return bytesToReturn;
        }

        static bool convertStringByteHexToByte(string strByteHex, out byte b)
        {
            if (strByteHex.Length == 1) strByteHex = "0" + strByteHex;

            return byte.TryParse(strByteHex, NumberStyles.HexNumber, null, out b);
        }
    }
}
