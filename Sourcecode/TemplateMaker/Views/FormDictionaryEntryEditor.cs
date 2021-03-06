using System.Collections.Generic;
using System.Windows.Forms;
using TemplateProcessor.Helpers.SmartString;
using TemplateProcessor.Helpers.SmartString.Models;

namespace TemplateMaker.Viewer.Views
{
    public partial class FormDictionaryEntryEditor : Form
    {
        public bool Continue = false;
        private List<Word> Words;
        private string Word;

        public FormDictionaryEntryEditor(string word)
        {
            InitializeComponent();
            Word = word;
            textBoxWordOriginal.Text = Word;
        }

        private void InputToWord(TextBox inputWord, CheckBox checkBoxAllowUpperCase)
        {
            if (!string.IsNullOrEmpty(inputWord.Text))
                Words.Add(new Word
                {
                    Value = inputWord.Text,
                    AllowMultipleUpperCase = checkBoxAllowUpperCase.Checked
                });
        }

        private void buttonSaveAndNext_Click(object sender, System.EventArgs e)
        {
            Continue = true;
            Words = new List<Word>();
            InputToWord(textBoxWord1, checkBoxAllowUpperCase1);
            InputToWord(textBoxWord2, checkBoxAllowUpperCase2);
            InputToWord(textBoxWord3, checkBoxAllowUpperCase3);
            InputToWord(textBoxWord4, checkBoxAllowUpperCase4);
            InputToWord(textBoxWord5, checkBoxAllowUpperCase5);
            SmartStringDictionary.AddWords(Words, saveToFile: true);
        }
    }
}
