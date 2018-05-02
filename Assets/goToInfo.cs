using UnityEngine;

public class goToInfo : MonoBehaviour {

    //Opens the link provided when the player taps of the LEARN button at the end of a quiz. 
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
            case 3:
                {
                    //Monitoring well in front of the Civil Engineering Building
                    Application.OpenURL("http://en.wika.com/newscontentgeneric_ms.WIKA?AxID=461");
                    break;
                }
            case 4:
                {
                    //Pipes coming out of the Civil Engineering Building
                    Application.OpenURL("https://en.wikipedia.org/wiki/Pipe_(fluid_conveyance)");
                    break;
                }
            case 5:
                {
                    //Manhole (sewer) at Lot R14 in front of the Civil Engineering Building
                    Application.OpenURL("https://en.wikipedia.org/wiki/Manhole");
                    break;
                }
            case 6:
                {
                    //Fountain at entrance
                    Application.OpenURL("https://en.wikipedia.org/wiki/Fountain");
                    break;
                }
            case 7:
                {
                    //Fountain in the Holden Hall
                    Application.OpenURL("https://en.wikipedia.org/wiki/Fountain");
                    break;
                }
            case 8:
                {
                    //Fountain-1 at the library
                    Application.OpenURL("https://en.wikipedia.org/wiki/Fountain");
                    break;
                }
            case 9:
                {
                    //Pond at Urbanovsky Park, Flint Avenue
                    Application.OpenURL("http://www.nhptv.org/natureworks/nwep7b.htm");
                    break;
                }
            case 10:
                {
                    //Drain pipe coming out of Flint garage
                    Application.OpenURL("https://pipelt.com/condominium/building-drainage-system-how-it-works-and-repair-options/");
                    break;
                }
        }
        
    }
}
