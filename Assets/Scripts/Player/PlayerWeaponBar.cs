using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBar : MonoBehaviour
{
    //public List<(GameObject,bool, int)[]> weapons=new List<(GameObject, bool, int)[]>();
    public List<object[]> weapons = new List<object[]>(); //{ {gun,purchased, ammunition}, {gun,purchased, ammunition}}
    public GameObject activeWeapon;
    public Dictionary<GameObject, (bool, int)[]> a = new Dictionary<GameObject, (bool, int)[]>();

    // Start is called before the first frame update
    void Start()
    {
        //Initialize list of weapons
        FillList();

        //Set active weapon
        var weapon = weapons[0];
        activeWeapon = (GameObject)weapon[0];
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            //changeWeapon()
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                changeWeapon(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                changeWeapon(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                changeWeapon(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                changeWeapon(3);
            }
        }
    }

    public void changeWeapon(int position)
    {
        var weaponObject = weapons[position];
        bool purchased = (bool)weaponObject[1];
        if (purchased)
        {
            activeWeapon.SetActive(false);

            activeWeapon = (GameObject)weaponObject[0];

            activeWeapon.SetActive(true);
        }
    }

    public void BuyWeapon(int price)
    {
        var weapon = GameObject.Find("OldGun");
        switch (price)
        {
            case 20:
                weapon = (GameObject)weapons[1][0];
                UpdateWeapon(1, (GameObject)weapons[1][0], true, 10);
                break;
            case 50:
                weapon = GameObject.Find("SemiAutomaticGun");
                UpdateWeapon(2, (GameObject)weapons[2][0], true, 10);
                break;
            case 100:
                weapon = GameObject.Find("SemiAutomaticGun");
                UpdateWeapon(3, (GameObject)weapons[3][0], true, 50);
                break;
        }
    }

    private void FillList()
    {
        var weapon = GameObject.Find("OldGun");
        AssignGun(weapon, true, -1);
        weapon.SetActive(true);

        weapon = GameObject.Find("Gun");
        AssignGun(weapon, false, 10);
        weapon.SetActive(false);

        weapon = GameObject.Find("PowerGun");
        AssignGun(weapon, false, 10);
        weapon.SetActive(false);

        weapon = GameObject.Find("SemiAutomaticGun");
        AssignGun(weapon, false, 10);
        weapon.SetActive(false);
    }

    /**
     * Gives a weapon format to be added to the weapons' list
     */
    private void AssignGun(GameObject weapon, bool purchased, int amunition)
    {
        object[] weaponObject = { weapon, purchased, amunition };
        weapons.Add(weaponObject);
    }

    public void UpdateWeapon(int position, GameObject weapon, bool purchased, int amunition)
    {
        object[] weaponObject = { weapon, purchased, amunition };
        weapons[position] = weaponObject;
    }

}
