using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField mail;
    public MySQLData db;

    public void onSubmit()
    {
        if(db.verifUser(mail.text))
        {
            db.getUser(mail.text);
            db.getUserLudis();
            foreach(Ludi ludi in PlayerStat.ludis)
            {
                db.getLudiGladiators(ludi);
            }
        }
        else
        {
            mail.text = "";
            mail.placeholder.GetComponent<Text>().text = "Cet utilisateur n'éxiste pas, réessayez";
        }
    }
}
