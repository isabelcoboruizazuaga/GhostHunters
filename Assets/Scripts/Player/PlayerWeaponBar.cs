using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponBar : MonoBehaviour
{
    //Weapons
    public Weapon activeWeapon;
    public Image[] weaponImageInBar = new Image[4];

    //Bullet
    public Image bulletImage;
    public TextMeshProUGUI bulletTxt;
    public Sprite[] bulletsSource = new Sprite[4];
    private GameManager gameManager;

    //Medical kit
    public TextMeshProUGUI medicalNumberTxt;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Set isActive bullet
        var weapon = gameManager.weaponList.GetWeapon(0);
        activeWeapon = weapon;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
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
        Weapon weapon = gameManager.weaponList.GetWeapon(index);

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
     *Shows in the ui the selected bullet avaliable bullets
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

    public void UpdateBullets(string bullets)
    {
        bulletTxt.text = bullets.ToString();
    }

    //Set the purchased bullet to bought in the bar
    public void BuyWeapon(Weapon weapon)
    {
        gameManager.weaponList.SetWeaponPurchased(weapon);
        EnableWeaponImageInBar(weapon.weaponSprite);

    }

    public void BuyBullets(Bullet bullet)
    {
        int ammunition= gameManager.weaponList.UpdateWeapon(bullet.gun, bullet.quantity);

        //If we're buying for the active weapon we need to update the bullet number
        if (bullet.gun == activeWeapon.gun)
        {
            UpdateBullets(ammunition.ToString());
        }
    }

    public void BuyMedicalKit()
    {
        gameManager.medicalKit++;
        SetMedicalImage(true);
    }

    public void ConsumeMedicalKit()
    {
        if (--(gameManager.medicalKit) <= 0)
        {
            SetMedicalImage(false);
        }
        else
        {
            SetMedicalImage(true);
        }

    }

    //Sets  the image of the given bullet in bullet bar   
    public void EnableWeaponImageInBar(Sprite sprite)
    {
        for (int i = 0; i < weaponImageInBar.Length; i++)
        {
            if (weaponImageInBar[i].GetComponent<Image>().sprite==sprite){
                weaponImageInBar[i].GetComponent<Image>().enabled = true;
            }
        }   
    }

    public void SetMedicalImage(bool isActive)
    {
        weaponImageInBar[3].GetComponent<Image>().enabled = isActive;
        medicalNumberTxt.enabled = isActive;
        medicalNumberTxt.text = "x"+gameManager.medicalKit.ToString();
    }
  

}
