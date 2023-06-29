using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBanking : MonoBehaviour
{

    public TMP_Text scoreBankText;
    public static int scoreBank = 1000;
    public GameObject[] couponPanel;
    string[] coupons = { "5 EJS123SDF21", "15 KXD556KFE25", "25 ULS731LDK21" };
    public static List<string> myCoupons = new List<string> { };

    void Update()
    {
        scoreBankText.text = scoreBank.ToString();
    }

    public void BuyCoupon(int bonuses)
    {
        if (scoreBank >= bonuses)
        {
            if (bonuses == 40)
            {
                couponPanel[0].SetActive(true);
                myCoupons.Add(coupons[0]);
                
            }
            else if(bonuses == 80)
            {
                couponPanel[1].SetActive(true);
                myCoupons.Add(coupons[1]);
            } else if (bonuses == 120)
            {
                couponPanel[2].SetActive(true);
                myCoupons.Add(coupons[2]);
            }
            scoreBank -= bonuses;
        }
    }
}
