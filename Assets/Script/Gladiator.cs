using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gladiator : MonoBehaviour
{
    public int id, avatar, dexterity, strength, balance, speed, strategy;
    public string gname;

    public Gladiator(int id_, string name_, int avatar_, int dexterity_, int strength_, int balance_, int speed_, int strategy_)
    {
      id = id_;
      gname = name_;
      dexterity = dexterity_;
      strength = strength_;
      balance = balance_;
      speed = speed_;
      strategy = strategy_;
    }
}
