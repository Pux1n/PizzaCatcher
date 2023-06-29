using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentAdder : MonoBehaviour
{
    public Transform content;
    public GameObject couponPanelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ClearChildObjects();
        foreach (string item in ScoreBanking.myCoupons)
        {
            GameObject couponPanel = Instantiate(couponPanelPrefab);
            couponPanel.transform.SetParent(content, false);
            TMP_InputField textCoupon = couponPanel.GetComponentInChildren<TMP_InputField>();
            TMP_Text textDiscount = couponPanel.GetComponentInChildren<TMP_Text>();
            string[] splitStrings = item.Split(' ');
            textCoupon.text = splitStrings[1];
            textDiscount.text = "Скидка " + splitStrings[0] + "%:";
        }
    }

    private void ClearChildObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
