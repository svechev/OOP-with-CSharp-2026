namespace Problem1Lab8
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello!\n");
            ProgramHelper programHelper = new ProgramHelper();
            IConvertible syntaxTool = (IConvertible)programHelper;
            Console.WriteLine("Test IConvertible explicit interface implementation:");

            Console.WriteLine(syntaxTool.ConvertToCSharp("mahiro"));
            Console.WriteLine(syntaxTool.ConvertToVB2015("mahiro"));

            Console.WriteLine("\nTest IConvertible implicit interface implementation:");

            Console.WriteLine(programHelper.ConvertToCSharp("mahiro"));
            Console.WriteLine(programHelper.ConvertToVB2015("mahiro"));


            Console.WriteLine("\nTest interface ICodeChecker:");
            ICodeChecker checkTool = (ICodeChecker)programHelper;
            Console.WriteLine(checkTool.CodeCheckSyntax("mahiro", "C#"));
            Console.WriteLine(checkTool.ConvertToCSharp("mahiro"));
            Console.WriteLine(checkTool.ConvertToVB2015("mahiro"));

            Console.WriteLine("\nTest ProgramConverter:");
            ProgramConverter programConverter = new ProgramConverter();
            IConvertible converterTool = (IConvertible)programConverter;
            Console.WriteLine(converterTool.ConvertToCSharp("mahiro"));
            Console.WriteLine(converterTool.ConvertToVB2015("mahiro"));
        }
    }
}