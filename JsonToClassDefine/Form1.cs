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
            var jsonObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(txtJson.Text);
            List<StringBuilder> classList = new List<StringBuilder>();
            txtClass.Text = "";
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
                else if (pro.Value.Type == Newtonsoft.Json.Linq.JTokenType.Array)
                {
                    Newtonsoft.Json.Linq.JArray array = (Newtonsoft.Json.Linq.JArray)pro.Value;
                   if( array.Count > 0 && array[0].Type == Newtonsoft.Json.Linq.JTokenType.Object )
                    {
                        string myName = name[0].ToString().ToUpper() + name.Substring(1);
                        resultStr.Append(className + "_" + myName + "[] ");
                        parseJson((Newtonsoft.Json.Linq.JObject)array[0], classList, className + "_" + myName);
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

        private void btnGetPro_Click(object sender, EventArgs e)
        {
            var jsonObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(txtJson.Text);
            txtJson.Text = jsonObj.Value<string>(txtPro.Text);
        }
    }
}
