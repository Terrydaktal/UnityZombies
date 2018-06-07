using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {
    NavMeshAgent nav;
    Transform player;
    Animator controller;
    int localHealth = 100;
    public AudioSource hitNoKill;
    public AudioSource hitKill;
    public AudioSource hitKill2;
    public AudioSource zombieDying;
    public AudioSource zombieDying2;
    public AudioSource zombieDying3;
    public AudioSource zombieDying4;
    public AudioSource zombieDying5;
    public AudioSource zombieDying6;
    public AudioSource zombieDying7;
    public AudioSource zombieDying8;
    public AudioSource zombieDying9;
    public AudioSource zombieDying10;
    public AudioSource[] audios;

    // Use this for initialization
    void Start() {
        audios = GetComponents<AudioSource>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (controller.GetInteger("health") > 1 && nav.name != "warzombie_f_pedroso@Zombie Idle")
        {
            nav.SetDestination(player.position);

        }

        if (localHealth > 1) { 

            if (controller.GetInteger("health") != localHealth)
            {

                localHealth = controller.GetInteger("health");
                audios[Random.Range(0, 3)].Play();
                if (localHealth < 1)
                {
                    audios[Random.Range(3, 11)].Play();
                }
            } 
        }


        // controller.SetFloat("speed", Mathf.Abs (nav.velocity.x) + Mathf.Abs(nav.velocity.z));

    }

}
