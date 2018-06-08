using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour {
    RaycastHit hit;
    bool Window;
    int boards = 0;
	// Use this for initialization
	void Start () {
        Window = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.transform.tag == "SpawnWall")
            {
                boardScript script = hit.transform.GetComponent<boardScript>();
                boards = script.boards;

                if (boards < 6)
                {
                    Window = true;
                    if (Input.GetKeyDown("e"))
                    {
                        hit.transform.SendMessage("Acknowledge", SendMessageOptions.DontRequireReceiver);
                    }
                }

                else
                {
                    Window = false;
                }
            }
            else
            {
                Window = false;
            }
        } 
	}

    private void OnGUI()
    {
        if (Window)
        {
            GUI.Label(new Rect(Screen.width - (Screen.width / 1.7f), Screen.height - (Screen.height / 1.4f), 1000, 200), "Press & Hold E to rebuild barrier");
        }

    }
}
