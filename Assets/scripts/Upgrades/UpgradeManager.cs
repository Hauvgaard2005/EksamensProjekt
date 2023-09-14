using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public float[,] upgradeItems = new float[4, 4];
    public float gold;
    public Text GoldTXT;

    public void Start()
    {
        GoldTXT.text = "Gold: " + gold.ToString();

        //ID's
        upgradeItems[1, 1] = 1;
        upgradeItems[1, 2] = 2;
        upgradeItems[1, 3] = 3;

        //Price
        upgradeItems[2, 0] = 3;
        upgradeItems[2, 1] = 5;
        upgradeItems[2, 2] = 10;
    }

    public void Upgrade()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (gold >= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID])
        {
            gold -= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID];
            upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID] *= 1.5f;
            GoldTXT.text = "Gold: " + gold.ToString();
            ButtonRef.GetComponent<ButtonInfo>().upgradeCost.text =upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID].ToString();
        }
    }

    public void addGold(int amount){
        gold += amount;
        GoldTXT.text = "Gold: " + gold.ToString();
    }


}
