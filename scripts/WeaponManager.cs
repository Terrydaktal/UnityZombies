using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

    public bool displayM24;
    public bool displayACR;
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

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Analyse(hit.collider.gameObject.name);
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

    void Analyse(string name)
    {
        if (name == "M24Quad" || name == "ACRQuad")
        {
            switch (name) {
                case "M24Quad": displayM24 = true; break;
                case "ACRQuad": displayACR = true; break;                  
        }
            if (Input.GetKeyDown("e"))
            {
                Compare(equipped);
                equippedWeapon.SetActive(false);
                if (currentWeapons.Count == 2)
                {
                    currentWeapons.Remove(equipped);
                    currentWeapons.Add(name.Replace("Quad","_fp"));
                }
                else { currentWeapons.Add(name.Replace("Quad", "_fp"));}

                equipped = name.Replace("Quad", "_fp");

                Compare(equipped);
                equippedWeapon.SetActive(true);
                EndOfWallBuy();
            }
        }
        else {
            displayM24 = false;
            displayACR = false;
        }
    }

    void OnGUI()
    {
        if (displayM24)
        {
            GUI.Label(new Rect(Screen.width - (Screen.width / 1.7f), Screen.height - (Screen.height / 1.4f), 1000, 200), "Press & Hold E to buy M24 [Cost: 1500]");
        }

        if (displayACR)
        {
            GUI.Label(new Rect(Screen.width - (Screen.width / 1.7f), Screen.height - (Screen.height / 1.4f), 1000, 200), "Press & Hold E to buy ACR [Cost: 2500]");
        }
    }


}
