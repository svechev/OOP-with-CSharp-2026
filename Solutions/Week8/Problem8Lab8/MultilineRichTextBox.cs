using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8Lab8
{
    public class MultilineRichTextBox : RichTextBox
    {
        protected override void Undo()
        {
            Console.WriteLine($"{(GetType())}.Undo");
        }

        public void PolyTest()
        {
            MultilineRichTextBox t1 = new MultilineRichTextBox();
            RichTextBox t2 = new RichTextBox();
            TextBox t3 = new TextBox();
            IUndoable[] boxes = [t1, t2, t3];
            foreach (var box in boxes)
            {
                box.Undo();
            }
        }

        private static void Main()
        {
            var box = new MultilineRichTextBox();
            box.PolyTest();
        }
    }
}
