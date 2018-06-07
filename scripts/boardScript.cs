using UnityEngine;
using System.Collections;

public class boardScript : MonoBehaviour {
	public int boards, previousBoards;
	public Animator[] boardAnim;
    public GameObject board1;
    public GameObject board2;
    public GameObject board3;
    public GameObject board4;
    public GameObject board5;
    public GameObject board6;
    GameObject[] boardObjects = new GameObject[6];

	// Use this for initialization
	void Start () {
		boardAnim = GetComponentsInChildren<Animator> ();
        boardObjects[0] = board1;
        boardObjects[1] = board2;
        boardObjects[2] = board3;
        boardObjects[3] = board4;
        boardObjects[4] = board5;
        boardObjects[5] = board6;
	}
	
	// Update is called once per frame
	void Update () {
		if(boards !=previousBoards)
		{
			previousBoards = boards;
			switch(boards)
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

    void Acknowledge ()
    {
        if (boards < 6) boards += 1;
        print("no boards : " + boards);
    }

    private void RemoveBoard() //verification in other script
    {
        if (boards > 0)
        {
            print("removing board");
            boardAnim[boards - 1].Play("boardAnimation" + boards);
            boardObjects[boards - 1].SendMessage("DisableBoard", SendMessageOptions.RequireReceiver);
            boards -= 1;
        }

    }

    private void RequestBoardUpdate(GameObject Mesh)
    {
       Mesh.SendMessage("ReceiveBoardAmount", boards, SendMessageOptions.RequireReceiver);
    }

}
