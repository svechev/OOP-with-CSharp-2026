using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandReverse
{
    class ChangeTextboxBackgroundCommand
    {
        private static RoutedUICommand backgroundChange;

        public static RoutedUICommand BackgroundChange { 
            get { return backgroundChange; }
        }

        static ChangeTextboxBackgroundCommand()
        {
            InputGestureCollection gestures = new InputGestureCollection();

            backgroundChange = new RoutedUICommand
               ("Change", "Change", typeof(ReverseCommand), gestures);
        }
    }
}
