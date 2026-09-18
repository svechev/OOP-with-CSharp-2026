using BankLibraryUI;
using Microsoft.Win32;
using Problem1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CreditInquiry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileStream input; // maintains the connection to the file
        private StreamReader fileReader; // reads data from text file
        private Record[] records;

        // name of file that stores credit, debit and zero balances
        private string fileName;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // TODO create XML file with sample data

            // loads records on File open
            var fileWithoutXML = File.ReadAllText(fileName); // reads xml serialized
            records = XMLutils.XmlDeserializeFromString<Record[]>(fileWithoutXML);
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            // create dialog box enabling user to open file         
            bool? result;

            OpenFileDialog fileChooser = new OpenFileDialog();
            fileChooser.InitialDirectory = System.Environment.CurrentDirectory;
            result = fileChooser.ShowDialog();
            fileName = fileChooser.FileName;

            // end using

            // exit event handler if user clicked Cancel
            if (result.HasValue)
            {
                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    //// create FileStream to obtain read access to file
                    //input = new FileStream(fileName,
                    //   FileMode.Open, FileAccess.Read);

                    //// set file from where data is read
                    //fileReader = new StreamReader(input);
                    LoadData();

                    // enable all GUI buttons, except for Open File button
                    BtnOpenFile.IsEnabled = false;
                    BtnCreditBalances.IsEnabled = true;
                    BtnDebitBalances.IsEnabled = true;
                    BtnZeroBalances.IsEnabled = true;
                } // end else
            } // end if
        }

        // invoked when user clicks credit balances,
        // debit balances or zero balances button
        private void GetBalances_Click(object sender, RoutedEventArgs e)
        {
            // delegate used to check a balance against a certain condition
            Func<decimal, bool> balanceChooser;

            // convert sender explicitly to object of type button
            Button senderButton = (Button)sender;

            // determine the condition the account balances must satisfy
            switch (senderButton.Content)
            {
                case "Credit Balances":  // positive balances
                    balanceChooser = balance => balance > 0M;
                    break;
                case "Debit Balances": // negative balances
                    balanceChooser = balance => balance < 0M;
                    break;
                default: // zero balances
                    balanceChooser = balance => balance == 0;
                    break;
            } // end switch

            // read and display file information
            try
            {
                TxtOutput.Text = "The accounts are:\n";

                // select records that match account type
                var balanceQuery =
                   from line in records
                       // let record = line.Split(',') as string[]
                   where balanceChooser(Convert.ToDecimal(line.Balance))
                   select line;

                // display each selected Record 
                foreach (var creditRecord in balanceQuery)
                {
                    // display the Record's information in the RichTextBox
                    TxtOutput.AppendText(
                       String.Format("{0}\t{1}\t{2}\n", creditRecord.Account,
                       creditRecord.FirstName, creditRecord.LastName));
                } // end foreach
            } // end try
              // handle exception when file cannot be read
            catch (IOException)
            {
                MessageBox.Show("Cannot Read File", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            } // end catch
        } // end method GetBalances_Click

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            // close file and StreamReader
            try
            {
                // close StreamReader and underlying file
                fileReader?.Close();
            } // end try
              // handle exception if FileStream does not exist
            catch (IOException)
            {
                // notify user of error closing file
                MessageBox.Show("Cannot close file", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            } // end catch


            System.Environment.Exit(0);
        }
    }
    // static class containing extension methods for class StreamReader
    public static class StreamReaderExtensions
    {
        // iterate over each line in a file
        public static IEnumerable<string> Lines(this StreamReader source)
        {
            // check for null reference
            if (source == null)
                throw new ArgumentNullException("StreamReader is null");

            // start at the beginning of the file
            source.BaseStream.Seek(0, SeekOrigin.Begin);

            string line; // a line of text

            // while there are lines left in the file
            while ((line = source.ReadLine()) != null)
            {
                yield return line; // return one line of the file as a string
            } // end while
        } // end extension method Lines
    } // end static class StreamReaderExtensions
}
