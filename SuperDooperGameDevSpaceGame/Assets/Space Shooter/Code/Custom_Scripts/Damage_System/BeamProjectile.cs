using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamProjectile : BaseDamagingProjectile
{
    [SerializeField] float maxDistance = 200f;
    [SerializeField] LayerMask allThingsThisCanHitMask;
    [SerializeField] GameObject beamEffect;
    Transform origin;
    DestroyOverTime lifeObject;
    Vector3 hitLocation;

    public override void SetStats(int newTeamNumber, float newDamage, float newArmorPenetration, Transform originTransform, SpaceshipMainComponent shipMain = null)
    {
        base.SetStats(newTeamNumber, newDamage, newArmorPenetration, originTransform);
        origin = originTransform;
        GetComponent<Collider>().enabled = false;
        lifeObject = GetComponent<DestroyOverTime>();
    }

    protected override void ProjectileFlight()
    {
        transform.position = origin.position;
        if(lifeObject.lifeTime < 1f)
        {
            transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime, transform.localScale.y, transform.localScale.z);
        }
        RaycastHit hit;
        float hitDistance = 0f;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, allThingsThisCanHitMask))
        {
            hitLocation = hit.point;
            hitDistance = hit.distance;
            if (hit.collider.GetComponent<DestroyableObject>() != null)
            {
                hit.collider.GetComponent<DestroyableObject>().DamageHull(damage * Time.deltaTime, armorPenetrationRatio);
                if (hitPrefab != null)
                {
                    Instantiate(hitPrefab, hitLocation, transform.rotation);
                }
            }
        }
        else
        {
            hitDistance = maxDistance;
            hitLocation = transform.position + transform.forward * maxDistance;
        }
        Vector3 beamDirection = (hitLocation - origin.position).normalized;
        //Debug.Log(hitDistance);
        beamEffect.transform.position = origin.position + beamDirection * hitDistance / 2f;
        beamEffect.transform.localScale = new Vector3(beamEffect.transform.localScale.x, beamEffect.transform.localScale.y, hitDistance / 10f);
    }
}
