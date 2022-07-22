<p align="center">
  <img src="https://i.imgur.com/nPsqSua.png">
</p>

<h1 align="center">Downlight</h1>

<div style="text-align: center">This is a 2D side scroller that I made as a way to improve my C# coding and game development skills.</div>
 <br />

 <p align="center"><img src="https://img.shields.io/github/last-commit/connorlee11/Downlight"> <img src="https://img.shields.io/github/directory-file-count/connorlee11/Downlight"> <img src="https://img.shields.io/discord/996873491779424276?color=red&label=Discord"></p> 
 <br />


<p align="center">
  <img src="https://media.giphy.com/media/clZUPN84jELxYouMVd/giphy.gif">
</p>

 <h1 align="center">Download</h1>

 <div style="text-align: center">If you want to give the game a try, you can download it here: <a href="https://drive.google.com/file/d/1oWp-wBEIWnkTbo9jcmSWaJCXIyDzU1yH/view?usp=sharing" target="_blank">Downlight</a></div>
<br />
<br />
<br />
<br />

<h1 align="center">Game Mechanics</h1>
<h2 align="left">Flashlight Toggle</h2>
<br />
<br />

<div style="text-align: left">The game features a flashlight brighten feature that slows down enemies when left-click is held down. While the light is in the brightened state it slowly drains the energy bar on the bottom left corner of the HUD. This feature was inspired by the flashlight mechanic from the game Alan Wake. As the game progresses in rounds, the need to conserve and use the energy wisely is paramount.
<br />

<p align="center">
  <img src="../Downlight/DownLight/Pictures/Small_01.png">
</p>


 <h2 align="left">Healing Light</h2>
<br />

<div style="text-align: left">Another mechanic that was inspired by Alan Wake was the healing mechanic. The player begins to recharge health as long as they are standing in the light. I achieved this by adding a box collider component set as a trigger to the Lantern asset. When the trigger senses an object with the tag "Player" it starts the coroutine named "Heal". 
<br />
<br />

<p align="center">
  <img src="../Downlight/DownLight/Pictures/HealingZone_Small.png">
</p>


 <h2 align="left">RNG Ammo Drops</h2>
<br />

<div style="text-align: left">Downlight is as much a game of luck as it is a game of skill. The enemies have a 1/4 chance of dropping ammo when you kill them. This mechanic makes conserving ammo a necessity if you plan on getting anywhere past round five. If your RNG is bad then you are forced to rely on the two ammo spawns on either side of the map. These only respawn every thirty seconds however.  
<br />
<br />

<p align="center"><img src="../Downlight/DownLight/Pictures/1out of 4.png"></p> 
<p align="center"><img src="../Downlight/DownLight/Pictures/Ammo_Small.png"></p>


<h1 align="center">Video</h1>



 



