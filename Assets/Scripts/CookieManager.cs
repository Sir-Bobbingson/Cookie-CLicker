using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieManager : MonoBehaviour
{
    [SerializeField] private int cookies = 0;
    [SerializeField] private int cookiesPerClick = 1;
    [SerializeField] private int cookiesPerHelper = 1;
    [SerializeField] private Text cookieText;
    [SerializeField] private Text upgradeText;
    [SerializeField] private Text helperText;
    [SerializeField] private Text noOfHelpersText;

    //upgrades
    private int costToUpgrade = 5;
    private int costToBuy = 100;
    private int noOfHelpers = 0;


    private void Start()
    {
        UpdateCookieText();
        UpdateUpgradeText();
        UpdateHelperText();
        UpdateNoOfHelpersText();
    }

    public void AddCookie()
    {
        cookies += cookiesPerClick;
        UpdateCookieText();
    }

    public void Helpers()
    {
        cookies += cookiesPerHelper;
        UpdateCookieText();
    }

    public void UpgradeCookiesPerClick()
    {
        if(cookies >= costToUpgrade)
        {
            cookies -= costToUpgrade;
            cookiesPerClick++;
            UpdateCookieText();
            costToUpgrade = costToUpgrade * 2;
            UpdateUpgradeText();
        }
            
    }

    private void UpdateCookieText()
    {
        if (cookieText != null)
        {
            switch (cookies)
            {
                case 0:
                    cookieText.text = "No Cookies :(";
                    break;
                case 1:
                    cookieText.text = "1 Cookie";
                    break;
                default:
                    cookieText.text = cookies + " Cookies";
                    break;
            }

        }
        else
        {
            Debug.Log("Cookie Text Not Set");
        }
    }

    private void UpdateUpgradeText()
    {
        upgradeText.text = "Upgrade Cost: " + costToUpgrade;
    }

    private void UpdateHelperText()
    {
        helperText.text = "Helper Cost: " + costToBuy;
    }

    private void UpdateNoOfHelpersText()
    {
        noOfHelpersText.text = "Number Of Helpers: " + noOfHelpers;
    }

    public void AddHelper()
    {
        if (cookies >= costToBuy)
        {
            cookies -= costToBuy;
            UpdateCookieText();
            InvokeRepeating("Helpers", 1.0f, 1.0f);
            if (costToBuy == 100) 
            {
                costToBuy = costToBuy * 5;
            }
            else
            {
                costToBuy = costToBuy + 500;
            }
            UpdateHelperText();

            noOfHelpers++;
            UpdateNoOfHelpersText();
        }
    }

}
