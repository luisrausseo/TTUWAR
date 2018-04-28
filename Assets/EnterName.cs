using UnityEngine;
using Facebook.Unity;

public class EnterName : MonoBehaviour {

    public void OnSubmit()
    {
        FB.API("/me?fields=first_name", HttpMethod.GET, add_Score);
    }

    void add_Score(IResult result)
    {
        Highscores.AddNewHighscore((string)result.ResultDictionary["first_name"], PlayerPrefs.GetInt("player_score"));
    }
}
