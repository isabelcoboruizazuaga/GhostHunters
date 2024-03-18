using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyableItemController : MonoBehaviour
{
    private TerminalUI terminalUI;
    private Button buyBtn;

    //Component members
    private Image image;
    public int quantity = 1;
    public TextMeshProUGUI priceTxt;

    //Player Controller
    private PlayerMovement playerController;
    private PlayerWeaponBar playerWeaponBar;

    private GameManager gameManager;
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        terminalUI = GameObject.Find("WeaponShopUI").GetComponent<TerminalUI>();
        buyBtn = GameObject.Find("BuyButton").GetComponent<Button>();
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerWeaponBar = GameObject.Find("Player").GetComponent<PlayerWeaponBar>();

        //Setting of this component members
        priceTxt = GetComponentInChildren<TextMeshProUGUI>();
        image = this.GetComponent<Image>();

        InitializeObject();
    }

    public void InitializeObject()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Sets this weapon object using the Sprite as an id
        try
        {
            this.weapon = gameManager.weaponList.FindWeaponBySprite(image.sprite);
            priceTxt.text = weapon.price.ToString();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
    public void ObjectClicked()
    {
        //Clean other listeners
        buyBtn.onClick.RemoveListener(Buy);

        //Set the object to buy in the buying interface
        terminalUI.SetBuy(this.weapon);

        //Ensure the player has money and the weapon is not alreade purchased
        if (playerController.money >= this.weapon.price && !this.weapon.isPurchased)
        {
            //Set active the buy button
            buyBtn.enabled = true;
            buyBtn.onClick.AddListener(Buy);
        }
    }

    public void Buy()
    {
        //Substract player money
        playerController.money -= this.weapon.price;
        playerController.addCoins(0);

        //Make weapon active in weapon bar
        playerWeaponBar.BuyWeapon(this.weapon);

        //Clean buy section
        terminalUI.Clear();
        buyBtn.onClick.RemoveListener(Buy);
    }

}
