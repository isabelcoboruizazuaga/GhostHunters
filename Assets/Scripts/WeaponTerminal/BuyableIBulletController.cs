using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BuyableIBulletController : MonoBehaviour
{
    private TerminalUI terminalUI;
    private Button buyBtn;

    //Component members
    private Image image;
    public TextMeshProUGUI priceTxt;

    //Player Controller
    private PlayerMovement playerController;
    private PlayerWeaponBar playerWeaponBar;

    private GameManager gameManager;
    public Bullet bullet;
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

        //Sets this bullet object using the Sprite as an id
        try
        {
            this.bullet = gameManager.bulletList.FindBulletBySprite(image.sprite);
            priceTxt.text = bullet.price.ToString() + "$";
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
        terminalUI.SetBuy(this.bullet);

        //Ensure the player has money and the necessary gun is purchased
        if (playerController.money >= this.bullet.price && (gameManager.weaponList.GetWeapon(bullet.gun).isPurchased))
        {
            //Set active the buy button
            buyBtn.enabled = true;
            buyBtn.onClick.AddListener(Buy);
        }
    }

    public void Buy()
    {
        //Substract player money
        playerController.money -= this.bullet.price;
        playerController.addCoins(0);

        //Update the weapon ammunition
        playerWeaponBar.BuyBullets(this.bullet);

        //Clean buy section
        terminalUI.Clear();
        buyBtn.onClick.RemoveListener(Buy);
    }
}
