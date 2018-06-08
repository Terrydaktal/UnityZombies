using UnityEngine;
using System.Collections;

public class playAnimation : MonoBehaviour {
	ParticleSystem[] dust;
    public GameObject thisboard;
    public AudioSource boardbreak;
	// Use this for initialization
	void Start () {
		dust = GetComponentsInChildren<ParticleSystem> ();
    }
	
	void EnableBoard() { 
        dust[0].Play();
        dust[1].Play();
		}

void DisableBoard()
    {
        dust[0].Play();
        dust[1].Play();
        boardbreak.Play();
      //  thisboard.GetComponent<Renderer>().enabled = false;
    }
}
