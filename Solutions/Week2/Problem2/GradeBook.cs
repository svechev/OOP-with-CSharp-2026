// Fig. 4.12: GradeBook.cs
// GradeBook class with a constructor to initialize the course name.
using System;
using System.Diagnostics.CodeAnalysis;

namespace Problem2
{

    public class GradeBook

    {
        #region Full Property- snippet (propfull + Tab)
        private string courseName; // course name for this GradeBook
        //public string CourseName
        //{
        //    get
        //    {
        //        return courseName;
        //    } // end get
        //    set
        //    {
        //        courseName = value;
        //    } // end set
        //} // end property CourseName

        // ... shorter
        public required string CourseName
        {
            get => courseName;
            // end get
            set => courseName = value ?? "N/A";
            // end set
        } // end property CourseName

        #endregion
        #region Autoimplemented init Property- snippet (prop + Tab)
        public string CourseTerm { get; init; } = "Fall";
        // Property CourseTerm cannot be changed inside class Gradebook
        // // Property CourseTerm can  be changed outside class Gradebook with object initializer
        #endregion

        public int CourseStart => DateTime.Now.Year;  // No SETTER define



        #region Autoimplemented Property- snippet (prop + Tab)
        public string Instructor { get; set; }

        #endregion

        // constructor initializes courseName with string supplied as argument
        #region Constructor
        [SetsRequiredMembers]
        public GradeBook(string name, string instructor) {
            CourseName = name;
            Instructor = instructor;
               } // initialize courseName and instructor using property // end constructor
        #endregion 

        // property to get and set the course name


        // display a welcome message to the GradeBook user
        public void DisplayMessage()
        {
            // use property CourseName to get the 
            // name of the course that this GradeBook represents
            Console.WriteLine("Welcome to the grade book for\n{0}!",
               CourseName);

        } // end method DisplayMessage
        public (int, string) GradeBookTitle() => (CourseStart, courseName);
        public void ChangeTitle((string instructor, String cname) title)
            => (Instructor, CourseName) = (title.instructor, title.cname);
        public void Message() => Console.WriteLine($"Welcome to the grade book for\n{courseName}!");
    } // end class GradeBook
}


