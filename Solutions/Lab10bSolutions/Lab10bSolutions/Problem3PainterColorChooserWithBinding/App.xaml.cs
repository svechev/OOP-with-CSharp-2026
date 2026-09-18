using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace ColorChooserPainterWithBinding
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
        public Brush BrushColor { get; set; } = Brushes.Black;
        
    }
}
