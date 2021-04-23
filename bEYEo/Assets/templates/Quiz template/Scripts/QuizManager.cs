using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private ScriptDataScriptTable quizData;
    [SerializeField] private List<Question> questions;
    [SerializeField] private bool shuffleQuestions;
    [SerializeField] private bool isTakeQuiz;
    [SerializeField] public static bool takeQuizTaken;
    [SerializeField] public static int takeQuizScore;
    static public int score;
    public AudioSource wrong;
    public AudioSource correct;

    private Question selectedQuestion;
    int questionIndex;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        takeQuizScore = 0;
        questions = quizData.questions;
        for (int i = 0; i < questions.Count; i++)
        {
            questions[i].resetQuestion();
        }
       
         

        SelectQuestion();
    }



    void SelectQuestion() {

        bool allQuestionsAwnsered = false;
        for (int i = 0; i < questions.Count; i++)
        {
            if (questions[i].isAnswered == false) { allQuestionsAwnsered = true; }
        }

        if (allQuestionsAwnsered)
        {
            
            int val = 0;
            if (shuffleQuestions)
            {
                do
                {

                    {
                        val = Random.Range(0, questions.Count);
                        selectedQuestion = questions[val];
                    }
                } while (selectedQuestion.isAnswered == true); ;

            }
            else {
                selectedQuestion = questions[questionIndex];

            }
            
            

            quizUI.SetQuestion(selectedQuestion);
            selectedQuestion.isAnswered = true;
            questionIndex++;
            


        }
        else {
            SceneManager.LoadScene("results");
        }
        
        
    }

    public bool Anwser(string awnsered) {

        bool correctAnswer = false;

        if (awnsered == selectedQuestion.correctAns)
        {
            //correct
            correct.Play();
            correctAnswer = true;
            score++;
            if (isTakeQuiz == true) {
                takeQuizTaken = true;
                takeQuizScore++; 
            };
        }
        else {
            //wrong
            wrong.Play();
        }

        Invoke("SelectQuestion", 0.4f);

        return correctAnswer;
    }


}




[System.Serializable]
public class Question {
    public string questionInfo;
    public QuestionType questionType;
    public Sprite questionsImg;
    public AudioClip questionClip;
    public UnityEngine.Video.VideoClip questionVideo;
    public List<string> options;
    public string correctAns;
    public bool  isAnswered = false;
    public bool audioPlayed = false;


    public void resetQuestion() {
          isAnswered = false;
          audioPlayed = false;
    }
}
[System.Serializable]
public enum QuestionType
{ 
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}