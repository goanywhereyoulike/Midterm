using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int selectedweapon = 0;
    // Update is called once per frame
    private void Start()
    {
        SelectWeapon();
    }
    void Update()
    {
        int preselect = selectedweapon;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedweapon = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedweapon = 1;


        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            selectedweapon = 2;

        }
        if (preselect != selectedweapon)
        {
            SelectWeapon();
        }
        
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedweapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }
}
