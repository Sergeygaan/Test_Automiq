using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkFiles;
using Sorting;


namespace SortObjects
{
    public partial class MainForm : Form
    {
        private string _stringInput;
        private string _stringCondition;
        private string _stringOut;

        private WorkOpenFileDialog _worckFileClass;
        private SortingScales _sortingClass;

        private Dictionary<char, int> _weightLetter = new Dictionary<char, int>();

        public MainForm()
        {
            InitializeComponent();
            _worckFileClass = new WorkOpenFileDialog();
            _sortingClass = new SortingScales();
        }

        private void DownloadFile(object sender, EventArgs e)
        {
            try
            {
                _stringInput = _worckFileClass.ReadFile();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            PrintList(_stringInput, Input);
                     
        }

        private void Sort(object sender, EventArgs e)
        {
            try
            {
                _stringOut = _sortingClass.SortData(_stringInput, _weightLetter);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            PrintList(_stringOut, Output);
        }

        private void SaveFile(object sender, EventArgs e)
        {

            _worckFileClass.WriteFile(_stringOut);
        }

        private void LoadRelations(object sender, EventArgs e)
        {
            string CheckStringCondition;
            _stringCondition = " ";

            try
            {
                CheckStringCondition = _worckFileClass.ReadFile();
                _sortingClass.ParsingString(CheckStringCondition, _weightLetter);
                _stringCondition = CheckStringCondition;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            PrintList(_stringCondition, Convention);
        }

        public void PrintList(string stringPrint, ListBox listBoxPrint)
        {
            listBoxPrint.Items.Clear();

            if (stringPrint != null)
            {
                listBoxPrint.Items.Add(stringPrint);
             }
               
            
        }


    }
}
