using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour {
    Animator controller;
    // Use this for initialization
    void Start () {
        controller = GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void HitByRaycast(int damage)
    {
        controller.SetInteger("health", controller.GetInteger("health")-damage);
        print("yes");
    }
}
