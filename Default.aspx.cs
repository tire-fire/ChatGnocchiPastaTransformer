using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatGnocchiPastaTransformer
{
    public partial class Default : Page
    {
        private List<string> history = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack || Session["history"] == null)
            {
                Session["history"] = history;
            }
            else
            {
                history = (List<string>)Session["history"];
            }
        }

        protected void AskButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string question = QuestionTextBox.Text;
            string answer = Global.bot.GenerateResponse(question);
            history.Add($"Q: {question}<br/>A: {answer}");

            // Clear the TextBox after the question is asked
            QuestionTextBox.Text = string.Empty;

            Session["history"] = history;
            DisplayHistory();
        }

        private void DisplayHistory()
        {
            HistoryPanel.Controls.Clear();

            var history = (List<string>)Session["history"];
            foreach (string entry in history)
            {
                HistoryPanel.Controls.Add(new Literal { Text = $"<div class='question'>{entry}</div>" });
            }
        }
    }
}