using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public float[,] upgradeItems = new float[5, 5];
    public float curGold;
    public Text GoldTXT;
    public Gold gold;

    public void Start()
    {
        GoldTXT.text = "Gold: " + curGold.ToString();

        //ID's
        upgradeItems[1, 1] = 1;
        upgradeItems[1, 2] = 2;
        upgradeItems[1, 3] = 3;
        upgradeItems[1, 4] = 4;

        //Price
        upgradeItems[2, 0] = 3;
        upgradeItems[2, 1] = 5;
        upgradeItems[2, 2] = 10;
        upgradeItems[2, 3] = 3;
    }

    public void Upgrade()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (curGold >= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID])
        {
            curGold -= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID];
            upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID] *= 1.5f;
            GoldTXT.text = "Gold: " + curGold.ToString();
            ButtonRef.GetComponent<ButtonInfo>().upgradeCost.text = upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID].ToString();
            switch (ButtonRef.GetComponent<ButtonInfo>().upgradeID){
                case 0:
                    {
                        Game.Instance.SpawnedPlayer.reloadSpeed *= 0.9f;
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
                        Game.Instance.CurrentGoldRange ++;   
                        gold.SetPickupDistance(Game.Instance.CurrentGoldRange);                 
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
