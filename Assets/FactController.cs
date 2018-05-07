using UnityEngine;
using UnityEngine.UI;

public class FactController : MonoBehaviour {

    public static int FactNum;
    public Text Fact;

    public void showFact()
    {
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
    }
}
