using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ludi : MonoBehaviour
{
    public int id;
    public string luname, speciality;
    public List<Gladiator> gladiators = new List<Gladiator>();

    public Ludi(int id_, string name_, string speciality_)
    {
      id = id_;
      luname = name_;
      speciality = speciality_;
    }
}
