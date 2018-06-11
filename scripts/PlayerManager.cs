using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 100;
    public int localHealth = 100;
    public RainCameraController SplatterBloodCamera;
    public RainCameraController FrameBloodCamera;
    public BloodRainCameraController bloodRainController;
    public AudioSource hitSound;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (localHealth != health)
        {
            SplatterBloodCamera.Play();
            //FrameBloodCamera.Play();
            hitSound.Play();
            bloodRainController.Attack(49);
            localHealth = health;
        }

        //if (health = 51
    }
}
