using UnityEngine;

public class activateWell : MonoBehaviour {

    public Light SpotLight;
    public ParticleSystem font_water;
    public GameObject exitWindow;
    public static int CrystalsTouched = 0;
    public static bool CanActivate = false;
    private bool alreadyActivated = false;
    public static Light SpotL;
    public static ParticleSystem fnt_wtr;

    public void Start()
    {
        SpotL = SpotLight;
        fnt_wtr = font_water;
    }
    void OnTriggerEnter()
    {
        Debug.Log("Touching Fountain!");
        if (CrystalsTouched >= 4 && alreadyActivated == false)
        {
            startQuiz.QuizNum = 21;          
            alreadyActivated = true;
            exitWindow.SetActive(true);
        }
    }

    public static void ActivateLight()
    {
        SpotL.intensity = 1;
        var water = fnt_wtr.emission;
        CrystalsTouched = 0;
        water.enabled = true;
    }
}
