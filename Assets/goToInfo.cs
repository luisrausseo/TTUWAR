using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToInfo : MonoBehaviour {

	public void openLink()
    {
        switch (startQuiz.QuizNum)
        {
            case 1:
                {
                    //Pfluger Fountain
                    Application.OpenURL("http://statues.vanderkrogt.net/object.php?record=ustx51");
                    break;
                }
            case 2:
                {
                    //Headwaters
                    Application.OpenURL("http://judsonc72.wixsite.com/texas-tech-lcbs/headwaters-fountain");
                    break;
                }
        }
        
    }
}
