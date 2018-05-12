using UnityEngine;

public class activateWell : MonoBehaviour {

    public Light SpotLight;
    public ParticleSystem font_water;
    public GameObject exitWindow;
    public static int CrystalsTouched = 0;
    public static bool CanActivate = false;
    private bool alreadyActivated = false;

    void OnTriggerEnter()
    {
        Debug.Log("Touching Fountain!");
        if (CrystalsTouched >= 4 && alreadyActivated == false)
        {
            startQuiz.QuizNum = 21;
                        
            alreadyActivated = true;
            SpotLight.intensity = 1;
            var water = font_water.emission;
            CrystalsTouched = 0;
            water.enabled = true;
            exitWindow.SetActive(true);
        }
    }
}
