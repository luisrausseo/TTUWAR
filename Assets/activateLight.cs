using UnityEngine;

public class activateLight : MonoBehaviour {

    public Light SpotLight;

    void OnTriggerEnter()
    {
        Debug.Log("Touching Crystal!");
        if (SpotLight.intensity == 0)
        {
            SpotLight.intensity = 1;
            activateWell.CrystalsTouched++;
        }
    }
}
