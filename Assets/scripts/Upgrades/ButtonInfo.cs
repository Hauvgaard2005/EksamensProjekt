using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ButtonInfo : MonoBehaviour
{
    public int upgradeID;
    public Text upgradeCost;
    public GameObject upgradeManager;


    public void Update()
    {
        upgradeCost.text = "Price: " + upgradeManager.GetComponent<UpgradeManager>().upgradeItems[2, upgradeID].ToString();
    }

}