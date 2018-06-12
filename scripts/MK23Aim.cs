using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK23Aim : MonoBehaviour {
    public GameObject FPSCamera;
    bool Aiming = false;
    bool reloading = false;
    bool aimingReady = false;
    GameObject MK23;


    // Use this for initialization
    void Start() {
        Aiming = false;
        reloading = false;
        aimingReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("1") || Input.GetKeyDown("2")) && Aiming)
        {
            FPSCamera.GetComponent<Animation>().Play("fastUnAimColt");
            Aiming = false;
            reloading = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (!Aiming) FPSCamera.GetComponent<Animation>().Play("MK23AimIn");
            else FPSCamera.GetComponent<Animation>().Play("MK23AimOut");
            Aiming = !Aiming;
            aimingReady = false;
            StartCoroutine(WaitingForAim());
        }

        if (Input.GetButtonDown("Fire1") && !reloading && aimingReady && Aiming)
        {
           // FPSCamera.GetComponent<Animation>().Play("coltAimedVibration");

        }

        if (Input.GetKeyDown("r") && !reloading)
        {
            reloading = true;
            StartCoroutine(WaitingForReload());
        }
    }

    IEnumerator WaitingForReload()
    {
        yield return new WaitForSeconds(2);
        reloading = false;
    }

    IEnumerator WaitingForAim()
    {
        yield return new WaitForSeconds(0.24f);   //same time for aiming in and out
        aimingReady = true;
    }
}
