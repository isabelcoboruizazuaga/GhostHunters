using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyableItemController : MonoBehaviour
{
    private TerminalUI terminalUI;
    private Button buyBtn;

    //Component members
    private Image image;
    public int price = 200;
    public int quantity = 1;
    public TextMeshProUGUI priceTxt;

    //Player Controller
    private PlayerMovement playerController;
    private PlayerWeaponBar playerWeaponBar;

    // Start is called before the first frame update
    void Start()
    {
        terminalUI = GameObject.Find("WeaponShopUI").GetComponent<TerminalUI>();
        buyBtn = GameObject.Find("BuyButton").GetComponent<Button>();
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerWeaponBar = GameObject.Find("Player").GetComponent<PlayerWeaponBar>();

        //Setting of this component members
        priceTxt = GetComponentInChildren<TextMeshProUGUI>();
        priceTxt.text = price.ToString();
        image = this.GetComponent<Image>();

    }

    public void ObjectClicked()
    {
        //Clean other listeners
        buyBtn.onClick.RemoveListener(Buy);

        //Set the object to buy in the buying interface
        terminalUI.SetBuy(image,price);

        //Ensure the player has money
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

        //Make weapon active in weapon bar
        playerWeaponBar.BuyWeapon(price);

        //Clean buy section
        terminalUI.Clear();
        buyBtn.onClick.RemoveListener(Buy);
    }

}
