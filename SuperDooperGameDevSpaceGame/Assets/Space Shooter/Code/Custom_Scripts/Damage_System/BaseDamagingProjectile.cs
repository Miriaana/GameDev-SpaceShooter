using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseDamagingProjectile : MonoBehaviour
{
    public SpaceshipMainComponent associatedShip;
    [SerializeField] protected float moveSpeed = 30f; 
    [SerializeField] protected GameObject hitPrefab;
    [SerializeField] protected AudioClip spawnSound, deathSound;
    [SerializeField] bool destroyedOnImpact = true;
    protected float damage = 10f, armorPenetrationRatio = 0f;
    protected int teamNumber;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        SoundEffectMaster.Instance.SpawnSoundEffect(transform.position, spawnSound, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileFlight();   
    }

    protected virtual void ProjectileFlight()
    {
        body.velocity = transform.forward * moveSpeed;
    }

    public virtual void SetStats(int newTeamNumber, float newDamage, float newArmorPenetration, Transform originTransform, SpaceshipMainComponent shipMain = null)
    {
        teamNumber = newTeamNumber;
        damage = newDamage;
        armorPenetrationRatio = newArmorPenetration;
        associatedShip = shipMain;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DestroyableObject>() != null && other.GetComponent<DestroyableObject>().teamNumber != teamNumber)
        {
            other.GetComponent<DestroyableObject>().DamageHull(damage, armorPenetrationRatio, associatedShip);
            if(hitPrefab != null)
            {
                Instantiate(hitPrefab, transform.position, transform.rotation);
                SoundEffectMaster.Instance.SpawnSoundEffect(transform.position, deathSound, 0.25f);
                if(destroyedOnImpact)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
