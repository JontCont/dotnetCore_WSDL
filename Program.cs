using System;
using System.Threading.Tasks;
using dotnetCore_WSDL.Data;
using dotnetCore_WSDL.Extension;
namespace dotnetCore_WSDL
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // step 1 : Setting parameters
            // string str = TransmissionExtension.Convert(new sendJob{ .... });
            // Console.WriteLine(str);

            // step 2 : Add parameters and request WSDL
            var requestResult = await RequestExtension.RequestWSDL();
            Console.WriteLine($"status : {requestResult.status} , message : {requestResult.message}");
        }
    }
}
