using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dotnetCore_WSDL.Data{
    public static class RequestExtension
    {
        //set config
        //example WSDL : http://localhost/jwsdata/services/Data?wsdl
        public static string url = "http://localhost/jwsdata/services/Data?wsdl";
        public static string XmlString = @""; // 輸入要request 內容


        // request result
        public static ResponseResult result { get; set; } =new ResponseResult();
        public class ResponseResult
        {
            public bool status { get; set; } = false;
            public string message { get; set; } = "";
        }


        // request WSDL
        public static async Task<ResponseResult> RequestWSDL()
        {
            //取得當前 html 字串
            HttpClient client = new();
            client
                .DefaultRequestHeaders
                .Accept
                .Add(
                    new MediaTypeWithQualityHeaderValue("text/xml")
                );//ACCEPT header

            try{
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = 
                    new StringContent(XmlString, Encoding.UTF8, "text/xml");//CONTENT-TYPE header

                HttpResponseMessage response =  await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return new ResponseResult{
                    status = true,
                    message = responseBody,
                };

            }catch(Exception ex){
                return new ResponseResult{
                    status = false,
                    message = ex.Message,
                };
            }
        }//RequestWSDL

        
    }//class RequestExtension
}//namespace
