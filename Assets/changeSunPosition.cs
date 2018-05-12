using UnityEngine;
using UnityEngine.UI;

public class changeSunPosition : MonoBehaviour {

    public Light Sun;
    public bool Debug;
    private float time;
    public GameObject DebugTime;
    public Text DebugClock;

    private void Start()
    {
        time = System.DateTime.Now.Hour;
    }

    private void Update () {
        var hour = 0f;

        if (Debug == false)
        {
            hour = System.DateTime.Now.Hour;
        }
        else
        {
            DebugTime.SetActive(true);   
            hour = time;
            DebugClock.text = (int) (hour % 24) + ":00";
            time = time + 0.03f;
        }

        Sun.transform.localRotation = Quaternion.Euler(15 * hour - 90, 90, 0);
    }
}
