// Exercise 16.8 Solution: ColorChooserPainter.xaml.cs
// Painter application with a color chooser (code-behind).
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using System;

namespace ColorChooserPainter
{
    public partial class ColorChooserPainterWindow : Window
    {  
        // constructor
        public ColorChooserPainterWindow()
        {
            InitializeComponent();
            colorLabel.Background = brushColor; // initial color
        } // end constructor

        private int diameter = 8;
        private Brush brushColor = Brushes.Black;
        private bool shouldErase = false;
        private bool shouldPaint = false;
        private Point startLine;
        private Point endLine;
        private enum Sizes
        {
            SMALL = 4,
            MEDIUM = 8,
            LARGE = 10
        } // end enum

        private void PaintCircle(Brush circleColor, Point position)
        {
            Ellipse newEllipse = new Ellipse();

            newEllipse.Fill = circleColor;
            newEllipse.Width = diameter;
            newEllipse.Height = diameter;

            Canvas.SetTop(newEllipse, position.Y);
            Canvas.SetLeft(newEllipse, position.X);

            paintCanvas.Children.Add(newEllipse);
        } // end method PaintCircle

        private void PaintLine()
        {
            if (Math.Abs(startLine.X - endLine.X) < diameter
                && Math.Abs(startLine.Y - endLine.Y) < diameter)
            {  // draw only lines longer than the  cap
                return;
            }
            Line newLine = new Line();
            newLine.X1 = startLine.X;
            newLine.Y1 = startLine.Y;
            newLine.X2 = endLine.X;
            newLine.Y2 = endLine.Y;
            newLine.Fill = brushColor;
            // Set Line's width and color  
            newLine.StrokeThickness = diameter;
            newLine.Stroke = brushColor;
            newLine.StrokeStartLineCap = PenLineCap.Round;
            newLine.StrokeEndLineCap = PenLineCap.Round;

            // Add line to the Grid.  
            paintCanvas.Children.Add(newLine);
            startLine = endLine;
        } // end method PaintCircle
        private void PaintCanvas_MouseLeftButtonDown(
         object sender, MouseButtonEventArgs e)
        {
            shouldPaint = true;
            startLine = e.GetPosition(paintCanvas);
        } // end method paintCanvas_MouseLeftButtonDown

        private void PaintCanvas_MouseLeftButtonUp(
           object sender, MouseButtonEventArgs e)
        {
            shouldPaint = false;
        } // end method paintCanvas_MouseLeftButtonUp

        private void PaintCanvas_MouseMove(
           object sender, MouseEventArgs e)
        {
            if (shouldPaint == true)
            {
                endLine = e.GetPosition(paintCanvas);
                PaintLine();
            } // end if
            else if (shouldErase == true)
            {
                Point mousePosition = e.GetPosition(paintCanvas);
                PaintCircle(paintCanvas.Background, mousePosition);
            } // end else if
        } // end method paintCanvas_MouseMove

        private void PaintCanvas_MouseRightButtonDown(
           object sender, MouseButtonEventArgs e)
        {
            shouldErase = true;
        } // end method paintCanvas_MouseRightButtonDown

        private void PaintCanvas_MouseRightButtonUp(
           object sender, MouseButtonEventArgs e)
        {
            shouldErase = false;
        } // end method paintCanvas_MouseRightButtonUp

        private void SmallRadioButton_Checked(
           object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.SMALL;
        } // end method smallRadioButton_Checked

        private void MediumRadioButton_Checked(
           object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.MEDIUM;
        } // end method mediumRadioButton_Checked

        private void LargeRadioButton_Checked(
           object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.LARGE;
        } // end method largeRadioButton_Checked

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (paintCanvas.Children.Count > 0)
            {

                paintCanvas.Children.RemoveAt(
                   paintCanvas.Children.Count - 1);

            } // end if
        } // end method undoButton_Click

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            paintCanvas.Children.Clear();
        } // end method clearButton_Click

        // Slider ValueChanged handler !!!!
        private void Slider_ValueChanged(
           object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // generate new color
            SolidColorBrush backgroundColor = new SolidColorBrush();
            backgroundColor.Color = Color.FromArgb(
               (byte)alphaSlider.Value, (byte)redSlider.Value,
               (byte)greenSlider.Value, (byte)blueSlider.Value);

            colorLabel.Background = backgroundColor; // display new color
            brushColor = backgroundColor; // use new color as brush color
        } // end method slider_ValueChanged
    } // end class ColorChooserPainterWindow
} // end namespace ColorChooserPainter
