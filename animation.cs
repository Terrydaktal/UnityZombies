using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : StateMachineBehaviour {
    void AlertObservers(string message)
    {
        if (message.Equals("complete"))
        {
            GameObject.FindGameObjectWithTag("EnemyMesh").transform.position = GameObject.FindGameObjectWithTag("Enemy").transform.position;

        }
    }
}
