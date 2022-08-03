using System;
using System.Threading.Tasks;
using dotnetCore_WSDL.Data;

namespace dotnetCore_WSDL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var requestResult = await RequestExtension.RequestWSDL();
            Console.WriteLine($"status : {requestResult.status} , message : {requestResult.message}");
        }
    }
}
