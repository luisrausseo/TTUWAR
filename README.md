# CS 4331 - Project #2

## TTUWAR: Texas Tech University's Water Augmented Reality

by:

* Gantaphon Chalumporn
* Jijun Sui
* Luis Rausseo

<img src="https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Logo.png" width="400" height="400" />

TTUWAR is a location-based AR mobile game in which the player can go walking around TTU campus and when close to a POI (Water source), the player can trigger a minigame/quiz that if completed it will give points to the player. When playing the first time, the player will need to login in to FB. In the game, answering quizzes correctly will accumulate score, which is stored in a database that the player can view through the HighScore button. Going there will prompt you to sumbit your score with a nickname, or view high scores directly. 

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

### Map

The map was created using the API from Mapbox.

![Map Screenshot](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/Basemap.PNG)

* [BaseMap](https://api.mapbox.com/styles/v1/luisrausseo/cjfbw7qvt0crj2rofx2ntq8zc.html?fresh=true&title=true&access_token=pk.eyJ1IjoibHVpc3JhdXNzZW8iLCJhIjoiY2pmYTZvN25jMDNuajJxcGF1eTRkaWh2eCJ9.okUiQz3Gexgb8rHDQ2Fzdw#16.29/33.584049/-101.874651)

### Android Camera

For developing on PC, DroidCam is used to retrive wireless camera input from Android device.

![DroidCam Screenshot](https://github.com/luisrausseo/TTUWAR/blob/master/ReadmeResources/droidcam.PNG)

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
