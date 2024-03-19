using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyableItemController : MonoBehaviour
{
    private TerminalUI terminalUI;
    private Button buyBtn;

    //Component members
    public int price=10;
    private Image image;
    public TextMeshProUGUI priceTxt;

    //Player Controller
    private PlayerMovement playerController;
    private PlayerWeaponBar playerWeaponBar;

    private GameManager gameManager;
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
        priceTxt.text = price.ToString() + "$";

        //Initializa
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ObjectClicked()
    {
        //Clean other listeners
        buyBtn.onClick.RemoveListener(Buy);

        //Set the object to buy in the buying interface
        terminalUI.SetBuy(image.sprite, price);

        //Ensure the player has money and the necessary gun is purchased
        if (playerController.money >= price)
        {
            //Set active the buy button
            buyBtn.enabled = true;
            buyBtn.onClick.AddListener(Buy);
        }
    }

    public void Buy()
    {
        //Substract player money
        playerController.money -= price;
        playerController.addCoins(0);

        //Update the weapon ammunition
        playerWeaponBar.BuyMedicalKit();

        //Clean buy section
        terminalUI.Clear();
        buyBtn.onClick.RemoveListener(Buy);
    }
}
