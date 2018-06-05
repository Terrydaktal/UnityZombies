@script RequireComponent(AudioSource) 

var drawAnim : String = "draw";
var fireLeftAnim : String = "fire";
var reloadAnim : String = "reload";
var aimAnim : String = "aim";
var aimedAnim : String = "aimed";
var idle2Anim : String = "idle2";
var idleAnim : String = "idle";
var walkAnim : String = "walk";
var jumpAnim : String = "jump";
var runAnim : String = "run";
var animationGO : GameObject;

var drawWeapon : boolean = false;
var reloading : boolean = false;
var aim : boolean = false;
var aiming : boolean = false;
var shots : int = 0;
var walking : boolean = false;
var jump = false;
var fire : AudioSource;
var clipin : AudioSource;
var clipout : AudioSource;
var bolt : AudioSource;


function Start (){
DrawWeapon();
var aSources = GetComponents(AudioSource);
fire = aSources[0];
clipin = aSources[1];
clipout = aSources[2];
bolt = aSources[3];
}
 
function Update (){
        
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2")){
        reloading = false;
        walking = false;
        aim = false;
        aiming = false;
        drawWeapon = false;
        }

        else if(Input.GetButtonDown ("Fire1") && reloading == false && drawWeapon == false && aiming == false){
        Fire();
        }
       
        else if (Input.GetKeyDown ("r") && reloading == false && drawWeapon == false && aiming == false){
        Reloading();
        }
       
        else if (Input.GetButtonDown ("Fire2") && reloading == false){
        Aim();
        }

        else if (Input.GetKeyDown ("w") && reloading == false && drawWeapon == false && aiming == false && aim == false){
        Walking();
        }
       
        else if (Input.GetKeyUp ("w")){
        walking = false;
        }

        else if (Input.GetKeyDown ("space") && reloading == false && drawWeapon == false && aiming == false && aim == false && jump == false){
        JumpHip();
        }

        else {
            if (reloading == false && aiming == false && drawWeapon == false && shots == 0 && aim == false && walking == false && jump == false){
            animationGO.GetComponent.<Animation>().Play(idle2Anim);
            }
        }      
}
 
function Fire(){
    animationGO.GetComponent.<Animation>().CrossFadeQueued(fireLeftAnim, 0.08, QueueMode.PlayNow);
    shots++;
    fire.Play();
    yield WaitForSeconds(0.4);
    shots--;
}
 
function DrawWeapon() {
  if(drawWeapon)
    return;
       
        animationGO.GetComponent.<Animation>().Play(drawAnim);
        drawWeapon = true;
        yield WaitForSeconds(1.4);
        drawWeapon = false;
       
}
 
function Reloading(){
     if(reloading) return;
        
        animationGO.GetComponent.<Animation>().Play(reloadAnim);
        reloading = true;
        yield WaitForSeconds(0.3);
        clipout.Play();
        yield WaitForSeconds(1.3);
        clipin.Play();
        yield WaitForSeconds(0.9);
        bolt.Play();
        yield WaitForSeconds(0.9);
        reloading = false; //3.2
}

function Aim(){
     if(!aim) {
       animationGO.GetComponent.<Animation>().Play(idleAnim);
	   animationGO.GetComponent.<Animation>().Play(aimAnim);
       aiming = true;
       yield WaitForSeconds(0.4);
       aiming = false;
	   aim = true;
   	} else {
       animationGO.GetComponent.<Animation>().Play(aimedAnim);
       yield WaitForSeconds(0.2);
       aim = false;
	}
    }

  function Walking(){
    walking = true;
    animationGO.GetComponent.<Animation>().Play(walkAnim);
}
   
   function JumpHip(){
   animationGO.GetComponent.<Animation>().Play(jumpAnim);
   jump = true;
   yield WaitForSeconds(1.1);
   jump = false;
}
