using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ludi : MonoBehaviour
{
  public int id;
  public string luname, speciality;
  public List<Gladiator> gladiators = new List<Gladiator>();

  public TMP_InputField ludiname;
  public TextMeshProUGUI spe;
  public MySQLData db;

  public Ludi(int id_, string name_, string speciality_)
  {
    id = id_;
    luname = name_;
    speciality = speciality_;
  }

  public void createUserLudi()
  {
    db.createLudi(ludiname.text, spe.text);
    PlayerStat.ludis.Add(new Ludi(Random.Range(0, 99999), ludiname.text, spe.text));
    db.getUserLudis();
  }

  public void createTemplateLudi()
  {
    PlayerStat.ludis.Add(new Ludi(Random.Range(0, 99999), "Debug", "Course de Char"));
  }
}
