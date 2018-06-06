@script RequireComponent(AudioSource);

var boltAnim : String = "Bolt";
var reloadAnim : String = "Reload";
var idleAnim : String = "Idle";
var fireLeftAnim : String = "Shoot";
var animationGO : GameObject;
var Shell : GameObject;
var ShellSpawn : Transform;

var reloading : boolean = false;
var shots : int = 0;
var jump = false;
var aiming = false;
var fire : AudioSource;
var bolt : AudioSource;
var loadDone : AudioSource;
var load : AudioSource;


function Start()
{
    //DrawWeapon();
    var aSources = GetComponents(AudioSource);
    fire = aSources[0];
    bolt = aSources[1];
    loadDone = aSources[2];
    load = aSources[3];
    yield WaitForSeconds(0.8);
}

function Update()
{
    if (Input.GetKeyDown("1") || Input.GetKeyDown("2")){
        reloading = false;
        jump = false;
        aiming = false;   
        shots = 0; 
    }

    if (Input.GetButtonDown("Fire1") && shots == 0)
    {
        Fire();
    }

    else if (Input.GetKeyDown("r") && reloading == false)
    {
        Reloading();
    }

    else
    {
        if (reloading == false && shots == 0)
        {
            animationGO.GetComponent.< Animation > ().Play(idleAnim);
        }
    }
}

function Fire()
{
    animationGO.GetComponent.< Animation > ().Play(fireLeftAnim);
    shots = 1;
    fire.Play();
    yield WaitForSeconds(0.7);
    animationGO.GetComponent.< Animation > ().Play(boltAnim);
    bolt.Play();

    if (Shell && ShellSpawn) {
		var shell = Instantiate (Shell, ShellSpawn.position, ShellSpawn.rotation);
		shell.GetComponent(Rigidbody).AddForce(ShellSpawn.transform.right * 2);
		shell.GetComponent(Rigidbody).AddTorque (Random.rotation.eulerAngles * 10);
		Destroy (shell, 5);
    }

    yield WaitForSeconds(1.05);
    shots = 0;
    
}


function Reloading()
{
    if (reloading) return;
    animationGO.GetComponent.< Animation > ().Play(reloadAnim);
    reloading = true;
    bolt.Play();

    if (Shell && ShellSpawn) {
		var shell = Instantiate (Shell, ShellSpawn.position, ShellSpawn.rotation);
		shell.GetComponent(Rigidbody).AddForce(ShellSpawn.transform.right * 2);
		shell.GetComponent(Rigidbody).AddTorque (Random.rotation.eulerAngles * 10);
		Destroy (shell, 5);
		}

    yield WaitForSeconds(1.5);
    load.Play();
    yield WaitForSeconds(0.7);
    load.Play();
    yield WaitForSeconds(0.7);
    load.Play();
    yield WaitForSeconds(0.7);
    load.Play();
    yield WaitForSeconds(0.7);
    yield WaitForSeconds(1.1);
    loadDone.Play();
    animationGO.GetComponent.< Animation > ().Play(boltAnim);
    yield WaitForSeconds(1.05);
    reloading = false;
}
