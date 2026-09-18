using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8Lab8
{
    public class TextBox : IUndoable
    {
        void IUndoable.Undo()
        {
            this.Undo();
        }

        protected virtual void Undo() {
            Console.WriteLine($"{(GetType())}.Undo");
        } 


    }
}
