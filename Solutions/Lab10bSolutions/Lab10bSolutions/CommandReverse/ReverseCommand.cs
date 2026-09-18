using Microsoft.Windows.Themes;
using System;
using System.Windows.Input;    // Required

namespace CommandReverse
{
    public class ReverseCommand
    {
        private static RoutedUICommand reverse;
         
        public static RoutedUICommand Reverse
        {
            get { return reverse; }
        }
         
        static ReverseCommand()
        {
            InputGestureCollection gestures = new();
            gestures.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Control-R"));
            // The first parameter is the text that appears on the button, menu item, etc. that uses this command.
            reverse = new RoutedUICommand("Reverse", "Reverse", typeof(ReverseCommand), gestures);
        }
 
    }
    public class ReverseBackgroundCommand
    {
        
        private static RoutedUICommand reverseBackground;

         
        public static RoutedUICommand ReverseBackground
        {
            get { return reverseBackground; }
        }
 
        static ReverseBackgroundCommand()
        {
            InputGestureCollection gestures = new();
            gestures.Add(new KeyGesture(Key.B, ModifierKeys.Control, "Control-B"));
            // The first parameter is the text that appears on the button, menu item, etc. that uses this command.
            reverseBackground = new RoutedUICommand("Reverse Background", "ReverseBackground", typeof(ReverseCommand), gestures);
        }
    }
}
