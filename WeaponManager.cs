using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

    public bool displayM24;
    public RaycastHit hit;
    public string equipped = "m9_fp";
    public List<string> currentWeapons = new List<string>();
    public GameObject[] Weapons;
    public GameObject equippedWeapon; //m9_fp
    public GameObject weapon1;
    public GameObject weapon2;


    void Start()
    {
        currentWeapons.Add("m9_fp");
    }

    void Update()
    {
        if (currentWeapons.Count == 2)
        {
            if (Input.GetKeyDown("1"))
            {
                weapon1.SetActive(true);
                equipped = currentWeapons[0]; 
                StartCoroutine(WaitingForWeapon());
            }

            if (Input.GetKeyDown("2"))
            {
                weapon2.SetActive(true);
                equipped = currentWeapons[1];
                StartCoroutine(WaitingForWeapon2());
            }
        }
    }
    void Compare(string param)
    {
        foreach (GameObject obj in Weapons)
        {
            if (obj.name == param)
            {
                equippedWeapon = obj;
            }
        }
    }

    private void EndOfWallBuy(){

        foreach (GameObject obj in Weapons)
        {
            if (obj.name == currentWeapons[0])
            {
                weapon1 = obj;
            }
        }

        foreach (GameObject obj in Weapons)
        {
            if (obj.name == currentWeapons[1])
            {
                weapon2 = obj;
                break;

            }
            else { weapon2 = weapon1; }
        }
    }

    IEnumerator WaitingForWeapon()
    {
        yield return new WaitForSeconds(0.05f);
        weapon2.SetActive(false);
    }

    IEnumerator WaitingForWeapon2()
    {
        yield return new WaitForSeconds(0.05f);
        weapon1.SetActive(false);
    }


    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.name == "M24Quad")
            {
                displayM24 = true;
                if (Input.GetKeyDown("e"))
                {
                    Compare(equipped);
                    equippedWeapon.SetActive(false);
                    if (currentWeapons.Count == 2) {
                        currentWeapons.Remove(equipped);
                        currentWeapons.Add("M24_Gun");
                    } else { currentWeapons.Add("M24_Gun"); }

                    equipped = "M24_Gun";

                    Compare(equipped);
                    equippedWeapon.SetActive(true);
                    EndOfWallBuy();
                }
            }
            else { displayM24 = false; }

        }

    }

    void OnGUI()
    {
        if (displayM24)
        {
            GUI.Label(new Rect(Screen.width - (Screen.width / 1.7f), Screen.height - (Screen.height / 1.4f), 1000, 200), "Press & Hold E to buy M24 [Cost: 1000]");
        }
    }


}