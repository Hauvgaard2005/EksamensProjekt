using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*public class UpgradeManager : MonoBehaviour
{
    public float[,] upgradeItems = new float[6, 6];
    public float curSoul;
    public Text SoulTXT;


    public void Start()
    {
        SoulTXT.text = "Souls: " + curSoul.ToString();

        //ID's
        upgradeItems[1, 1] = 1;
        upgradeItems[1, 2] = 2;
        upgradeItems[1, 3] = 3;
        upgradeItems[1, 4] = 4;
        upgradeItems[1, 5] = 5;

        //Price
        upgradeItems[2, 0] = 3;
        upgradeItems[2, 1] = 5;
        upgradeItems[2, 2] = 4;
        upgradeItems[2, 3] = 3;
        upgradeItems[2, 4] = 5;
    }

    public void Upgrade()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (curSoul >= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID])
        {
            curSoul -= upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID];

            //Pris for Upgrades
            upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID] = (int)upgradeItems[2, ButtonRef.GetComponent<ButtonInfo>().upgradeID] * 1.5f;


            curSoul = (int)curSoul;
            SoulTXT.text = "Souls: " + curSoul.ToString();

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
                        Game.Instance.SpawnedPlayer.damage += 2.5f;
                        break;
                    }
                case 2:
                    {
                        Game.Instance.SpawnedPlayer.Range += 2f;
                        break;
                    }
                case 3:
                    {
                        Game.Instance.CurrentSoulRange++;

                        foreach (Soul soul in FindObjectsOfType<Soul>())
                        {
                            soul.SetPickupDistance(Game.Instance.CurrentSoulRange);
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

    public void addSouls(int amount)
    {
        curSoul += amount;
        SoulTXT.text = "Souls: " + curSoul.ToString();
    }


}*/
