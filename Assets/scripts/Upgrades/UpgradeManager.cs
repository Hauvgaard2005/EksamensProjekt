using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public float[,] upgradeItems = new float[6, 6];
    public float curGold;
    public Text GoldTXT;


    public void Start()
    {
        GoldTXT.text = "Gold: " + curGold.ToString();

        //ID's
        upgradeItems[1, 1] = 1;
        upgradeItems[1, 2] = 2;
        upgradeItems[1, 3] = 3;
        upgradeItems[1, 4] = 4;
        upgradeItems[1, 5] = 5;

        //Price
        upgradeItems[2, 0] = 3;
        upgradeItems[2, 1] = 5;
        upgradeItems[2, 2] = 10;
        upgradeItems[2, 3] = 3;
        upgradeItems[2, 4] = 5;
    }

    public void Upgrade()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (curGold >= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID])
        {
            curGold -= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID];

            //Pris for Upgrades
            upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID] *= 1.1f;


            GoldTXT.text = "Gold: " + curGold.ToString();
            ButtonRef.GetComponent<ButtonInfo>().upgradeCost.text = upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID].ToString();

            //Upgrades (Husk at ændre længden af arrays hvis der tilføjes flere upgrades)
            switch (ButtonRef.GetComponent<ButtonInfo>().upgradeID)
            {
                case 0:
                    {
                        Game.Instance.SpawnedPlayer.reloadSpeed *= 0.8f;
                        break;
                    }
                case 1:
                    {
                        Game.Instance.SpawnedPlayer.damage *= 1.5f;
                        break;
                    }
                case 2:
                    {
                        Game.Instance.SpawnedPlayer.Range += 2f;
                        break;
                    }
                case 3:
                    {
                        Game.Instance.CurrentGoldRange++;

                        foreach (Gold gold in FindObjectsOfType<Gold>())
                        {
                            gold.SetPickupDistance(Game.Instance.CurrentGoldRange);
                        }

                        break;
                    }
                case 4:
                    {
                        Game.Instance.SpawnedPlayer.speed *= 1.2f;
                        break;
                    }

            }
        }


    }

    public void addGold(int amount)
    {
        curGold += amount;
        GoldTXT.text = "Gold: " + curGold.ToString();
    }


}
