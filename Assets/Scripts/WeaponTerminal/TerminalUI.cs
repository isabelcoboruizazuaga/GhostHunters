using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    //General
    private TextMeshProUGUI playerMoneyTxt;
    Sprite blankImage;

    //Buy Section
    private Image buyImage;
    private TextMeshProUGUI buyTxt;
    private TextMeshProUGUI remainTxt;
    private TextMeshProUGUI playerBuyTxt; //Money the player has
    private Button buyBtn;

    //Player Controller
    private PlayerMovement playerController;

    // Start is called before the first frame update
    void Start()
    {
        //General
        playerController = GameObject.Find("Player").GetComponent<PlayerMovement>();
        blankImage = Resources.Load<Sprite>("BlankImage");
        playerMoneyTxt = GameObject.Find("PlayerMoney").GetComponent<TextMeshProUGUI>();

        //Buy Section
        buyImage = GameObject.Find("ImageSelected").GetComponent<Image>();
        playerBuyTxt = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        buyTxt = GameObject.Find("BuyText").GetComponent<TextMeshProUGUI>();
        remainTxt = GameObject.Find("RemainText").GetComponent<TextMeshProUGUI>();
        buyBtn = GameObject.Find("BuyButton").GetComponent<Button>();
    }

    //Fills the selected weapon in the buy section
    public void SetBuy(Weapon weapon)
    {
        buyImage.GetComponent<Image>().sprite = weapon.weaponSprite;
        buyTxt.text = weapon.price.ToString();
        remainTxt.text = (playerController.money - weapon.price).ToString();
    }

    //Fills the selected bullet in the buy section
    public void SetBuy(Bullet bullet)
    {
        buyImage.GetComponent<Image>().sprite = bullet.bulletSprite;
        buyTxt.text = bullet.price.ToString();
        remainTxt.text = (playerController.money - bullet.price).ToString();
    }

    public void Clear()
    {
        //Set everything
        buyImage.GetComponent<Image>().sprite = blankImage;
        playerMoneyTxt.text = (playerController.money).ToString();
        playerBuyTxt.text = (playerController.money).ToString();
        buyTxt.text = "0";
        buyBtn.enabled = false;
    }
}
