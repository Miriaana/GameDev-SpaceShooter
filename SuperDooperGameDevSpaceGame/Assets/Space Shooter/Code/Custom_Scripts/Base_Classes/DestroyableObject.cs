using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Hull))]
public class DestroyableObject : MonoBehaviour
{
    public int teamNumber = 0;
    public bool DestroyOnDeath = true;
    public bool Immortal = false;
    [SerializeField] float objectSize = 1f;
    [SerializeField] GameObject[] instantiatedDebris;
    bool hasBeenDestroyed = false;
    protected Hull compHull;

    private void Start()
    {
        compHull = GetComponent<Hull>();
    }

    public virtual void DamageHull(float takenDamage, float armorPen = 0f, SpaceshipMainComponent associatedShip = null)
    {
        if(!Immortal)
        {
            float healthBefore = compHull.curHealth;
            float healthAfter = compHull.TakeDamage(takenDamage, armorPen);
            if (associatedShip != null)
            {
                associatedShip.score += Mathf.RoundToInt(Mathf.Clamp(healthBefore - healthAfter, 0f, float.MaxValue));
            }
            if (healthAfter <= 0 && !hasBeenDestroyed)
            {
                hasBeenDestroyed = true;
                DestroyThis();
            }
        }
    }

    public void DestroyThis()
    {
        foreach (GameObject obj in instantiatedDebris)
        {
            var inst = Instantiate(obj, transform.position + Random.Range(-objectSize, objectSize) * Vector3.right + Random.Range(-objectSize, objectSize) * Vector3.forward, transform.rotation);
            if(inst.GetComponent<Asteroid>() != null)
            {
                inst.GetComponent<Asteroid>().RandomizeRotationSpeeds();
                inst.GetComponent<Asteroid>().RandomizeDirection();
            }
        }
        if(DestroyOnDeath)
        {
            Destroy(gameObject);
        }
        else
        {
            GameStateManager.Instance.CheckAllPlayerHealth();
        }
    }

    public float GetMaxHealth()
    {
        CheckForHull();
        return compHull.maxHealth;
    }

    public float GetCurHealth()
    {
        CheckForHull();
        return compHull.curHealth;
    }

    void CheckForHull()
    {
        if(compHull == null)
        {
            compHull = GetComponent<Hull>();
        }
    }
}
