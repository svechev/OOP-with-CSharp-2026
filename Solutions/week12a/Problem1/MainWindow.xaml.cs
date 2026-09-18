using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Sources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Problem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Serializable] // important
        public readonly record struct Student(string FirstName, string LastName, string ID, string CourseName, int Grade);
        
        public MainWindow()
        {
            InitializeComponent();
            TestXMLSerializeDeserialize();
        }

        public void TestXMLSerializeDeserialize()
        {

            // Serialize students to XML
            Student[] students = [new Student("Momiji", "Hozuki", "1", "Intro to CS", 95),
                                  new Student("Petar", "Petrov", "2", "OOP", 55),
                                  new Student("Mahiro", "Oyama", "3", "Mathematics", 99)];

            //var studentsXML = XMLutils.XmlSerializeToString(students);
            //txtOutput.Text = studentsXML;
            //MessageBox.Show(studentsXML);

            // Write to file
            //var fcJSON = new SaveFileDialog()
            //{
            //    InitialDirectory = Environment.CurrentDirectory
            //};
            //fcJSON.ShowDialog();
            //var filenameJSON = fcJSON.FileName ?? "students.xml";
            //if (filenameJSON == "") filenameJSON = "students.xml";
            //File.WriteAllText(filenameJSON, studentsXML);


            // Deserialize students from XML
            //var fcoJSON = new OpenFileDialog()
            //{
            //    InitialDirectory = Environment.CurrentDirectory
            //};
            //fcoJSON.ShowDialog();

            //var fileWithXML = fcJSON.FileName ?? "students.xml";

            //var fileWithoutXML = File.ReadAllText(fileWithXML);
            //var studentsFromXML = XMLutils.XmlDeserializeFromString<Student[]>(fileWithoutXML);
            //txtOutput.AppendText( "\n" + string.Join("\n", studentsFromXML.Select(st => st)));


            // Serialize to JSON
            Student[] students2 = [new Student("Momiji", "Hozuki", "1", "Intro to CS", 95),
                                  new Student("Petar", "Petrov", "2", "OOP", 55),
                                  new Student("Mahiro", "Oyama", "3", "Mathematics", 99)];

            var studentsJSON = XMLutils.JSONSerializeToString(students);
            txtOutput.Text = studentsJSON;
            //MessageBox.Show(studentsXML);

            // Write to file
            var fcJSON = new SaveFileDialog()
            {
                InitialDirectory = Environment.CurrentDirectory
            };
            fcJSON.ShowDialog();
            var filenameJSON = fcJSON.FileName ?? "students.json";
            if (filenameJSON == "") filenameJSON = "students.json";
            File.WriteAllText(filenameJSON, studentsJSON);

            // Deserialize students from JSON
            var fcoJSON = new OpenFileDialog()
            {
                InitialDirectory = Environment.CurrentDirectory
            };
            fcoJSON.ShowDialog();

            var fileWithJSON = fcJSON.FileName ?? "students.json";

            var fileWithoutJSON = File.ReadAllText(fileWithJSON);
            var studentsFromJSON = XMLutils.JSONDeserializeFromString<Student[]>(fileWithoutJSON);
            txtOutput.AppendText( "\n" + string.Join("\n", studentsFromJSON.Select(st => st)));
        }
    }
}