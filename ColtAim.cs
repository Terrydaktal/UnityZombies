using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColtAim : MonoBehaviour {
    public GameObject FPSCamera;
    bool Aiming = false;

    // Use this for initialization
    void Start() {
        Aiming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("1") || Input.GetKeyDown("2")) && Aiming){
            FPSCamera.GetComponent<Animation>().Play("fastUnAimColt");
            Aiming = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (!Aiming) FPSCamera.GetComponent<Animation>().Play("aimColt");
            else FPSCamera.GetComponent<Animation>().Play("unAimColt");
            Aiming = !Aiming;
        }
    }
  
}
