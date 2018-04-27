using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class startQuiz : MonoBehaviour {

    public GameObject QuizWindow;
    public Text questionText;
    public Text optA;
    public Text optB;
    public Text optC;
    public Text optD;
    public ToggleGroup QuizToggle;
    public GameObject DoneBttn;
    public GameObject SubmitBttn;
    public GameObject LearnBttn;
    public GameObject Toggles;
    public GameObject[] Lifes = new GameObject[] {};
    public AudioSource wrongAnswer;
    public AudioSource gameOver;
    public AudioSource correct;
    public AudioSource WonGame;
    private int question;
    private int HowManyQuestions = 2;
    private int HowManyLifes = 3;
    private string[] correctAnswers_str = new string[] { "1", "2" };
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

    public void submitAnswer()
    {
        if (QuizToggle.ActiveToggles().FirstOrDefault().name == correctAnswers_str[question])
        {
            Debug.Log("Correct!");
            correct.Play();
            question++;
            ScoreManager.AddScore(5);
            if (question < HowManyQuestions)
            {
                loadQuestion();
                QuizToggle.SetAllTogglesOff();
            }
            else
            {
                WonGame.Play();
                questionText.text = "Congratulations! You won the challenge...";
                SubmitBttn.SetActive(false);
                Toggles.SetActive(false);
                DoneBttn.SetActive(true);
                LearnBttn.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Incorrect!");
            HowManyLifes--;
            if (HowManyLifes > 0)
            {
                wrongAnswer.Play();
                Lifes[HowManyLifes].SetActive(false);
            }
            else
            {
                gameOver.Play();
                Lifes[HowManyLifes].SetActive(false); //Last life
                questionText.text = "You lost! Try again...";
                SubmitBttn.SetActive(false);
                Toggles.SetActive(false);
                DoneBttn.SetActive(true);
                LearnBttn.SetActive(true);
            }
        }
    }
}
