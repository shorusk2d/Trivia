using System;
using System.ComponentModel;
using System.Net;
using System.Windows;

namespace Trivia
{
    internal class VModel : INotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
        public Command ClickedTrue { get; set; } = new Command();
        public Command ClickedFalse { get; set; } = new Command();
        TriviaAPI api = new TriviaAPI();
        Question question = new Question();
        SQL saver = new SQL();
        public VModel()
        {
            ClickedFalse.Function = OnFalse;
            ClickedTrue.Function = OnTrue;
            LoadQuestion();
        }

        private void OnTrue(object obj)
        {
            if (string.Equals(question.correct_answer, "True")) MessageBox.Show("You are right!");
            else MessageBox.Show("You are wrong!");
            LoadQuestion();
        }

        private void OnFalse(object obj)
        {
            if (string.Equals(question.correct_answer, "False")) MessageBox.Show("You are right!");
            else MessageBox.Show("You are wrong!");
            LoadQuestion();
        }
        private void LoadQuestion()
        {
            Text = string.Empty;
            Result r = api.LoadQuestion();
            if (r == null) return;
            if (r.response_code != 0)
            {
                MessageBox.Show("Something went wrong");
                return;
            }
            question = r.results[0];
            Text = WebUtility.HtmlDecode(question.question);
            saver.SaveQuestion(question);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string m)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(m));
        }
    }
}