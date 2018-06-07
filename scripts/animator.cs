using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animator : MonoBehaviour {
    Animator controller;
    int boards = 1;
    NavMeshAgent nav;
    RaycastHit hit;
    public GameObject Mesh;
    public GameObject SpawnWall;
    public bool WaitingForNextBoard;
    public bool Stopped = false;

    // Use this for initialization
    void Start () {
        controller = GetComponentInParent<Animator>();
        nav = GetComponentInParent<NavMeshAgent>();
        WaitingForNextBoard = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, Vector3.down, out hit)) {
            SpawnWall.SendMessage("RequestBoardUpdate", Mesh, SendMessageOptions.DontRequireReceiver);
            print(hit.transform.tag);
            if (hit.transform.tag == "SpawnWallZombieSide")
            {
                print(boards);
                if (boards > 0 && !WaitingForNextBoard)
                {
                    WaitingForNextBoard = true;
                    Invoke("RemoveBoard", 1.5f);
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

    private void RemoveBoard()
    {
        print("boards > 0");
        if (!Stopped) nav.isStopped = true;
        SpawnWall.SendMessage("RemoveBoard", SendMessageOptions.DontRequireReceiver);
        WaitingForNextBoard = false;
    }

    void ReceiveBoardAmount(int boardsRemaining)
    {
        boards = boardsRemaining;
    }

    void HitByRaycast(int damage)
    {
        controller.SetInteger("health", controller.GetInteger("health")-damage);
        print("yes");
    }
}
