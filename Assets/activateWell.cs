using UnityEngine;

public class activateWell : MonoBehaviour {

    public Light SpotLight;
    public ParticleSystem font_water;
    public GameObject exitWindow;
    public static int CrystalsTouched = 0;
    private bool alreadyActivated = false;

    void OnTriggerEnter()
    {
        Debug.Log("Touching Fountain!");
        if (CrystalsTouched >= 4 && alreadyActivated == false)
        {
            alreadyActivated = true;
            ScoreManager.AddScore(10);
            SpotLight.intensity = 1;
            var water = font_water.emission;
            CrystalsTouched = 0;
            water.enabled = true;
            exitWindow.SetActive(true);
        }
    }
}
