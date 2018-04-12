using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]

    private static int score;
    public Text scoreText;

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

