using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    public class MyException : ApplicationException
    {
        private string error;
        private Exception innerException;
        public MyException()
        {
        }
        //带一个字符串参数的构造函数，作用：当程序员用Exception类获取异常信息而非MyException时把自定义异常信息传递过去
        public MyException(string msg)
            : base(msg)
        {
            this.error = msg;
        }
        //带有一个字符串参数和一个内部异常信息参数的构造函数
        public MyException(string msg, Exception innerException)
            : base(msg)
        {
            this.innerException = innerException;
            this.error = msg;
        }
        public string GetError()
        {
            return error;
        }
    }
}    


