using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGUI : MonoBehaviour {

    public GameObject MenuGUI;

    public void showWindow()
    {
        MenuGUI.SetActive(true);
    }

    public void closeWindow()
    {
        MenuGUI.SetActive(false);
    }

}
