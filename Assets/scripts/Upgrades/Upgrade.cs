using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static HellUpgrader;
using System;
public class Upgrade : MonoBehaviour
{
    public int id; //ID of the upgrade
    public TMP_Text UpgradeCapTXT; //How many times you can upgrade this upgrade
    public TMP_Text TitleTXT; //Name of the upgrade
    public TMP_Text DescriptionTXT; //Description of the upgrade
    public int[] ConnectedUpgrades; //Which Upgrades this upgrade is connected to

    public void UpdateUI()
    {
        UpgradeCapTXT.text = $"{hellUpgrader.UpgradeLevels[id]} / {hellUpgrader.UpgradeCap[id]}";
        TitleTXT.text = $"{hellUpgrader.UpgradeNames[id]}";
        DescriptionTXT.text = $"{hellUpgrader.UpgradeDescription[id]}\n{hellUpgrader.curSoul}/1"; //1 her er lige med prisen. Kan ændres til en variabel senere

        GetComponent<Image>().color = hellUpgrader.UpgradeLevels[id] >= hellUpgrader.UpgradeCap[id] ? Color.yellow
        : hellUpgrader.curSoul >= 1 ? Color.green : Color.grey; //1 her er lige med prisen. Kan ændres til en variabel senere

        foreach (var ConnectedUpgrade in ConnectedUpgrades)
        {
            hellUpgrader.UpgradeList[ConnectedUpgrade].gameObject.SetActive(hellUpgrader.UpgradeLevels[id] > 0);
            hellUpgrader.ConnectorList[ConnectedUpgrade].SetActive(hellUpgrader.UpgradeLevels[id] > 0);
        }

    }

    public void Buy()
    {
        if (hellUpgrader.curSoul < 1 || hellUpgrader.UpgradeLevels[id] >= hellUpgrader.UpgradeCap[id]) return;
        hellUpgrader.curSoul -= 1; //1 her er lige med prisen, som tidligere og kan ændres til en variabel senere
        hellUpgrader.UpgradeLevels[id]++;
        hellUpgrader.UpdateAllUpgradeUI();
        Debug.Log("Bought upgrade " + id);
        Debug.Log(Game.Instance.SpawnedPlayer.specialAttackPrefab.cost);

        switch (id)
        {
            case 0:
                {
                    Game.Instance.SpawnedPlayer.canBazooka = true;
                    break;
                }
            case 1:
                {
                    Game.Instance.SpawnedPlayer.specialAttackPrefab.SplashRange += 0.1f;
                    break;
                }
            case 2:
                {
                    Game.Instance.SpawnedPlayer.specialAttackPrefab.SplashDamage += 5f;
                    break;
                }
            case 3:
                {
                    Game.Instance.SpawnedPlayer.reloadSpeed *= 0.9f;
                    break;
                }
            case 4:
                {
                    Game.Instance.SpawnedPlayer.canDash = true;
                    break;
                }
            case 5:
                {
                    Game.Instance.SpawnedPlayer.damage += 2f;
                    break;
                }
            case 6:
                {
                    Game.Instance.SpawnedPlayer.Range += 0.2f;
                    break;
                }
            case 7:
                {
                    Game.Instance.CurrentSoulRange += 0.2f;
                    break;
                }
            case 8:
                {
                    Game.Instance.SpawnedPlayer.speed += 1f;
                    break;
                }

        }

    }

}