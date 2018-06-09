using UnityEngine;
using System.Collections;

public class playAnimation : MonoBehaviour {
	ParticleSystem[] dust;
    public GameObject thisboard;
    public AudioSource boardbreak;
    public AudioSource windowbuild;
	// Use this for initialization
	void Start () {
		dust = GetComponentsInChildren<ParticleSystem> ();
    }
	
	void EnableBoard() {
        windowbuild.Play();
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
