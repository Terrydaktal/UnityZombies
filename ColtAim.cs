using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColtAim : MonoBehaviour {
    public GameObject FPScamera;
    bool Aiming = false;

    // Use this for initialization
    void Start() {
        Aiming = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Fire2"))
        {
            if (!Aiming) FPScamera.GetComponent<Animation>().Play("aimColt");
            else FPScamera.GetComponent<Animation>().Play("unAimColt");
            Aiming = !Aiming;
        }
    }
  
}




