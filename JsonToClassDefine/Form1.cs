using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonToClassDefine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtClass.Text = "";
            Newtonsoft.Json.Linq.JObject jsonObj;
            var jsonToken = (Newtonsoft.Json.Linq.JToken)Newtonsoft.Json.JsonConvert.DeserializeObject(getJsonString());
            if (jsonToken.Type == Newtonsoft.Json.Linq.JTokenType.Array)
            {
                jsonObj = (Newtonsoft.Json.Linq.JObject)((Newtonsoft.Json.Linq.JArray)jsonToken)[0];
            }
            else if (jsonToken.Type == Newtonsoft.Json.Linq.JTokenType.Object)
            {
                jsonObj = (Newtonsoft.Json.Linq.JObject)jsonToken;
            }
            else
            {
                return;
            }
                List<StringBuilder> classList = new List<StringBuilder>();
           
            var className = txtClassName.Text;
            if(string.IsNullOrEmpty(className))
            {
                MessageBox.Show(className);
            }

            parseJson(jsonObj, classList, className);

            foreach( var s in classList )
            {
                txtClass.AppendText(s.ToString() + "\r\n\r\n");
            }
        }

        void parseJson(Newtonsoft.Json.Linq.JObject jsonObj , List<StringBuilder> classList,string className)
        {
            var jsonProperty = jsonObj.Properties();
            StringBuilder resultStr = new StringBuilder();
            classList.Add(resultStr);

            resultStr.AppendLine("class "+ className + "{");
            foreach (var pro in jsonProperty)
            {
                string name = pro.Name;
                var value = pro.Value as Newtonsoft.Json.Linq.JValue;
                resultStr.Append("public ");
                if(pro.Value == null)
                {
                    resultStr.Append("object ");
                }
                else if(pro.Value.Type == Newtonsoft.Json.Linq.JTokenType.Object)
                {
                    string myName = name[0].ToString().ToUpper() + name.Substring(1);
                    resultStr.Append(className + "_" + myName + " ");
                    parseJson((Newtonsoft.Json.Linq.JObject)pro.Value, classList, className + "_" + myName);
                }
                else if (pro.Value.Type == Newtonsoft.Json.Linq.JTokenType.Array)
                {
                    string otherString = "[]";                   
                    Newtonsoft.Json.Linq.JArray array = (Newtonsoft.Json.Linq.JArray)pro.Value;
                    _check:
                    if (array.Count > 0 && array[0].Type == Newtonsoft.Json.Linq.JTokenType.Object)
                    {
                        string myName = name[0].ToString().ToUpper() + name.Substring(1);
                        resultStr.Append(className + "_" + myName + otherString + " ");
                        parseJson((Newtonsoft.Json.Linq.JObject)array[0], classList, className + "_" + myName);
                    }
                    else if (array.Count > 0 && array[0].Type == Newtonsoft.Json.Linq.JTokenType.Array)
                    {
                        array = (Newtonsoft.Json.Linq.JArray)array[0];
                        otherString += "[]";
                        goto _check;
                    }
                    else
                    {
                        resultStr.Append("object ");
                    }
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.String)
                {
                    resultStr.Append("string ");
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.Integer)
                {
                    resultStr.Append("int? ");
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.Boolean)
                {
                    resultStr.Append("bool ");
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.Bytes)
                {
                    resultStr.Append("byte[] ");
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.Date)
                {
                    resultStr.Append("DateTime? ");
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.Float)
                {
                    resultStr.Append("double? ");
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.Guid)
                {
                    resultStr.Append("Guid ");
                }
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.TimeSpan)
                {
                    resultStr.Append("TimeSpan? ");
                }               
                else if (value.Type == Newtonsoft.Json.Linq.JTokenType.Object)
                {
                    parseJson((Newtonsoft.Json.Linq.JObject)pro.Value, classList, className + "_" + name);
                }
                else
                {
                    resultStr.Append("object ");
                }
                resultStr.Append(name);
                resultStr.AppendLine("{get;set;}");
                resultStr.AppendLine("");
            }
            resultStr.AppendLine("}");
        }
        string getJsonString()
        {
            var str = txtJson.Text;
            if (str.StartsWith("\""))
                return Newtonsoft.Json.JsonConvert.DeserializeObject<string>(str);
            return str;
        }
        private void btnGetPro_Click(object sender, EventArgs e)
        {
            try
            {
                
                var jsonObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(getJsonString());
                txtJson.Text = jsonObj[txtPro.Text].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
