using UnityEngine;
using UnityEngine.UI;

public class activateLight : MonoBehaviour {

    public Light SpotLight;
    public AudioSource gotIt_sound;
    public GameObject FactWindow;
    public Text Fact;
    private int FactNum;

    void OnTriggerEnter()
    {
        Debug.Log("Touching Crystal!");
        if (SpotLight.intensity == 0)
        {
            gotIt_sound.Play();
            SpotLight.intensity = 1;
            activateWell.CrystalsTouched++;
            FactNum = int.Parse(this.name);
            switch (FactNum)
            {
                case 1:
                    Fact.text = "68.7% of the fresh water on Earth is trapped in glaciers.";
                    break;
                case 2:
                    Fact.text = "About 6,800 gallons of water is required to grow a day’s food for a family of four.";
                    break;
                case 3:
                    Fact.text = "70% of the human brain is water.";
                    break;
                case 4:
                    Fact.text = "Hot water can freeze faster than cold water under some conditions (commonly known as the Mpemba effect).";
                    break;
            }
            FactWindow.SetActive(true);
        }
    }
}
