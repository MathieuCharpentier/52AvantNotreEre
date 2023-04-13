using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LudiList : MonoBehaviour
{
    public GameObject ludiPrefab;

    void Update()
    {
        if(PlayerStat.ludis.Count != gameObject.GetComponentsInChildren<Button>().Length)
        {
            foreach(Button but in gameObject.GetComponentsInChildren<Button>())
            {
                Destroy(but.gameObject);
            }

            foreach(Ludi ludi in PlayerStat.ludis)
            {
                GameObject temp = Instantiate(ludiPrefab, transform);
                string[] param = {ludi.luname, ludi.speciality, "0"+ludi.gladiators.Count};
                temp.SendMessage("ChangeText", param);
            }
        }
    }
}
