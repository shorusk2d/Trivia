using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Trivia
{
    class TriviaAPI
    {
        public Result LoadQuestion()
        {
            try
            {
                WebRequest a = WebRequest.Create(Properties.Settings.Default.apistring);
                WebResponse b = a.GetResponse();
                string c = string.Empty;
                using (StreamReader read = new StreamReader(b.GetResponseStream()))
                    c = read.ReadToEnd();
                return JsonConvert.DeserializeObject<Result>(c);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }

    public class Result
    {
        public int response_code;
        public Question[] results;
    }

    public class Question
    {
        public string question;
        public string correct_answer;
    }
}
