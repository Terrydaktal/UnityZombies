using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {
    NavMeshAgent nav;
    Transform player;
    Animator controller;
    AudioSource[] audios;
    int localHealth = 100;
    public bool attacking = false;
    public bool death = false;
    public GameObject FPSCamera;

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
                    death = true;
                }
            } 
        }
         print(Mathf.Abs(Vector3.Distance(player.position, this.transform.position)));
         if (Mathf.Abs(Vector3.Distance(player.position, this.transform.position)) < 2.65 && !attacking && !death)
          {
            attacking = true;
            controller.speed = 1.5f;
            controller.Play("attack2");
            audios[Random.Range(11, 20)].Play();
            Invoke("CheckHit", 0.3f);
            StartCoroutine(WaitForAttackEnd());
         }

        // controller.SetFloat("speed", Mathf.Abs (nav.velocity.x) + Mathf.Abs(nav.velocity.z));

    }

    IEnumerator WaitForAttackEnd()
    {
        yield return new WaitForSeconds(1.6f);
        attacking = false;
    }

    void CheckHit()
    {
        if(Mathf.Abs(Vector3.Distance(player.position, this.transform.position)) < 3.5 && !death)
        {
            controller.speed = 1f;
            PlayerManager pm = FPSCamera.GetComponent<PlayerManager>();
            pm.health -= 49;

        }
    }
}
