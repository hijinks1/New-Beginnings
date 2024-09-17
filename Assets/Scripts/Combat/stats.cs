using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    //These let me fill in the stats of each character
    public int damage;
    public int maxHP;
    public int currentHP;
    public int mindmg;
    public int maxdmg;

    public bool TakeDamage(int dmg)
 {
     int totalDamage = dmg + Random.Range(mindmg, maxdmg);
     Debug.Log(totalDamage);
     currentHP = currentHP - totalDamage;
     
    if (currentHP <= 0)
    {
    //unit has died
    return true;
    }
    else
    {
    //unit is still alive
    return false;
    }
 }
}
