# CS 4331 - Project #2

## TTUWAR: Texas Tech University's Water Augmented Reality

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Logo.png" width="400" height="400" />

by:

* Gantaphon Chalumporn
* Jijun Sui
* Luis Rausseo

## The Game

TTUWAR is a location-based AR mobile game in which the player can go walking around TTU campus and when close to a POI (Water source), the player can trigger a minigame/quiz that if completed it will give points to the player. When playing the first time, the player will need to login in to FB. In the game, answering quizzes correctly will accumulate score, which is stored in a database that the player can view through the HighScore button. Going there will prompt you to submit your score with a nickname, or view high scores directly. 

### Login

To play TTUWAR, the player will need to login using Facebook when opening the application for the first time. This is needed to personalize the experience for the user and be able to upload player's score to the leaderboard.

![Main Screen](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021953_TTUWAR.jpg)

### How to play?

TTUWAR is a location based game, which means the player would need to navigate the real world to play this game. GPS location is retreived by the game and used to determine player's location.

There are several water sources / features around campus in which the player can find a sticker with a distinct marker. When the marked is scanned with the AR camera, an activity will start.

![Main Play](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021637_TTUWAR.jpg)

As per now, these activities are just quizzes regarding the water feature. 

![Quiz](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021718_TTUWAR.jpg)

> __Note__: In the future, these activities will be triggered by player's positioning respecting the water feature.

Every correct answer will grant the player 5 points. 

![Leaderboard](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021642_TTUWAR.jpg)

## Development

### Vuforia

Since Vuforia for Unity has a weird behaivor in which overrides the main camera of all scenes, the following script was implemented to stop Vuforia in the first scene. 

```C#
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Vuforia;
using System.Reflection;
using System;

public class VuforiaCameraIssueFix : MonoBehaviour
{
    void Awake()
    {
        try
        {
            EventInfo evSceneLoaded = typeof(SceneManager).GetEvent("sceneLoaded");
            Type tDelegate = evSceneLoaded.EventHandlerType;

            MethodInfo attachHandler = typeof(VuforiaRuntime).GetMethod("AttachVuforiaToMainCamera", BindingFlags.NonPublic | BindingFlags.Static);

            Delegate d = Delegate.CreateDelegate(tDelegate, attachHandler);
            SceneManager.sceneLoaded -= d as UnityAction<Scene, LoadSceneMode>;
        }
        catch (Exception e)
        {
            Debug.LogWarning("Cant remove the AttachVuforiaToMainCamera action: " + e.ToString());
        }
    }
}
```

When activating the AR camera, it is just needed to run this line of code to activate Vuforia.

`VuforiaRuntime.Instance.InitVuforia();`

The following line of code, can be used to stop the camera:

`VuforiaBehaviour.Instance.enabled = false;`

### Facebook SDK for Unity

Facebook SDK was used to personalize user's experience. It was needed to be able to make the leaderboard since the player's name was required to submit the highscores. 

> __Note__: in the future, more login providers could be added to the application.

To make the Facebook SDK Unity plugin to run, it was needed to install [OpenSSL](https://www.openssl.org/) to make it work.

### Mapbox SDK for Unity

The map was created using the API from Mapbox.

![Map Screenshot](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Basemap.PNG)

* [BaseMap](https://api.mapbox.com/styles/v1/luisrausseo/cjfbw7qvt0crj2rofx2ntq8zc.html?fresh=true&title=true&access_token=pk.eyJ1IjoibHVpc3JhdXNzZW8iLCJhIjoiY2pmYTZvN25jMDNuajJxcGF1eTRkaWh2eCJ9.okUiQz3Gexgb8rHDQ2Fzdw#16.29/33.584049/-101.874651)

### Water Wells Locator

To set the position of the models regarding the Water Wells in the world map, a correction factor had to be calculated since the coordenates from MapBox differs from the ones that Google Maps provide.

```C#
namespace Mapbox.Examples
{
    using Mapbox.Unity.Location;
    using UnityEngine;

    public class WaterSourcesLocation : MonoBehaviour
    {
        [SerializeField] private Vector2[] LatLon;
        [SerializeField] private GameObject[] POIs;

        bool _isInitialized;
        private float Zcorrection = 4.98445f;
        private float Xcorrection = 6.289173f;
        private Vector2 origin = new Vector2(-7.89f, 16.37f);

        private AbstractLocationProvider _locationProvider = null;


        void LateUpdate()
        {
            Unity.Map.AbstractMap map = LocationProviderFactory.Instance.mapManager;

            for (int i = 0; i < LatLon.Length; i++)
            {
                Utils.Vector2d currentPos = new Utils.Vector2d(LatLon[i].x, LatLon[i].y);
                Vector3 coord = new Vector3(map.GeoToWorldPositionXZ(currentPos).x - Xcorrection, -15.8f, map.GeoToWorldPositionXZ(currentPos).z + Zcorrection);
                POIs[i].transform.localPosition = coord;
            }
        }

    }
}
```

![Unity Script Screenshot}() 

### Building the Project

During the development of this project, one the challenges was to actually build the .apk for Android. To that end, the following SDKs were used:

* [Android Studio](https://developer.android.com/studio/index.html) with SDK API 24 - 27
* Android NDK
* [Java SE Development Kit 8u171](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html)
* Unity for Windows ver. 2017.4.0f1 (64-bit)

## Sources

### Assets

* [Character Pack: Free Sample by SUPERCYAN](https://assetstore.unity.com/packages/3d/characters/humanoids/character-pack-free-sample-79870)
* [Cartoon Lowpoly Water Well by Antonio Neves](https://assetstore.unity.com/packages/3d/environments/fantasy/cartoon-lowpoly-water-well-29717)
* [Water FX Pack by Unity Technologies](https://assetstore.unity.com/packages/vfx/particles/environment/water-fx-pack-19248)
* [Hand-Painted Fountain](https://assetstore.unity.com/packages/3d/environments/fantasy/hand-painted-fountain-41694)
* [Medieval Stone Water Well](https://assetstore.unity.com/packages/3d/environments/medieval-stone-water-well-30476)
* [Fantasy Object Free Set](https://assetstore.unity.com/packages/3d/environments/fantasy/fantasy-object-free-set-66160)
* [Casual Game GUI Skin by Dead Mosquito Games](https://assetstore.unity.com/packages/2d/gui/casual-game-gui-skin-67196)

https://assetstore.unity.com/packages/3d/environments/fantasy/hand-painted-fountain-41694


### Android Camera

For developing on PC, DroidCam is used to retrive wireless camera input from Android device.

![DroidCam Screenshot](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/DroidCam.PNG)

* [DroidCam](https://www.dev47apps.com/)


### Miscellaneous

* [Never Surrender Font](https://www.dafont.com/never-surrender.font)
* [TTU Double T Logo](https://www.depts.ttu.edu/rawlsbusiness/communications/brand/)
* [Splash Screen Background](http://www.kinyu-z.net/WDF-966875.html)

## Progress

### Luis: 

* ~~Created basemap and add it to Unity.~~
* ~~Created principal scene of location-based game.~~
* ~~Modified/created scripts to get user location.~~
* ~~Added player and animations.~~
* ~~Modified/created scripts to add POI's models to map based on longitude and latitude.~~
* ~~Created AR camera scene and scripts to swtich between scenes.~~
* ~~Added splash screen.~~
* ~~Added Facebook SDK and enabled login feature.~~
* ~~Fixed world scene GUI.~~
* ~~Made quiz GUI.~~
* ~~Made QuizManager system.~~
* ~~Merged final AR scene with World scene and Leaderboard system.~~
* Pending: Fix animation of player while walking/GPS speed script. 
* Pending: Get unique username from Facebook API for the leaderboard. 

### Gantaphon: 

* ~~Tested Vuforia AR platform in seperate project.~~
* ~~Created AR database on Vuforia.~~
* ~~Seted Vuforia configuration for Unity project.~~
* ~~Mapped modle on taget AR image.~~
* ~~Use DroidCam to test AR on PC platform.~~
* ~~Merged AR finished scene with Map scene.~~
* ~~Added more models and target image.~~
* Pending: Create more quizzes. 
* Pending: Add information tabregarding POIs.

### Jijun:

* ~~Created a leaderboard scene in Unity.~~
* ~~Created UI elements to display rank, score, and player entered nickname~~
* ~~Configured dreamlo leaderboards database and set up a connection between project and database~~
* ~~Created a UI that prompts a nickname to submit score.~~
* ~~Added buttons to navigate between Map scene and highscores scene~~
* ~~Created score script to keep track of player score during the entire game~~
* Pending: Add sound.
* Pending: Modify score system to subtract points, give bonus points, etc.

## References

* [Vuforia | Augmented Reality](https://www.vuforia.com/)
* [Unity Asset Store](https://assetstore.unity.com/)
* [CS 4331 - Project 2: Water resources](https://idatavisualizationlab.github.io/CS5331-VirtualReality/)
* [Mapbox](https://www.mapbox.com/)
* [dreamlo Leaderboards](http://dreamlo.com/)

## Disclaimer

TTU and Double T(R) logo are registered trademarks of Texas Tech University. Used in this project under the authorization of the Office of Marketing and Brand Management at Texas Tech University.

[Authorization](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Double_T_Logo_Authorization.pdf)
