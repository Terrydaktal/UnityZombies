@script RequireComponent(AudioSource)

var drawAnim : String = "draw";
var fireLeftAnim : String = "fire2";
var reloadAnim : String = "reload";
var aimAnim : String = "aim";
var aimedAnim : String = "aimed";
var idleAnim : String = "idle";
var walkAnim : String = "run";
var jumpAnim : String = "jump";
var runAnim : String = "run";
var animationGO : GameObject;
var firstBuy : boolean = true;
var doneAttaching : boolean = false;

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
var draww : AudioSource;


function Start()
{
    DrawWeapon();
    var aSources = GetComponents(AudioSource);
    fire = aSources[1];
    clipout = aSources[2];
    clipin = aSources[3];
    draww = aSources[4];
    bolt = aSources[8];
}

function OnEnable(){
    if (firstBuy) {
        AttachSilencer();
        firstBuy = false;
    } else {
        //DrawWeapon();
    }
}

function Update()
{
    if (Input.GetKeyDown("1") || Input.GetKeyDown("2")){
        walking = false;
        aiming = false;
        aim = false;
        reloading = false;
        drawWeapon = false;

    }
    if (Input.GetButtonDown("Fire1") && !reloading && !drawWeapon && !aiming && doneAttaching)
    {
        Fire();
    }

    else if (Input.GetKeyDown("r") && !reloading && !drawWeapon && !aiming && doneAttaching)
    {
        Reloading();
    }

    else if (Input.GetButtonDown("Fire2") && !reloading && doneAttaching && !walking)
    {
        Aim();
     }

   else if (Input.GetKeyDown("w") && !reloading && !drawWeapon && !aiming && !aim && doneAttaching)
  {
       Walking();
  }

    else if (Input.GetKeyUp("w") && doneAttaching)
    {
        walking = false;
    }

 //   else if (Input.GetKeyDown("space") && !reloading && !drawWeapon && !aiming && !aim && !jump && doneAttaching)
  //  {
 //       JumpHip();
 //   }

    else
    {
        if (!reloading && !aiming && !drawWeapon && shots == 0 && !aim && !walking && !jump && doneAttaching)
        {
            animationGO.GetComponent.< Animation > ().Play(idleAnim);
        }
    }
}

function Fire()
{
    animationGO.GetComponent.< Animation > ().CrossFadeQueued(fireLeftAnim, 0.08, QueueMode.PlayNow);
    shots++;
    fire.Play();
    yield WaitForSeconds(0.4);
    shots--;
}

function DrawWeapon()
{
//    if (drawWeapon)
//        return;

    animationGO.GetComponent.< Animation > ().Play(drawAnim);
 //   drawWeapon = true;
    draww.Play();
//    yield WaitForSeconds(1.4);
//    drawWeapon = false;

}

function Reloading()
{
    if (reloading) return;

    animationGO.GetComponent.< Animation > ().Play(reloadAnim);
    reloading = true;
    yield WaitForSeconds(0.3);
    clipout.Play();
    yield WaitForSeconds(0.65);
    clipin.Play();
    yield WaitForSeconds(0.35);
    bolt.Play();
    yield WaitForSeconds(0.7);
    reloading = false; //2
}

function Aim()
{
    if (!aim)
    {
        aiming = true;
        yield WaitForSeconds(0.24);
        aiming = false;
        aim = true;
    }
    else
    {
        aiming = true;
        yield WaitForSeconds(0.24);
        aiming = false;
        aim = false;
    }
}

function Walking()
{
    walking = true;
    animationGO.GetComponent.< Animation > ().Play("run");
}

function JumpHip()
{
    animationGO.GetComponent.< Animation > ().Play(jumpAnim);
    jump = true;
    yield WaitForSeconds(1.1);
    jump = false;
}

function AttachSilencer () {
    animationGO.GetComponent.< Animation > ().Play("silencerOn");
    yield WaitForSeconds(4.1);
    doneAttaching = true;
}
