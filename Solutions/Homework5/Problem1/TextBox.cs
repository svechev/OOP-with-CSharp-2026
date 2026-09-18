using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public abstract class TextBox
    {
        #region Data Members
        protected string baseText;
        protected string text;
        #endregion

        #region Constructors
        public TextBox()
        {
            baseText = $"{(GetType())}:Type baseText";
            text = $"{(GetType())}:Type text";
        }
        #endregion

        #region Methods
        protected virtual void TypeText()
        {
            Console.WriteLine($"text: {text}");
        }

        public abstract void EditTextAllowed();

        public abstract void EditTextDisllowed();
        #endregion
    }
}
