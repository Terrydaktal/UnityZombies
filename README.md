# UnityZombies

A high graphics FPS zombie survival game I'm creating using the Unity engine, GIMP, Vegas and other tools, based on the classic Nazi Zombie series, with realistic, attention to detail animations, high quality weapons and 3D sounds. (Weapon, Tree, House, FBX, prefabs preprovided by unitypackages without decent animations / scripts. I have created every animation and script).

dev v1.0  
added house prefabs   
added first player controller and WASD movement, mouse look movement, jumping  
added light, made scene pitch black  
added grass to the plane  
added ACR prefab, added a custom skin  
created animations for ACR firing, ADS, walking, reloading, jumping, shooting whilst ADS, drawing  
added sounds to the animations  
coded animations with correct keybindings  
added crouching feature  
added raycast and bullet hole feature  
finetuned ACR animation times and smoothened animations  
fixed ACR animation bugs and logic errors  

![Screenshot](images/img1.jpg)
  
dev v1.0.1  
added zombie prefab and added walking animation  
fixed walking animation resetting and zombie not dying when idle  
created zombie spawn point  
added navmesh and zombie pathfinding  
added blood particle effect when bullet hits zombie  
implemented basic zombie hp system  
added zombie dying animation and coded it in  
  
dev v1.0.2  
fixed zombie mesh not disappearing upon death (created separate mesh object)  
coded in 15 different zombie dying and hit sounds  
  
dev v1.0.3  
added M24 prefab  
created and coded animations for M24 firing, ADS, reloading  
added sniper scope animations and on screen crosshairs  
fixed thread times and fine tuned animations in time with raycasts  
added reloading whilst looking through scope animation  
added sounds to the animations  

![Screenshot](images/img2.jpg)
  
dev v1.1  
changed skybox  
added trees  
added lightning, wind, rain and fog  
fixed frame rate issues  
made foliage move in the breeze  
added more zombie spawn points  

![Screenshot](images/img16.jpg)
  
dev v1.1.1  
added wall guns  
coded wall gun player sensor and weapon pickup controls  
added text alert to the GUI when player is on the sensor  
added weapon switching and a weapon manager  
fixed being able to draw 2 weapons at once  
fixed all weapon booleans being stuck in erroneus states when switching weapons  
configured mystery box prefab  
added 3D spatial blend to all sounds and adjusted zombie dying sounds rolloff  

![Screenshot](images/img6.jpg)
  
dev v1.1.2  
added colt prefab and added custom texture  
created and coded colt ADS, shooting whilst ADS, reloading, draw, firing animations  
added colt reloading, ADS  
added new bullet hole system (10 different bullet holes and animations based on surface, tagged all game objects with respective tags)  
added muzzle flash and smoke  
added weapon bullet hole flying and impact sounds with 3D spatial blend  
added 3D spatial  blend to all weapon sounds  
fixed shooting whilst reloading issue on colt  
fixed player moving with mouse pan  
fixed shooting whilst rapid pressing r on all weapons  
added distortion and screen shaking when firing colt ADS  
improved m24 and colt ADS animations by animating camera as well as weapon  

![Screenshot](images/img4.jpg)
![Screenshot](images/img7.jpg)
![Screenshot](images/img8.jpg)
![Screenshot](images/img5.jpg)
![Screenshot](images/img9.jpg)
![Screenshot](images/img10.jpg)
![Screenshot](images/img15.jpg)
  
dev v1.1.3  
  
added barrier prefab  
created window barrier animation  
created and programmed sensor for zombie and player near window  
added text alert to the GUI when player is on the sensor and fixed issue with it not going away  
added fix board animations and a single remove board animation  
fixed various bugs with animations not working and zombies not coming into the window once all the boards have been knocked down  
fixed zombies standing on ledge whilst taking down boards  
added sounds to tbe boards being taken down with 3D spatial blend and adjusted rolloff  
adjusted rolloff for zombie gib sounds  
fixed remove board animation not working and finetuned timings  
fixed rebuild barrier alert not going away when barrier is built  
added bullet hole information to the boards and retextured them  
added more remove board animations  
cloned another barrier into the scene for the other window  
Spawnwall -> hit.transform.parent.gameObject means all windows can be managed dynamically with the same script  
created more space in the house, removed some objects  
removed mesh renderer from window quad  
replaced object message system using direct variable accesses, reduced code clutter  
fixed barrier animation repeating  
fixed barrier board not coming back  
added delay to rebuilding barrier  
added souds to rebuilding the barrier with correct rolloffs and 3D spatial blend  
separated ACR aim and sway animations to camera and gun to allow for both animations at the same time, adds realistic sway when ADS  
fixed ACR raycast, made child of gun  
fixed ACR shooting whilst reloading logic error  
adjusted lighting and effects  
configured g18 prefab  
![Screenshot](images/img17.jpg)
![Screenshot](images/img18.jpg)
  
dev v1.1.4  
added weapon sway mechanic for M24 and colt  
added zombie attack animation to the zombie animator state machine and programmed trigger  
fixed R3 distance vector for attack animation  
added player hit sound and blood screen effects  
added basic player HP and regeneration system  
added zombie attack sounds with appropriate rolloff  
adjusted zombie attack animations and attack range  
added rain patter sounds to the scene with appropriate rolloff (logarithmic)  
added basic player death animation and game over sequence  
hid cursor during game  
configured spas13 prefab    
added MK23 pistol, wallbuy, raycast, complete set of animations and sounds (still glitchy atm)   
zombies can now attack through window, yet to add different animations  
![Screenshot](images/img19.jpg)
![Screenshot](images/img20.jpg)
![Screenshot](images/img21.jpg)


to do list:  
legs -> crawler  
add crawler system  
head - > head comes off  
shooting things on table  
add more zombie death animations  
make blood more realistic - stain  
window climbing (player + zombie animations)  
ammo system -> all gun empty mechanics  
buy more ammo system at wallgun  
score / point system  
puddles on the ground  
player soldier body and see feet  
fix m24 reloading sound, prevent firing whilst reloading  
fim m9 smoke repeating, dynamic time  
collateral damage  
fix gun switching issue scope still zoomed in  
fix draw animation issues  
add walking and jump animations to the 2 new guns  
adding better floor terrain  
fix crouching issue causing superjump  
stuff leaking out of barrels, basket moves  
keep bullet holes (perhaps)  
fix colt smoke  
zombie spawning speeds (configure round system)  
zombie run animations and speeds and zombie hp system  
fix issue reloading whilst buying a weapon  
buying weapon sound  
shake when firing (colt not aiming and m4 not aiming, acr both, mk23 both)  
put ACR over to the new system with aiming, change animations, stop it from shooting when reloading  
stop looking through walls issue  
change to press and hold E rather than just pressing E like the text says (perhaps)  
fix stupid bullet line issue on fabric  
fix not reloading when crouching  
get mystery box working  
gun draw issues -> no animations  
fix ACR draw, off the bottom of the screen  
add zombie footstep sounds and other  sounds  
add zombie runner, instantiation with increaing frequency  
fix jump height  
fix delay to hit down board initially  
fix stuck zombies  
fix glitch spots and revamp map navmesh, prevent climbing out of window  
fix dead zombies knocking down barrier  
add zombie taking down barrier animations, attack through window animations  
gun draw sounds  
fix ACR aiming when walking animation  
ACR gun sway ADS fix  
ACR aiming in speed fix and shooting whilst doing it fix  
ACR flash and smoke  
player death -> improve animation  
blood animations fade and HP regenerates -> improve current basic system  
weapon move when walking -> remove all idles and make scripted - weapon bob  
add character bob  
add map constraints  
add door functionality and animations  
improve game over sequence, remove blood etc  
fire empty animations and sounds  
mk23 improve animations and scripts, ADS sway , ads shake when fire, coord it all  
fix mk23 aim whilst buy  
move whole project over to c#  
add spas13 and g18 into the game fully  
revamp and tweak all weapon animations and fix inaccuracies and glitches on all  
tweak weapon damage  
add perks  
revamp zombie replace linear interpolation with collider  
