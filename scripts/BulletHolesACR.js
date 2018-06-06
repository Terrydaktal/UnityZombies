var bulletTex : GameObject[]; // creates an array to use random textures of bullet holes
var reloading : boolean;
var range : int = 300;
var hitSounds : AudioClip[];
var flash : ParticleSystem;
var smoke : ParticleSystem;
var lighty : Light;
var particles : ParticleSystem;
var distortion : ParticleSystem;
var damage : int = 100;
var effectObject : String;
var effects : GameObject[];

function Start() {
    reloading = false;
}
 
function Update () {
 
   var fwd = transform.TransformDirection(Vector3.forward);
   var hit : RaycastHit;
   Debug.DrawRay(transform.position, fwd * range, Color.green); 

   if (Input.GetKeyDown("1") || Input.GetKeyDown("2")){
        reloading = false;
   }
    
   if (Input.GetButtonDown("Fire2")){
        WaitingForZoom();
    }

   if (Input.GetKeyDown("r")){
        reloading = true;
    }

   if (Input.GetButtonDown ("Fire1") && !reloading){
         smoke.Play();
         //flash.Play();
         //particles.Play();
         distortion.Play();
         lighty.enabled = !lighty.enabled;

        if ( Physics.Raycast(transform.position, fwd, hit, range)){ 
             if (hit.collider.gameObject.name == "Mesh") {
             var blood = Instantiate(bulletTex[1], hit.point, Quaternion.identity); 
             Destroy(blood, 1.0);
             hit.transform.SendMessage("HitByRaycast", damage, SendMessageOptions.DontRequireReceiver);
            }
            else {
             effectObject = hit.transform.gameObject.tag;
             for each (var obj : GameObject in effects){
                if (obj.name == effectObject+"Impact") {
                    var effectIstance : GameObject = Instantiate(obj, hit.point, new Quaternion());
                }
             }

             effectIstance.transform.LookAt(hit.point + hit.normal);
             Destroy(effectIstance, 4);

             //Instantiate(effects[3], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            
             if (effectObject == "Metal"){Instantiate(bulletTex[2], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));} //sparks

             Instantiate(bulletTex[3], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)); //smoke
             AudioSource.PlayClipAtPoint(hitSounds[Random.Range(0,5)], hit.point);
 
            }
            Waiting();
        
        }
        
    }
}

function Waiting(){
    yield WaitForSeconds(3.4);
    reloading = false;
}

function WaitingForZoom(){
    yield WaitForSeconds(0.6);
    reloading = false;
}
