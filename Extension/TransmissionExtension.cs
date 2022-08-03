using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetCore_WSDL.Extension
{
    public static class TransmissionExtension
    {
        /// <summary>
        /// 迭代屬性，呼叫 string.Trim() 去除前後空白
        /// </summary>
        /// <param name="item"></param>
        public static void Trim(this object item)
        {
            foreach (var prop in item.GetType().GetProperties())
            {
                string? s = prop.GetValue(item) as string;
                if (s != null)
                {
                    prop.SetValue(item, s.Trim());
                }
            }
        }

        public static string ConvertClassName<T>(){
            Type t = typeof(T);
            return t!=null?  t.Name : "";
        }

        public static string Convert<T>(T obj){
            Type t = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(t);
            StringBuilder strBuilder = new StringBuilder();
            foreach (PropertyDescriptor property in properties)
            {
                if (property.GetValue(obj) is null ||string.IsNullOrEmpty(property.GetValue(obj).ToString())) { continue; }
                strBuilder.AppendLine(
                    @$"<xsd:{property.Name}>{property.GetValue(obj)}</xsd:{property.Name}>"
                );
            }
            return strBuilder.ToString();
        }

    }
}