using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeScript : MonoBehaviour {

    public Texture2D CrosshairZoom;
    public Camera NormalCamera;// FPS camera
    public bool Zooming = false;
    public GameObject C_Right_Hand;
    public GameObject C_Left_Hand;
    public GameObject Dummy01;
    public GameObject Dummy02;
    public GameObject Hand;
    public GameObject animationGO;
    public bool Ready = false;
    public bool Yes = false;
    public bool reloading = false;
    public bool Busy = false;

    void Update()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2"))
        {
            if (Zooming) { GetComponent<Camera>().fieldOfView = 73; }
            StopAllCoroutines();
            Zooming = false;
            Ready = false;
            Yes = false;
            reloading = false;
            Busy = false;
            
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Zooming = !Zooming;
            if (Zooming){
                StartCoroutine(WaitingForZoom());
                animationGO.GetComponent<Animation>().Play("AimScope");

            }
            else { animationGO.GetComponent<Animation>().Play("ScopeOut"); }
        }
        if (Input.GetButtonDown("Fire1") && !Busy)
        {
            Busy = true;
            StartCoroutine(WaitingForShot());
            
            if (Zooming)
            {
                animationGO.GetComponent<Animation>().Play("Stun");
            }
        }

        if (Yes && Zooming)
        {
            animationGO.GetComponent<Animation>().Play("shake");
            Yes = false;
        }

      if (Yes && !Zooming)
       { Yes = false; }

        if (Zooming && Input.GetKeyDown("r"))
        {
            animationGO.GetComponent<Animation>().Play("ScopeOut");
            Zooming = false;
            //reloading = true;
        }

    }
       
    IEnumerator WaitingForZoom () {
        yield return new WaitForSeconds(0.4166f);
        Ready = true;
    }

    IEnumerator WaitingForShot() {
        yield return new WaitForSeconds(0.7f);
        Yes = true;
        yield return new WaitForSeconds(1.065f);
        Busy = false;
    }


    void Toggle (bool toggle)
    {
        C_Left_Hand.SetActive(toggle);
        C_Right_Hand.SetActive(toggle);
        Dummy01.SetActive(toggle);
        Dummy02.SetActive(toggle);
        Hand.SetActive(toggle);
    }

    void OnGUI()
    {
        if (NormalCamera.GetComponent<Camera>().enabled)
        {
            if (Zooming)
            {
                if (Ready)
                {
                    if (CrosshairZoom)
                    {
                        float scopeSize = (Screen.height * 1.8f);
                        GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (scopeSize * 0.5f), (Screen.height * 0.5f) - (scopeSize * 0.5f), scopeSize, scopeSize), CrosshairZoom);
                        Toggle(false);
                    }
                }
            } else {
                Ready = false;
                if (C_Left_Hand.activeSelf == false) { Toggle(true); }
            }     
        }
    }
}



