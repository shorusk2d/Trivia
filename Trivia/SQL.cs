using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Trivia
{
    class SQL
    {
        public void SaveQuestion(Question q)
        {
            using (SqlConnection db = new SqlConnection(Properties.Settings.Default.sqlstring))
            {
                SqlCommand cm = new SqlCommand($"insert into Questions ([question], [correct]) values (\'{q.question}\', \'{q.correct_answer}\')", db);
                try
                {
                    db.Open();
                    cm.ExecuteNonQuery();
                    db.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
