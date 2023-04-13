using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCount : MonoBehaviour
{
    public TextMeshProUGUI money;

    void Update()
    {
        money.text = "Bourse: "+PlayerStat.money+" Deniers";
    }
}
