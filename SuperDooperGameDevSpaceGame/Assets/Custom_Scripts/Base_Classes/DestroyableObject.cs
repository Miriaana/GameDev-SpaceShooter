using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Hull))]
public class DestroyableObject : MonoBehaviour
{
    public int teamNumber = 0;
    [SerializeField] float objectSize = 1f;
    [SerializeField] GameObject[] instantiatedDebris;
    bool hasBeenDestroyed = false;

    protected Hull compHull;
    private void Start()
    {
        compHull = GetComponent<Hull>();
    }

    public virtual void DamageHull(float takenDamage, float armorPen = 0f)
    {
        float remainingHealth = compHull.TakeDamage(takenDamage, armorPen);
        if (remainingHealth <= 0 && !hasBeenDestroyed)
        {
            hasBeenDestroyed = true;
            DestroyThis();
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
        Destroy(gameObject);
    }
}
