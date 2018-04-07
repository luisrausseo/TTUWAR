using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Facebook.Unity;

public class loadPic : MonoBehaviour {

    public GameObject DialogProfilePic;

    // Use this for initialization
    void Start () {
        FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
    }

    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Image ProfilePic = DialogProfilePic.GetComponent<Image>();
            ProfilePic.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
    }
}
