# Game Programming with C# Final Assignment Simon Dunvall

### Add a short description of the intended behavior, how the game mechanic should work. I need to know what were you trying to achieve.<br>
I choose to make the kariomart game so the intended behavior was to make a game that follows your specification. I understood the assignment like this. The player to chooses a track and to race thier friend. The cars to have to go around the tracks a couple of times to finish the game and for the player to then choose another track. So you only race against your friend who also playes with you.However I did not have time to do all nice to haves because I tried to write as good code as a posible. More than that I made my game in 3D, used the new input system, wanted to keep the code clean so that I can easily change the code in the future.<br><br>

	
### Add a short set of instructions for me, as a developer, about what do I need do to in order to take a look at your project - what scene I need to load in order to play? Do I need any additional packages to install?<br>
Open the project in unity and click play in the editor and the right scene should load. That is the MainMenu scene just so you know but if you take the code from github everytinh should work.<br><br>

	
### Describe quickly the structure of your code and the thinking behind design.<br>
My code is structured is that I have an Init class that runs on when the game is started. That class loads two classes one called GameSettings and another called GameState. The GameSettings class is a scriptable object where some settings for the game is saved so that the game knows if it is paused for example or how many laps neeeds to be completed for a player to win. The GameState class keeps track of the GameSettings and methods related to the state of the game. So to pause the game or load scenes. The GameState also loads the MainMenu scene when initilised so that the right scene gets displayed when the game is started. 

The GameState also that cares of initilising the pausemenu and all the cars. So that when it does not matter with track Im in the cars will always work and the same for the pausemenu with also makes it easier if you want to att more tracks in the future. The pausemenu have an controller that controlls the menu in terms of when to display it or not. Then it also have a script for the two buttons "resume" and "main menu" so that those buttons work correctly. All menus have that structure if it is needed so some those not have a controller.

The Car has a controller that calcules the movment of the car dependent on the input that is given. It also has a data script to store the temporary data of the car in my case it is just to store the amount of laps that have been completed. That data is deleted every time the car is destroyed with is when a scene is loaded with is helpfull because you only want the car to keep the data for this race and not for the remening time of the game.

The rest is that the prefabs for the track have a script each to calculate when a player has gotten x amounts of laps or to increase the speed of the car when you hit a specific cube in the scene.<br><br>
	
### Add a short list if instructions about how to play the game like, for example, the key mappings and what do they do<br>
Click start game in the main menu than just choose the track you want to play. The keymaps are wasd and arrowkeys for forward, right, reverse and left. Car one has wasd car two has the arrowkeys. If you want to pause the game than you can use esc and either resume or go back to the main menu.<br><br>

	
### Add a list of sources of inspiration - you don't need to cover all of them, just the ones that helped.<br>
These three sources were my inspiration for the game. They all have to do with the car and how it works and they have been very helpfull in terms of having a goal that I wanted to reach with the car controller

https://learn.unity.com/tutorial/challenge-3-configure-the-wheel-drive-component-s-acceleration-and-steering-angle-inputs?uv=2020.1&projectId=5fc93d81edbc2a137af402b7#5fc82e4aedbc2a075144c80e<br>
https://docs.unity3d.com/Manual/WheelColliderTutorial.html<br>
https://www.youtube.com/watch?v=DU-yminXEX0<br><br>


	
### Add the Unity version for the project<br>
2022.3.9f1<br><br>

 
**Add your name to the project**<br>
Simon Dunvall
