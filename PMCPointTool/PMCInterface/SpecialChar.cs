using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    /// <summary>
    /// 报警接口中的特殊字符类
    /// </summary>
    public class SpecialChar
    {
        public List<string> specialChars = new List<string>();
        public List<string> SpecialChars
        {
            get { return specialChars; }
            set { specialChars = value; }
        }
        public SpecialChar()
        {
            this.specialChars.Add("%");
            //this.specialChars.Add("#");
            this.specialChars.Add("$");
            //this.specialChars.Add("&");
            this.specialChars.Add(@"\n");
            this.specialChars.Add("{Tab}");
        }
    }
}
