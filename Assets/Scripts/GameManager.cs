using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite oldGun, gun, powerGun, semiAutomaticGun;
    public WeaponList weaponList = new WeaponList();
    // Start is called before the first frame update
    void Start()
    {
        weaponList = new WeaponList();
        CreateWeapons();
    }

    private void CreateWeapons()
    { 
        GameObject weaponGo = GameObject.Find("OldGun");
        weaponList.AddWeapon(weaponGo,true,-1,0,oldGun);
        weaponGo.SetActive(true);

        weaponGo = GameObject.Find("Gun");
        weaponList.AddWeapon(weaponGo,false,10,20, gun);
        weaponGo.SetActive(true);

        weaponGo = GameObject.Find("PowerGun");
        weaponList.AddWeapon(weaponGo,false,10,50,powerGun);
        weaponGo.SetActive(true);

        weaponGo = GameObject.Find("SemiAutomaticGun");
        weaponList.AddWeapon(weaponGo, false, 50, 100, semiAutomaticGun);
        weaponGo.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
