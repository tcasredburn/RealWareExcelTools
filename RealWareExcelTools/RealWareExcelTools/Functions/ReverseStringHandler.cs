using RealWareExcelTools.Core.Functions;
using System;

namespace RealWareExcelTools.Functions
{
    internal class ReverseStringHandler : IRealWareExcelFunction
    {
        private readonly string _inputString;

        public ReverseStringHandler(string inputString)
        {
            _inputString = inputString;
        }

        public string GetResult()
        {
            var charArray = _inputString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
