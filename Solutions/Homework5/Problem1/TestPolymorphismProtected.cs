namespace Problem1
{
    public class TestPolymorphismProtected
    {
        public static void Main()
        {
            TextBox[] textBoxes = [
                new EditTextBox(),
                new RichTextBox(),
                new MultiLineTextBox()
                ];
            foreach ( var textBox in textBoxes )
            {
                // We are in class TestPolymorhismProtected,
                // which neither TextBox nor derived from TextBox
                // so "protected" does not allow to call it here 

                // textBox.TypeText();
              
                
            }
            
        }
    }
}