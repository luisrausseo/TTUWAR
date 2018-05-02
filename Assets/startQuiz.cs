using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    public AudioSource QuizBGM;
    private int question;
    private int HowManyQuestions = 2;
    private int HowManyLifes = 3;
    private string[] correctAnswers_str;
    private Text[] TextOpt;
    public static int QuizNum;

    // Use this for initialization
    private void Start()
    {
        TextOpt = new Text[] { optA, optB, optC, optD };
        question = 0;
    }

    // Manages the questions that will be shown
    private void loadQuestion()
    {   
        //QuizNum is modified when a target is detected using the Vuforia Camera. 
        switch (QuizNum)
        {
            //Pfluger Fountain
            case 1: 
                {
                    correctAnswers_str = new string[] { "1", "2" };
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
                    break;
                }

            //Headwaters
            case 2:
                {
                    correctAnswers_str = new string[] { "1", "3" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "What is the name of the water feature between English/Philosophy and the College of Education?";
                                optA.text = "A.	Fountain of Knowledge";
                                optB.text = "B.	Headwaters";
                                optC.text = "C.	Education Journey";
                                optD.text = "D.	Water Play";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "What is supposed to mean the water pouring over the fountain at the Headwater?";
                                optA.text = "A.	Thirst for knowledge";
                                optB.text = "B.	Nurturing new ideas";
                                optC.text = "C.	Life’s Journey";
                                optD.text = "D.	Sounds that letters create";
                                break;
                            }
                    }
                    break;
                }

            //Monitoring well
            case 3: 
                {
                    correctAnswers_str = new string[] { "0", "2" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "Which statement is not true about monitoring well?";
                                optA.text = "A.	The monitoring well cannot be used for monitoring the effects of pollution of the groundwater";
                                optB.text = "B.	The groundwater level at that monitoring point will change due to seasonal variations";
                                optC.text = "C.	A monitoring well consists of a small diameter borehole tube";
                                optD.text = "D.	Monitoring wells are bored and used for level monitoring";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "Which role does not perform the of Monitoring well?";
                                optA.text = "A.	Level monitoring of groundwater";
                                optB.text = "B.	Water quality analysis";
                                optC.text = "C.	Monitoring the tidal current";
                                optD.text = "D. Monitoring the effects of pollution of the groundwate";
                                break;
                            }
                    }
                    break;
                }

            //Pipes coming out of the Civil Engineering Building
            case 4: 
                {
                    correctAnswers_str = new string[] { "1", "2" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "Pipe is made out of many types of material, except...";
                                optA.text = "A.	Concrete";
                                optB.text = "B.	Paper";
                                optC.text = "C.	Glass";
                                optD.text = "D.	Plastic";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "Which standards is a certified for Concrete Pipe?";
                                optA.text = "A.	ASTM D3033/3034";
                                optB.text = "B.	ASTM A312";
                                optC.text = "C.	ASTM C76";
                                optD.text = "D. ASTM A795";
                                break;
                            }
                    }
                    break;
                }

            //Manhole (sewer) at Lot R14 in front of the Civil Engineering Building
            case 5: 
                {
                    correctAnswers_str = new string[] { "3", "0" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "Which structure is not a composition of Manhole?";
                                optA.text = "A.	Flow inverts";
                                optB.text = "B.	Manhole cover";
                                optC.text = "C.	Flumes";
                                optD.text = "D.	Beam";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "Which material is usually not outfit for manholes?";
                                optA.text = "A.	Wood";
                                optB.text = "B.	Metal";
                                optC.text = "C.	Polypropylene";
                                optD.text = "D. Fiberglass steps";
                                break;
                            }
                    }
                    break;
                }

            //Fountain at entrance
            case 6:
                {
                    correctAnswers_str = new string[] { "1", "1" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "What is the main purpose of Splash fountains?";
                                optA.text = "A.	Decoration";
                                optB.text = "B.	Cool down the heat";
                                optC.text = "C.	Drinking";
                                optD.text = "D.	Cleaning";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "What is not true about fountains before the 19th century?";
                                optA.text = "A.	Required water source to be higher";
                                optB.text = "B.	Can not be used for washing clothes";
                                optC.text = "C.	Operated by gravity";
                                optD.text = "D. The fountain normally ran continually";
                                break;
                            }
                    }
                    break;
                }

            //Fountain in the Holden Hall
            case 7: 
                {
                    correctAnswers_str = new string[] { "2", "1" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "Which fountain is not in the Baroque Fountains of Rome?";
                                optA.text = "A.	Fontana di Trevi";
                                optB.text = "B.	Triton Fountain";
                                optC.text = "C.	Fontana Masini";
                                optD.text = "D.	Piazza Navona";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "Which is the tallest fountains in the World?";
                                optA.text = "A.	The World Cup Fountain (2002) in the Han-gang River in Seoul, Korea";
                                optB.text = "B.	King Fahd's Fountain (1985) in Jeddah, Saudi Arabia";
                                optC.text = "C.	The Gateway Geyser (1995), next to the Mississippi River in St. Louis, Missouri";
                                optD.text = "D. Port Fountain (2006) in Karachi, Pakistan";
                                break;
                            }
                    }
                    break;
                }

            //Fountain-1 at the library
            case 8:
                {
                    correctAnswers_str = new string[] { "0", "1" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "When is the oldest evidence of human-made fountains?";
                                optA.text = "A.	2000 BC";
                                optB.text = "B.	10000 BC";
                                optC.text = "C.	6th century BC";
                                optD.text = "D.	5000 BC";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "What material Ancient Romans used for pipes when building fountains?";
                                optA.text = "A.	Bronze";
                                optB.text = "B.	Lead";
                                optC.text = "C.	Silver";
                                optD.text = "D. Gold";
                                break;
                            }
                    }
                    break;
                }

            //Pond at Urbanovsky Park, Flint Avenue
            case 9:
                {
                    correctAnswers_str = new string[] { "3", "1" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "Over time, sometimes hundreds of years, ponds can change into...";
                                optA.text = "A.	Marshes";
                                optB.text = "B.	Swamps";
                                optC.text = "C.	Land";
                                optD.text = "D.	All correct";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "In very cold places, how ponds freeze solid?";
                                optA.text = "A.	Bottom to top";
                                optB.text = "B.	Top to bottom";
                                optC.text = "C.	Instantly all together";
                                optD.text = "D. Deepest to shallowest";
                                break;
                            }
                    }
                    break;
                }

            //Drain pipe coming out of Flint garage
            case 10:
                {
                    correctAnswers_str = new string[] { "1", "3" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "Which choice is not key advantage of cast iron pipes?";
                                optA.text = "A.	Durability";
                                optB.text = "B.	Low cost";
                                optC.text = "C.	Fire-resistance";
                                optD.text = "D.	Reduces noise";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "Which choice is not disadvantage of clay pipes?";
                                optA.text = "A.	Susceptible to tree root";
                                optB.text = "B.	Very heavy and hard to cut";
                                optC.text = "C.	Can not use for sanitary drainage";
                                optD.text = "D. Will not find it in your neighborhood home improvement store";
                                break;
                            }
                    }
                    break;
                }
        }
    
    }
    
    // Starts quiz
    public void GoToQuiz()
    {
        QuizBGM.Play();
        loadQuestion();
        QuizWindow.SetActive(true);
    }

    // Handles the progress of the quiz
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
                QuizBGM.Stop();
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
                QuizBGM.Stop();
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
