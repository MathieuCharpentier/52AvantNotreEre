using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LudiButton : MonoBehaviour
{
    public TextMeshProUGUI ludiName;
    public TextMeshProUGUI spe;
    public TextMeshProUGUI nbrGladia;
    public void ChangeText(string[] card)
    {
        ludiName.text = "Nom: " + card[0];
        spe.text = "Spécialité: " + card[1];
        nbrGladia.text = "Gladiateurs: " + card[2];
    }
}
