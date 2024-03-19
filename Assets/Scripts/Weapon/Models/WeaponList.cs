using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponList
{
    public List<Weapon> weapons;

    public WeaponList()
    {
        this.weapons = new List<Weapon>();
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }
    public void AddWeapon(GameObject gun, bool isPurchased, int ammunition, int price, Sprite weaponSprite, string name)
    {
        Weapon weapon = new Weapon(gun, isPurchased, ammunition, price, weaponSprite, name);
        weapons.Add(weapon);
    }

    public void RemoveWeapon(Weapon weapon)
    {
        weapons.Remove(weapon);
    }
    public Weapon FindWeaponBySprite(Sprite sprite)
    {
        foreach (var weapon in weapons)
        {
            if (weapon.weaponSprite.name.Equals(sprite.name))
            {
                return weapon;
            }
        }
        return null;
    }
    public void SetWeaponPurchased(Weapon weapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var wpn = weapons[i];
            //Finds whe bullet to change
            if (wpn.name.Equals(weapon.name))
            {
                weapon.isPurchased = true;
                //Updates it in the list
                weapons[i] = weapon;
            }
        }
    }

    public int UpdateWeapon(GameObject gun, int ammunition)
    {
        for(int i = 0;i < weapons.Count;i++) { 
        var wpn = weapons[i];

            //Finds the gun
            if (wpn.gun == gun) {
                wpn.ammunition += ammunition;
                weapons[i] = wpn;

                //returns the new bullets' number
                return wpn.ammunition;
            }
        }
        return 0;
    }
    public void UpdateWeapon(Weapon weapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var wpn = weapons[i];
            //Finds whe bullet to change
            if (wpn.name.Equals(weapon.name))
            {
                //Updates it in the list
                weapons[i] = weapon;
            }
        }
    }
    public Weapon GetWeapon(int index)
    {
        return weapons[index];
    }


    public Weapon GetWeapon(GameObject gun)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var wpn = weapons[i];

            if (wpn.gun==gun)
            {
                return wpn;
            }
        }
        return null;
    }


}
