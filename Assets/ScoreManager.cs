using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // From the inspector, drag & Drop the GameObject holding the Text component used to display the score
    [SerializeField]

    private static int score;
    public Text scoreText;

    //To add or subtract score, use
    // private ScoreManager scoreManager;
    //then
    //scoreManager.Score++;
    //scoreManager.Score--;

    void Start()
    {
        score = PlayerPrefs.GetInt("player_score");
        Debug.Log(score);
        //if (score < 0)
        //{
        //   score = 0;
        //}
        scoreText.text = "Score: " + score;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        PlayerPrefs.SetInt("player_score", score);
        scoreText.text = "Score: " + score;
    }

    public void updateScoreView()
    {
        PlayerPrefs.SetInt("player_score", score);
    }

    public static void AddScore(int NewscoreValue)
    {
        score = score + NewscoreValue;
        //updateScoreView();
        PlayerPrefs.SetInt("player_score", score);
    }


}

