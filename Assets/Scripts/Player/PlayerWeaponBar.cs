using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBar : MonoBehaviour
{
    //public List<(GameObject,bool, int)[]> weapons=new List<(GameObject, bool, int)[]>();
    public List<object[]> weapons=new List<object[]>();
    public GameObject activeWeapon;
    public Dictionary<GameObject, (bool, int)[]> a = new Dictionary<GameObject, (bool, int)[]>();

    // Start is called before the first frame update
    void Start((GameObject, bool, int)[] values)
    {
        var weapon = weapons[0];
        activeWeapon = (GameObject)weapon[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Alpha2)|| Input.GetKeyDown(KeyCode.Alpha3)|| Input.GetKeyDown(KeyCode.Alpha4))
        {
            //ALpha1= 49, alpha2= 50, ..., alpha4=52
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
        activeWeapon.SetActive(false);
        var weapon = weapons[position];
        activeWeapon = (GameObject)weapon[0];
        activeWeapon.SetActive(true);
    }
}
