using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    //These let me fill in the stats of each character
    public int damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg)
 {
    currentHP -= dmg;

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
