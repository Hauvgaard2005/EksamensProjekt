using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class HellUpgrader : MonoBehaviour
{
    public float curSoul;
    public Text SoulTXT;


    public void Start()
    {
        SoulTXT.text = "Souls: " + curSoul.ToString();
    }

    public void Update()
    {
        curSoul = (int)curSoul;
        SoulTXT.text = "Souls: " + curSoul.ToString();

    }

    public void addSouls(int amount)
    {
        curSoul += amount;
        SoulTXT.text = "Souls: " + curSoul.ToString();
    }

}