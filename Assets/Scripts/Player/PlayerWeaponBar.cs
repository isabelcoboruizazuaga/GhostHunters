using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponBar : MonoBehaviour
{
    //Weapons
    public Weapon activeWeapon;
    public Image[] weaponImageInBar = new Image[4];

    //Bullets
    public Image bulletImage;
    public TextMeshProUGUI bulletTxt;
    public Sprite[] bulletsSource = new Sprite[4];
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Initialize list of weapons
        //FillList();
        gameManager.weaponList.SetOneWeaponActive(0);

        //Set active weapon
        var weapon = gameManager.weaponList.GetWeaponByIndex(0);
        activeWeapon = weapon;
        //ShowWeaponBullets(0, weapon);


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

    public void changeWeapon(int index)
    {
        Weapon weapon = gameManager.weaponList.GetWeaponByIndex(index);

        if (weapon.isPurchased)
        {
            //Activar el arma
            activeWeapon.gun.SetActive(false);

            activeWeapon = weapon;

            activeWeapon.gun.SetActive(true);

            //Mostrar las balas
           ShowWeaponBullets(index);
        }
    }

    /*
     *Shows in the ui the selected weapon avaliable bullets
     */
    public void ShowWeaponBullets(int position)
    {
        bulletImage.GetComponent<Image>().sprite = bulletsSource[position];
        if (position != 0)
        {
            bulletTxt.text = activeWeapon.ammunition.ToString();
        }
        else
        {
            bulletTxt.text = "\u221E";
        }
    }

    public void UpdateBullets(string bullets, object[] activeWeaponObject)
    {
        bulletTxt.text = bullets.ToString();
    }

    //Set the purchased weapon to bought in the bar
    public void BuyWeapon(Weapon weapon)
    {
        gameManager.weaponList.SetWeaponPurchased(weapon);
        EnableWeaponImageInBar(weapon.weaponSprite);

    }

    //Sets active the image of the given weapon in weapon bar   
    public void EnableWeaponImageInBar(Sprite sprite)
    {
        for (int i = 0; i < weaponImageInBar.Length; i++)
        {
            if (weaponImageInBar[i].GetComponent<Image>().sprite==sprite){
                weaponImageInBar[i].GetComponent<Image>().enabled = true;
            }
        }   
    }
    /*
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
    /*
    private void AssignGun(GameObject weapon, bool purchased, int amunition)
    {
        object[] weaponObject = { weapon, purchased, amunition };
        weapons.Add(weaponObject);
    }
    */

}
