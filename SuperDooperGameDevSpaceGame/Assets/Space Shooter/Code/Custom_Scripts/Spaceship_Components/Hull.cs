using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    public float maxHealth = 100f, curHealth = 100f, armor = 10f;

    public float TakeDamage(float dmgAmount, float armorPen = 0f)
    {
        float damageTaken = dmgAmount * 100f / (100f + Mathf.Clamp(armor - (armor * armorPen), 0f, armor) );
        curHealth -= damageTaken;
        if(GetComponent<SpaceshipMainComponent>() != null)
        {
            GetComponent<SpaceshipMainComponent>().thisUiPlayer.SetHealthSlider(curHealth);
        }
        return curHealth;
    }
}
