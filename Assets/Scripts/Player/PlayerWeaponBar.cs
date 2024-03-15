using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponBar : MonoBehaviour
{
    //Weapons
    public List<object[]> weapons = new List<object[]>(); //{ {gun,purchased, ammunition}, {gun,purchased, ammunition}}
    public GameObject activeWeapon;
    public object[] activeWeaponObjectComplete;
    public Dictionary<GameObject, (bool, int)[]> a = new Dictionary<GameObject, (bool, int)[]>();
    public Image[] weaponImageInBar = new Image[4];

    //Bullets
    public Image bulletImage;
    public TextMeshProUGUI bulletTxt;
    public Sprite[] bulletsSource = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        //Initialize list of weapons
        FillList();

        //Set active weapon
        var weapon = weapons[0];
        activeWeaponObjectComplete = weapon;
        activeWeapon = (GameObject)weapon[0];
        ShowWeaponBullets(0, weapon);
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
            //Activar el arma
            activeWeapon.SetActive(false);

            activeWeapon = (GameObject)weaponObject[0];
            activeWeaponObjectComplete = weaponObject;

            activeWeapon.SetActive(true);

            //Mostrar las balas
            ShowWeaponBullets(position, weaponObject);
        }
    }

    /*
     *Shows in the ui the selected weapon avaliable bullets
     */
    public void ShowWeaponBullets(int position, object[] weaponObject)
    {
        bulletImage.GetComponent<Image>().sprite = bulletsSource[position];
        if (position != 0)
        {
            bulletTxt.text = ((int)weaponObject[2]).ToString(); //WeaponObject-> {weapon, purchased, ammunition}
        }
        else
        {
            bulletTxt.text = "\u221E";
        }
    }

    public void UpdateBullets(string bullets, object[] activeWeaponObject)
    {
        bulletTxt.text = bullets.ToString();
        this.activeWeaponObjectComplete = activeWeaponObject;
        UpdateWeapon(activeWeaponObject);
    }

    //Set the purchased weapon to bought in the bar
    public void BuyWeapon(int price)
    {
        var weapon = GameObject.Find("OldGun");
        switch (price)
        {
            case 20:
                weapon = (GameObject)weapons[1][0];
                UpdateWeapon(1, (GameObject)weapons[1][0], true, 10);
                //Set visible
                EnableWeaponImageInBar(1);
                break;
            case 50:
                weapon = GameObject.Find("SemiAutomaticGun");
                UpdateWeapon(2, (GameObject)weapons[2][0], true, 10);
                EnableWeaponImageInBar(2);
                break;
            case 100:
                weapon = GameObject.Find("SemiAutomaticGun");
                UpdateWeapon(3, (GameObject)weapons[3][0], true, 50);
                EnableWeaponImageInBar(3);
                break;
        }
    }

    //Sets active the image of the given weapon in weapon bar   
    public void EnableWeaponImageInBar(int position)
    {
        weaponImageInBar[position - 1].GetComponent<Image>().enabled = true;
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

    /*
     * Updates a weapon based on the given index
     */
    public void UpdateWeapon(int position, GameObject weapon, bool purchased, int amunition)
    {
        object[] weaponObject = { weapon, purchased, amunition };
        weapons[position] = weaponObject;
    }

    /*
     *Updates a weapon in the list based on the weapon Game Object of the given object
     */
    public void UpdateWeapon(object[] weaponComplete)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var item = weapons[i]; 
            //Encuentra el objeto basándose en el arma
            if (item[0] == weaponComplete[0])
            {
                //Lo sustituye por el objeto pasado
                weapons[i] = weaponComplete;
            }
        }
    }

}
