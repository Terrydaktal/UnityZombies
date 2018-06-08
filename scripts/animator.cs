using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animator : MonoBehaviour
{
    Animator controller;
    int boards = 1;
    NavMeshAgent nav;
    RaycastHit hit;
    public bool WaitingForNextBoard;
    public bool Stopped = false;

    // Use this for initialization
    void Start()
    {
        controller = GetComponentInParent<Animator>();
        nav = GetComponentInParent<NavMeshAgent>();
        WaitingForNextBoard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.transform.tag == "SpawnWallZombieSide")
            {
                boardScript script = hit.transform.parent.gameObject.GetComponent<boardScript>();
                boards = script.boards;
                print(boards);
                if (boards > 0 && !WaitingForNextBoard)
                {
                    WaitingForNextBoard = true;
                    RemoveBoard(hit.transform);
                }

                if (boards < 1)
                {
                    print("happens");
                    nav.isStopped = false;
                    Stopped = false;
                }
            }

        }

    }

    private void RemoveBoard(Transform transform)
    {
        print("boards > 0");
        if (!Stopped) { nav.isStopped = true; }
        transform.parent.gameObject.SendMessage("RemoveBoard", SendMessageOptions.DontRequireReceiver);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6f);
        WaitingForNextBoard = false;
    }

    void HitByRaycast(int damage)
    {
        controller.SetInteger("health", controller.GetInteger("health") - damage);
        print("yes");
    }
}
