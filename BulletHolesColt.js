var bulletTex : GameObject[]; // creates an array to use random textures of bullet holes
var reloading : boolean;
var range : int = 30;
var hitSounds : AudioClip[];
var flash : ParticleSystem;
var smoke : ParticleSystem;
var lighty : Light;
var particles : ParticleSystem;
var distortion : ParticleSystem;
var shots : int;
var damage : int = 50;
var aiming : boolean = false;

function Start() {
    reloading = false;
    smokeDone = true;  
}
 
function Update () {
 
   var fwd = transform.TransformDirection(Vector3.forward);
   var hit : RaycastHit;
   Debug.DrawRay(transform.position, fwd * range, Color.green);

    if (Input.GetKeyDown("1") || Input.GetKeyDown("2")){
            reloading = false;
            smokeDone = true;
            aiming = false;
            shots = 0;
    }

  // if (Input.GetButtonDown ("Fire1")){
  //      shots ++;
   // }

    if (Input.GetButtonDown ("Fire2")) {
        WaitingForAim();
    }

        if (Input.GetButtonDown ("Fire1") && !reloading && Physics.Raycast(transform.position, fwd, hit, range)){ 
             if (hit.collider.gameObject.name == "Mesh") {
             var blood = Instantiate(bulletTex[1], hit.point, Quaternion.identity); 
             Destroy(blood, 1.0);
             hit.transform.SendMessage("HitByRaycast", damage, SendMessageOptions.DontRequireReceiver);
             //shots --;
             flash.Play();
             particles.Play();
             distortion.Play();
             lighty.enabled = !lighty.enabled;
            }
            else {
             print(hitSounds.length);
             Instantiate(bulletTex[0], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
             Instantiate(bulletTex[2], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)); //sparks
             Instantiate(bulletTex[3], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)); //smoke
             //shots --;
             flash.Play();
             particles.Play();
             distortion.Play();
             lighty.enabled = !lighty.enabled;
             AudioSource.PlayClipAtPoint(hitSounds[Random.Range(0,5)], hit.point);
 
            }
        }
    
  //  if (!reloading && shots > 3){
   //        smoke.Play();
  //  }

    if (Input.GetKeyDown ("r") ) {
      reloading = true;
      Waiting();
    }
}

function Waiting(){
    yield WaitForSeconds(3.4);
    reloading = false;
}

function WaitingForAim(){
    aiming = true;
    yield WaitForSeconds(0.35);
    aiming = false;
}