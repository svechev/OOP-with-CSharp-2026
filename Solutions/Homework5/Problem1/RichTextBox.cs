using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class RichTextBox : TextBox
    {
        #region Data Members
        new protected string text;
        #endregion

        #region Constructors
        public RichTextBox() : base()
        {
            text = $"{(GetType())}:Type text";
        }
        #endregion

        #region Methods
        protected override void TypeText()
        {
            Console.WriteLine($"text: {text}");
        }

        public override void EditTextAllowed()
        {
            base.TypeText();
            Console.WriteLine($"base.text: {base.text}");
            Console.WriteLine($"base.baseText: {base.baseText}");
        }

        public override void EditTextDisllowed()
        {
            TextBox textBox = new RichTextBox();

            // Polymorphism is checked at runtime,
            // this is a problem about access, checked by the compiler.
            // "protected" means the method/data member can be accessed
            // by a reference whose compile type is the current class
            // or a class derived from it.
            // In this case the reference is from type TextBox
            // and cannot access data from the current class because
            // TextBox is not derived from the current class (but the opposite)

            //textBox.TypeText();
            //textBox.text = "newText";
            //textBox.baseText = "newBasetext";
        }
        #endregion
    }
}
