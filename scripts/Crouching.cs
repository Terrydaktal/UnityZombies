using UnityEngine;

public class Crouching : MonoBehaviour
{

    CharacterController characterCollider;

    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();

    }

    private void Update()
    {
       
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterCollider.height = 0.7f;
        } else
        {
            characterCollider.height = 1.6f;
        }
    }
}
