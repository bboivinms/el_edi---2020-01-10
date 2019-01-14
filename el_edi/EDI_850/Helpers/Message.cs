using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_850.Helpers
{
    public class Message
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public Severity Severity { get; set; }

        public Scope Scope { get; set; }
    }

    public enum Severity
    {
        Warning,
        Critical
    }

    public enum Scope
    {
        Internal,
        Customer
    }


}
