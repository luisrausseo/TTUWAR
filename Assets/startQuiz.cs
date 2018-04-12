using UnityEngine;
using UnityEngine.UI;

public class startQuiz : MonoBehaviour {

    public GameObject QuizWindow;
    public Text questionText;
    public Text optA;
    public Text optB;
    public Text optC;
    public Text optD;
    public GameObject DoneBttn;
    private int question;
    private int HowManyQuestions = 2;
    private int[] correctAnswers = new int[] { 1, 2 };
    private Text[] TextOpt;
    

    // Use this for initialization
    private void Start()
    {
        TextOpt = new Text[] { optA, optB, optC, optD };
        question = 0;
        loadQuestion();
        
    }

    private void loadQuestion()
    {
        switch (question)
        {
            case 0:
                {
                    questionText.text = "Which is the name of the water feature located in the center of the Memorial Circle?";
                    optA.text = "A.	Preston Scott Fountain";
                    optB.text = "B.	Pfluger Fountain";
                    optC.text = "C.	Curry Holden Fountain";
                    optD.text = "D.	James Marion West, Sr. Fountain";
                    break;
                }
            case 1:
                {
                    questionText.text = "In which year the Pfluger Fountain was added to the Memorial Circle?";
                    optA.text = "A.	1948";
                    optB.text = "B.	1997";
                    optC.text = "C.	2002";
                    optD.text = "D.	2014";
                    break;
                }
        }
    }
    
    public void GoToQuiz()
    {
        QuizWindow.SetActive(true);
    }

    public void isCorrect(int option)
    {
        if (correctAnswers[question] == option)
        {
            question++;
            ScoreManager.AddScore(5);
            if (question < HowManyQuestions)
            {
                loadQuestion();
            }
            else
            {
                questionText.text = "Congratulations!";
                optA.text = "";
                optB.text = "";
                optC.text = "";
                optD.text = "";
                DoneBttn.SetActive(true);
            }
        }
        else
        {
            questionText.text = "Incorrect, try again!";
        }
    }
}
