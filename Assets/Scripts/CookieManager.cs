using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieManager : MonoBehaviour
{
    [SerializeField] private int cookies = 0;
    [SerializeField] private int cookiesPerClick = 1;
    [SerializeField] private int cookiesPerHelper = 1;
    [SerializeField] private int cookiesPerBaker = 5;
    [SerializeField] private Text cookieText;
    [SerializeField] private Text upgradeText;
    [SerializeField] private Text helperText;
    [SerializeField] private Text noOfHelpersText;
    [SerializeField] private Text bakerText;
    [SerializeField] private Text noOfBakersText;
    [SerializeField] private Text achievementText;

    //upgrades
    private int costToUpgrade = 5;
    //helpers
    private int costToBuy = 100;
    private int noOfHelpers = 0;
    //bakers
    private int costToBake = 1000;
    private int noOfBakers = 0;
    //cookiemonster
    private int costToMonster = 25000;
    private bool monster = true;

    #region Achivement Variables
    public int achievementCounter = 0;
    private bool clickAchievement = false;
    private bool clickerAchievement = false;
    private bool clickMoreAchievement = false;
    private bool clickEvenMoreAchievement = false;
    private bool clickTheMostAchievement = false;
    private bool upgradeAchievement = false;
    private bool helperAchievement = false;
    private bool bakerAchievement = false;
    private bool monsterAchievement = false;
    private bool getALifeAchievement = false;
    #endregion

    #region Achievement Images
    public Image clickAch;
    public Image clickerAch;
    public Image clickMoreAch;
    public Image clickEvenMoreAch;
    public Image clickTheMostAch;
    public Image upgradeAch;
    public Image helperAch;
    public Image bakerAch;
    public Image monsterAch;
    public Image getALifeAch;
    #endregion

    #region Buttons
    public Button upgradeButton;
    public Button helperButton;
    public Button bakerButton;
    public Button monsterButton;
    #endregion

    #region Colours
    Color32 green = new Color32(0, 255, 109, 255);
    Color32 gray = new Color32(146, 146, 146, 255);
    Color32 blue = new Color32(0, 75, 255, 255);
    #endregion

    private void Start()
    {
        UpdateCookieText();
        UpdateUpgradeText();
        UpdateHelperText();
        UpdateNoOfHelpersText();
        UpdateBakerText();
        UpdateNoOfBakersText();
    }

    private void Update()
    {
        #region Button Colour
        if (cookies >= costToUpgrade)
        {
            upgradeButton.image.color = green;
        }
        else
        {
            upgradeButton.image.color = gray;
        }

        if (cookies >= costToBuy)
        {
            helperButton.image.color = green;
        }
        else
        {
            helperButton.image.color = gray;
        }

        if (cookies >= costToBake)
        {
            bakerButton.image.color = green;
        }
        else
        {
            bakerButton.image.color = gray;
        }

        if (cookies >= costToMonster)
        {
            monsterButton.image.color = blue;
        }
        else
        {
            monsterButton.image.color = gray;
        }
        #endregion

        #region Hidden Buttons
        if (cookies >= 800)
        {
            bakerButton.gameObject.SetActive(true);
        }

        if (cookies >= 2000 && monster == true)
        {
            monsterButton.gameObject.SetActive(true);
            monster = false;
        }
        #endregion
    }


    #region Cookies
    public void AddCookie()                         //Adds cookies per click
    {
        cookies += cookiesPerClick;
        UpdateCookieText();
    }


    private void UpdateCookieText()                 //Updates number of cookies
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
            #region Achievements
            if (cookies >= 1 && clickAchievement == false)
            {
                clickAch.gameObject.SetActive(true);
                clickAchievement = true;

                UpdateAchievementText();
            }

            if (cookies >= 10 && clickerAchievement == false)
            {
                clickerAch.gameObject.SetActive(true);
                clickerAchievement = true;
                UpdateAchievementText();
            }

            if (cookies >= 100 && clickMoreAchievement == false)
            {
                clickMoreAch.gameObject.SetActive(true);
                clickMoreAchievement = true;
                UpdateAchievementText();
            }

            if (cookies >= 1000 && clickEvenMoreAchievement == false)
            {
                clickEvenMoreAch.gameObject.SetActive(true);
                clickEvenMoreAchievement = true;
                UpdateAchievementText();
            }

            if (cookies >= 10000 && clickTheMostAchievement == false)
            {
                clickTheMostAch.gameObject.SetActive(true);
                clickTheMostAchievement = true;
                UpdateAchievementText();
            }

            if (cookies >= 1000000 && getALifeAchievement == false)
            {
                getALifeAch.gameObject.SetActive(true);
                getALifeAchievement = true;
                UpdateAchievementText();
            }
            #endregion
        }
    }
    #endregion

    #region Upgrade
    public void UpgradeCookiesPerClick()
    {
        if (cookies >= costToUpgrade)                //Checks if player can afford upgrade
        {
            cookies -= costToUpgrade;               //Takes cost from cookies
            cookiesPerClick++;                      //Increases cookies per click
            UpdateCookieText();
            costToUpgrade = costToUpgrade * 2;      //Increases cost of upgrade
            UpdateUpgradeText();

            if (upgradeAchievement == false)
            {
                upgradeAch.gameObject.SetActive(true);
                upgradeAchievement = true;
                
                UpdateAchievementText();
            }
        }

    }

    private void UpdateUpgradeText()                //Updates cost of upgrade text
    {
        upgradeText.text = "Upgrade Cost: " + costToUpgrade;
    }
    #endregion

    #region Helpers
    public void AddHelper()
    {
        if (cookies >= costToBuy)                   //Checks if player can afford helper
        {
            cookies -= costToBuy;                   //Takes cost from cookies
            UpdateCookieText();
            InvokeRepeating("Helpers", 1.0f, 1.0f); //Starting in 1 second a cookie will be added every one second
            if (costToBuy == 100)                   //After first buy increase to 500, from then on add 500 to cost
            {
                costToBuy = costToBuy * 5;
            }
            else
            {
                costToBuy = costToBuy + 500;
            }
            UpdateHelperText();

            noOfHelpers++;                          //Add a helper
            UpdateNoOfHelpersText();

            if (helperAchievement == false)
            {
                helperAch.gameObject.SetActive(true);
                helperAchievement = true;
                
                UpdateAchievementText();
            }
        }
    }

    public void Helpers()                           //Adds cookies per helper
    {
        cookies += cookiesPerHelper;
        UpdateCookieText();
    }

    private void UpdateHelperText()                 //Updates cost of helpers text
    {
        helperText.text = "Helper Cost: " + costToBuy;
    }

    private void UpdateNoOfHelpersText()            //Updates number of helpers text
    {
        noOfHelpersText.text = "Helpers: " + noOfHelpers;
    }
    #endregion

    #region Bakers
    public void AddBaker()
    {
        if (cookies >= costToBake)                       //Checks if player can afford baker
        {
            cookies -= costToBake;                      //Takes cost from cookies
            UpdateCookieText();
            InvokeRepeating("Bakers", 1.0f, 1.0f);      //Starting in 1 second 5 cookies will be added every one second
            if (costToBake == 1000)                     //After first buy increase to 500, from then on add 500 to cost
            {
                costToBake = costToBake * 5;
            }
            else
            {
                costToBake = costToBake + 5000;
            }
            UpdateBakerText();

            noOfBakers++;                          //Add a baker
            UpdateNoOfBakersText();

            if (bakerAchievement == false)
            {
                bakerAch.gameObject.SetActive(true);
                bakerAchievement = true;
                
                UpdateAchievementText();
            }
        }
    }

    public void Bakers()                           //Adds cookies per baker
    {
        cookies += cookiesPerBaker;
        UpdateCookieText();
    }

    private void UpdateBakerText()                 //Updates cost of bakers text
    {
        bakerText.text = "Baker Cost: " + costToBake;
    }

    private void UpdateNoOfBakersText()            //Updates number of bakers text
    {
        noOfBakersText.text = "Bakers: " + noOfBakers;
    }
    #endregion

    #region Cookie Monster
    public void AddCookieMonster()
    {
        if (cookies >= costToMonster)
        {
            cookies -= costToMonster;                      //Takes cost from cookies
            UpdateCookieText();

            cookiesPerClick = cookiesPerClick += 1000;
            cookiesPerHelper = 100;
            cookiesPerBaker = 500;
            monsterButton.gameObject.SetActive(false);
            monsterAchievement = true;

            if (monsterAchievement == true)
            {
                monsterAch.gameObject.SetActive(true);
                
                monsterAchievement = false;
                UpdateAchievementText();
            }
        }
    }
    #endregion

    private void UpdateAchievementText()
    {
        achievementCounter++;
        achievementText.text = "Achievements:  " + achievementCounter + "/10";
    }
}
