# CS 4331 - Project #3

## TTUWAR: Texas Tech University's Water Augmented Reality

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/TTUWAR.jpg"/>

by:

* Gantaphon Chalumporn
* Jijun Sui
* Luis Rausseo

## The Game

TTUWAR is a location-based AR mobile game in which the player can go walking around TTU campus and when close to a POI (Water source), the player can trigger a minigame/quiz that if completed it will give points to the player. When playing the first time, the player will need to login in to FB. In the game, answering quizzes correctly will accumulate score, which is stored in a database that the player can view through the HighScore button. Going there will prompt you to submit your score with a nickname, or view high scores directly. 

### Login

To play TTUWAR, the player will need to login using Facebook when opening the application for the first time. This is needed to personalize the experience for the user and be able to upload player's score to the leaderboard.

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021953_TTUWAR.jpg" width="243" height="500" />

> __Note__: in the future, more login providers could be added to the application.

### How to play?

TTUWAR is a location based game, which means the player would need to navigate the real world to play this game. GPS location is retreived by the game and used to determine player's location.

There are several water sources / features around campus in which the player can find a sticker with a distinct marker. When the marked is scanned with the AR camera, an activity will start.

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021637_TTUWAR.jpg" width="243" height="500" />

As per now, these activities are just quizzes regarding the water feature or a minigame in which the player needs to memorize some facts and then answer a question in the end. 

#### Quizzes

Every correct answer will grant the player 5 points. If the player make a mistake, will lose a life and when all lifes are depleted will lose the challenge.

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021718_TTUWAR.jpg" width="243" height="500" />

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180506-030214_TTUWAR.jpg" width="243" height="500" />

#### Crystal Mini-game

The player needs to touch the 4 crystals in the game-space which will show a fact about water. After all crystals are activated, the player can go to the center and activate the well's water by answering a quiz regarding the crystals' facts. If sucessful, the player will gain 10 points.

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180506-030239_TTUWAR.jpg"/>

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180511-234941_TTUWAR.jpg"/>

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180511-235047_TTUWAR.jpg"/>

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/GameGif.gif"/>

#### Leaderboard

In the world map, the player can access the leaderboard tapping the button on the top-right corner. If tap in the ADD button, the score will be sent to dreamlo database. If the player has a lower score than the one uploaded, it won't be uploaded.

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Screenshot_20180412-021642_TTUWAR.jpg" width="243" height="500" />

## Development

### Vuforia

Since Vuforia for Unity has a weird behaivor in which overrides the main camera of all scenes, the following script was implemented to stop Vuforia in the first scene by attaching the script to a GameObject.  

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
> Credits to __caiovm__ from [Unity Forum](https://forum.unity.com/threads/use-ar-camera-vuforia-core-in-individual-scene-not-entire-project.498489/)

When activating the AR camera, it is just needed to run this line of code to activate Vuforia.

`VuforiaRuntime.Instance.InitVuforia();`

The following line of code, can be used to stop the camera:

`VuforiaBehaviour.Instance.enabled = false;`

To be able to perform different actions with different markers, the following script was attached to each imageTarget.

```C#
using UnityEngine;
using Vuforia;

public class markerDetected : MonoBehaviour, ITrackableEventHandler
{
    public GameObject promptWindow;

    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //target is found
            Debug.Log("Detected: " + this.name);
            if (this.name == "Pfluger")
            {
                startQuiz.QuizNum = 1;
            }
            if (this.name == "Headwaters")
            {
                startQuiz.QuizNum = 2;
            }
            promptWindow.SetActive(true);
        }
        else
        {
            Debug.Log("Lost");
        }
    }
}
```

### Facebook SDK for Unity

Facebook SDK was used to personalize user's experience. It was needed to be able to make the leaderboard since the player's name was required to submit the highscores. 

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

![Unity Script Screenshot](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/POIs_Editor.PNG) 

### Sun Position Changer

There is a directional light on top of the world map which changes position depending of the time of the day.

```C#
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
```

![Sun Position Changer](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/SunGif.gif) 

### Building the Project

During the development of this project, one the challenges was to actually build the .apk for Android. To that end, the following SDKs were used:

* [Android Studio](https://developer.android.com/studio/index.html) with SDK API 24 - 27
* Android NDK
* [Java SE Development Kit 8u171](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html)
* Unity for Windows ver. 2017.4.0f1 (64-bit)

> __Note__: The Android SDKs and NDK were downloaded in Android Studio's SDK Manager.

## Sources

### Assets

* [Character Pack: Free Sample by SUPERCYAN](https://assetstore.unity.com/packages/3d/characters/humanoids/character-pack-free-sample-79870)
* [Cartoon Lowpoly Water Well by Antonio Neves](https://assetstore.unity.com/packages/3d/environments/fantasy/cartoon-lowpoly-water-well-29717)
* [Water FX Pack by Unity Technologies](https://assetstore.unity.com/packages/vfx/particles/environment/water-fx-pack-19248)
* [Hand-Painted Fountain](https://assetstore.unity.com/packages/3d/environments/fantasy/hand-painted-fountain-41694)
* [Medieval Stone Water Well](https://assetstore.unity.com/packages/3d/environments/medieval-stone-water-well-30476)
* [Fantasy Object Free Set](https://assetstore.unity.com/packages/3d/environments/fantasy/fantasy-object-free-set-66160)
* [Casual Game GUI Skin by Dead Mosquito Games](https://assetstore.unity.com/packages/2d/gui/casual-game-gui-skin-67196)

### Sounds

* [ZAPSPLAT](https://www.zapsplat.com/)
* [Patakas World by DL Sounds](https://www.dl-sounds.com/royalty-free/patakas-world/)
* [Superboy by DL Sounds](https://www.dl-sounds.com/royalty-free/superboy/)
* [NFF Fruit Appearance by NoiseForFun](http://www.noiseforfun.com/waves/fantasy-and-magic/NFF-fruit-appearance.wav)

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
* ~~Improved quiz GUI.~~
* ~~Added life system to quizzes.~~
* ~~Added sound and BGM to quiz GUI.~~
* ~~Modified QuizManager system to allow multiple quizzes.~~
* ~~Improved LEARN button script to allow multiple websites.~~
* ~~Created Crystal's minigame scene.~~
* ~~Added BGM to mapWorld.~~
* ~~Added quiz system to Crystal's minigame.~~

### Gantaphon: 

* ~~Tested Vuforia AR platform in seperate project.~~
* ~~Created AR database on Vuforia.~~
* ~~Seted Vuforia configuration for Unity project.~~
* ~~Mapped modle on taget AR image.~~
* ~~Use DroidCam to test AR on PC platform.~~
* ~~Merged AR finished scene with Map scene.~~
* ~~Added more models and target image.~~
* ~~Replied to peer's feedback.~~
* ~~Gathered information regarding POIs~~
* ~~Added more markers to Vuforia SDK.~~

### Jijun:

* ~~Created a leaderboard scene in Unity.~~
* ~~Created UI elements to display rank, score, and player entered nickname.~~
* ~~Configured dreamlo leaderboards database and set up a connection between project and database.~~
* ~~Created a UI that prompts a nickname to submit score.~~
* ~~Added buttons to navigate between Map scene and highscores scene.~~
* ~~Created score script to keep track of player score during the entire game.~~
* ~~Modified score system to subtract points, give bonus points, etc.~~
* ~~Researched how to implement multiplayer function~~
* ~~Added more score modifiers~~
* ~~Added timer function to quiz games~~
* ~~Created multiplayer test lobby~~
* ~~Made multiplayer demo for Crystal game.~~
* Multiplayer test scene (can implement into Crystal game, but the other parts are difficult to make into multiplayer.
* Link to Video [Here](https://youtu.be/qQhVm4dcqu0)

## Pending/Proposals:

* Fix animation of player while walking/GPS speed script.
* Get unique username from Facebook API for the leaderboard. 
* Integrate more login options (Google Play and/or email).
* Expand multiplayer system so that it remains consistent between map and game changes. 
* Integrate the multiplayer system to whole project.

## References

* [Vuforia | Augmented Reality](https://www.vuforia.com/)
* [Unity Asset Store](https://assetstore.unity.com/)
* [CS 4331 - Project 2: Water resources](https://idatavisualizationlab.github.io/CS5331-VirtualReality/)
* [Mapbox](https://www.mapbox.com/)
* [dreamlo Leaderboards](http://dreamlo.com/)
* [Seametrics](http://www.seametrics.com/blog/water-facts/)

## Feedback

### Project #2:

__Q__: Are the wells based on actual water resources around Lubbock, and if so which resources are they based on?

> __A__: All of them except one are based on actual water resources according to the data we have. There is one resources that we added near our class building for presentation purpose.

__Q__: Were there any issues that occurred with the scanner? Or was it easy to implement

> __A__: There are some problems with Vuforia camera you can look for the solution through our report.

__Q__: How expandable is this project? How easy is it to apply this to a different region or add new trivia? I like the appearance of this project.

> __A__: It could be applied to many other field and there are rooms for more features.

__Q__: Would the mouse disappear?

> __A__: Our application run on mobile devices (Android) no mouse will be shown on the mobile. The mouse you saw during the presentation is because we ran mobile screen duplication on Windows machine.

__Q__: Interesting game, would look into other options besides Facebook

> __A__: Other options can be added but we will focus on adding other features and UI improvement as our first priority.


## Disclaimer

TTU and Double T(R) logo are registered trademarks of Texas Tech University. Used in this project under the authorization of the Office of Marketing and Brand Management at Texas Tech University.

[Authorization](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Double_T_Logo_Authorization.pdf)
