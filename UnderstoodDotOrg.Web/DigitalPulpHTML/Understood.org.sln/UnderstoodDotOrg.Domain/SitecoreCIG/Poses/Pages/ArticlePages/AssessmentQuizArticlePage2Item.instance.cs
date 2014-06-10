using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class AssessmentQuizArticlePage2Item 
{
    public static IEnumerable<QuizQuestionItem> GetAllQuestions(AssessmentQuizArticlePage2Item CurrentQuiz2)
    {
        IEnumerable<QuizQuestionItem> AllSlideItems = CurrentQuiz2.AllQuestions;
        return AllSlideItems;
    }
    private IEnumerable<QuizQuestionItem> _allQs;
    private IEnumerable<QuizQuestionItem> AllQuestions
    {
        get
        {
            if (_allQs == null)
            {
                _allQs = this.InnerItem.GetChildren()
               .Where(t => t.TemplateID.ToString() == QuizQuestionItem.TemplateId.ToString())
               .Select(x => new QuizQuestionItem(x));
            }
            return _allQs;
        }
    }
    public static List<Item> GetQuestionAndAnswer(AssessmentQuizArticlePage2Item ObjAssesmentQuizPage2, string AnswerText)
    {
        List<Item> _QnAID = new List<Item>(2);
        IEnumerable<QuizQuestionItem> AllQs = ObjAssesmentQuizPage2.AllQuestions;
        if (AllQs != null)
        {
            foreach (QuizQuestionItem q in AllQs)
            {
                IEnumerable<QuizAnswersItem> AllAs = QuizQuestionItem.GetAllAnswers(q);
                if (AllAs != null)
                {
                    foreach (QuizAnswersItem a in AllAs)
                    {
                        if (a.Answer == AnswerText)
                        {
                            _QnAID.Add(q.InnerItem);
                            _QnAID.Add(a.InnerItem);


                        }
                    }
                }
            }

        }
        return _QnAID;
    }
}
}