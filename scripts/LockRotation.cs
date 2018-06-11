using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

	Quaternion rotation;
    public AudioSource rain;
    public AudioSource raindrops;
    public bool notPlaying = true;
	void Awake()
	{
		rotation = transform.rotation;
	}
	
	void LateUpdate()
	{
		transform.rotation = rotation;
	}

    void Update()
    {
        if (notPlaying)
        {
            notPlaying = false;
           // rain.Play();
            raindrops.Play();
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(39);
        notPlaying = true;
    }
}
