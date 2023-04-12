using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Signin : MonoBehaviour
{
    public TMP_InputField lname;
    public TMP_InputField fname;
    public TMP_InputField mail;
    public MySQLData db;

    public void onSubmit()
    {
        if(!db.verifUser(mail.text))
        {
            PlayerStat.lname = lname.text;
            PlayerStat.fname = fname.text;
            PlayerStat.mail= mail.text;
            Debug.Log(db.createUser(lname.text, fname.text, mail.text));
        }
        else
        {
            lname.text = "";
            fname.text = "";
            mail.text = "";
            lname.placeholder.GetComponent<Text>().text = "Cet utilisateur éxiste déjà, réessayez";
        }
    }
}
