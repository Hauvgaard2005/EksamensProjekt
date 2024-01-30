using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class HellUpgrader : MonoBehaviour
{
    public static HellUpgrader hellUpgrader;
    public void Awake() => hellUpgrader = this;

    [Header("Hell Upgrades")]
    public int[] UpgradeLevels; //How many upgrades
    public int[] UpgradeCap; //How many times you can upgrade this upgrade
    public string[] UpgradeCapTXT; //How many times you can upgrade this upgrade
    public string[] UpgradeNames; //Name of the upgrade
    public string[] UpgradeDescription; //Description of the upgrade

    //Upgrader Holder med alle upgrades
    public List<Upgrade> UpgradeList;
    public GameObject UpgradeHolder;
    //Connector Holder med alle connectors
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    [Header("Souls")]
    public float curSoul;
    public Text SoulTXT;


    public void Start()
    {
        SoulTXT.text = "Souls: " + curSoul.ToString();

        UpgradeLevels = new int[9];
        UpgradeCap = new int[] { 1, 3, 5, 5, 1, 10, 10, 5, 3 };

        UpgradeNames = new string[]
        {
            "Soulzooka",
            "AOE Range",
            "Damage",
            "Reload Speed",
            "Dash",
            "Damage",
            "Range",
            "Soul Range",
            "Speed"

        };

        UpgradeDescription = new string[]
        {
           "Unlocks the Soulzooka",
           "Increases the range of your Soulzookas AOE",
            "Increases the damage of your Soulzookas AOE",
            "Reduces the time before you can shoot again",
            "Unlocks the dash ability",
            "Increases the damage of your Fireball",
            "Increases the range your Fireball can travel",
            "Incraeses the range you can collect souls from",
            "Increases your movement speed"

        };

        foreach (var upgrade in UpgradeHolder.GetComponentsInChildren<Upgrade>()) UpgradeList.Add(upgrade);
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);


        for (var i = 0; i < UpgradeList.Count; i++) UpgradeList[i].id = i;

        //Styrer hvilke lines der er connected til hvad
        //Eksempelvis hvis den først upgrade i listen var connected til 4, 5, 6 upgrade "UpgradeList[0].ConnectedUpgrades = new int[] { 3, 4, 5 };"
        UpgradeList[0].ConnectedUpgrades = new[] { 1, 2 };



        UpdateAllUpgradeUI();
    }

    public void UpdateAllUpgradeUI()
    {
        foreach (var upgrade in UpgradeList) upgrade.UpdateUI();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) addSouls(20);
        curSoul = (int)curSoul;
        SoulTXT.text = "Souls: " + curSoul.ToString();



    }

    public void addSouls(int amount)
    {
        curSoul += amount;
        SoulTXT.text = "Souls: " + curSoul.ToString();
        UpdateAllUpgradeUI();
    }
    public void removeSouls(int amount)
    {
        curSoul -= amount;
        SoulTXT.text = "Souls: " + curSoul.ToString();
        UpdateAllUpgradeUI();
    }
}