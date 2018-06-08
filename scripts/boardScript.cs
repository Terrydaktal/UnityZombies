using UnityEngine;
using System.Collections;

public class boardScript : MonoBehaviour
{
    public int boards, previousBoards;
    public Animator[] boardAnim;
    public GameObject[] boardObjects;

    // Use this for initialization
    void Start()
    {
        boardAnim = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boards != previousBoards)
        {
            previousBoards = boards;
            switch (boards)
            {

                case 1:
                    boardAnim[0].Play("boardAnimation1");
                    return;
                case 2:
                    boardAnim[1].Play("boardAnimation2");
                    return;
                case 3:
                    boardAnim[2].Play("boardAnimation3");
                    return;
                case 4:
                    boardAnim[3].Play("boardAnimation4");
                    return;
                case 5:
                    boardAnim[4].Play("boardAnimation5");
                    return;
                case 6:
                    boardAnim[5].Play("boardAnimation6");
                    return;
            }
        }
    }

    void Acknowledge()
    {
        if (boards < 6) boards += 1;
        print("no boards : " + boards);
        boardObjects[boards - 1].SetActive(true);
        boardObjects[boards - 1].SendMessage("EnableBoard", SendMessageOptions.DontRequireReceiver);
    }

    private void RemoveBoard() //verification in other script
    {
        if (boards > 0)
        {
            print("removing board");
            Invoke("preDisableBoard", 5.4f);
            Invoke("DisableBoard", 6f);
        }

    }

    private void preDisableBoard()
    {
        boardAnim[boards - 1].Play("boardRemoval");
        boardObjects[boards - 1].SendMessage("DisableBoard", SendMessageOptions.DontRequireReceiver);
    }

    private void DisableBoard()
    {
        boardObjects[boards - 1].SetActive(false);
        boards -= 1;
    }


}
