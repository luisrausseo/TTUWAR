using UnityEngine;

public class changeSunPosition : MonoBehaviour {

    public Light Sun;
	
	void Update () {
        var hour = System.DateTime.Now.Hour;
        Sun.transform.localRotation = Quaternion.Euler(15 * hour - 90, 90, 0);
    }
}
