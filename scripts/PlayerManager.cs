using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 100;
    public int localHealth = 100;
    public bool dead = false;
    public RainCameraController SplatterBloodCamera;
    public RainCameraController FrameBloodCamera;
    public BloodRainCameraController bloodRainController;
    public AudioSource hitSound;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
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
            StopAllCoroutines();
            StartCoroutine(WaitingForRegen());
        }

        if (health < 0 && !dead)
        {
            dead = true;
            StopAllCoroutines();
            this.GetComponent<Animation>().Play("death");

        }

        if (dead)
        {
            Invoke("EndGame", 4.0f);
        }
    }

    IEnumerator WaitingForRegen()
    {
        yield return new WaitForSeconds(10f);
        bloodRainController.Reset();
        bloodRainController.HP = 100;
        health = 100;
        localHealth = 100;
    }

    void EndGame()
    {
        Application.Quit();
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 20;
        if (dead)
        {
            GUI.skin.label.fontSize = 40;
            GUI.Label(new Rect(Screen.width - (Screen.width / 1.7f), Screen.height - (Screen.height / 1.4f), 1000, 200), "Game Over");
        }
    }
}
