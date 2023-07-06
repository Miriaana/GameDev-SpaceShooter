using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int Team = 1;
    public bool active = false;
    [SerializeField] Transform target, baseTransform, gunTransform;
    [SerializeField] float turnSpeed = 35f, inactiveToleranceTime = 3f;
    [SerializeField] WeaponSystem weaponSystem;
    Collider sphereCollider;
    float inactiveTimer;
    

    private void Start()
    {
        sphereCollider = GetComponent<Collider>();
        inactiveTimer = inactiveToleranceTime;
    }

    private void Update()
    {
        if(active)
        {
            if (target != null && inactiveTimer >= 0)
            {
                if (TurnBase() && TurnGuns())
                {
                    weaponSystem.Fire();
                }
                inactiveTimer -= Time.deltaTime;
            }
            else
            {
                sphereCollider.enabled = true;
                inactiveTimer = inactiveToleranceTime;
            }
        }
    }

    public bool TurnBase()
    {
        Vector3 baseDirection = (new Vector3(target.position.x, baseTransform.position.y, target.position.z) - baseTransform.position).normalized;
        Debug.DrawLine(baseTransform.position, baseDirection, Color.red);
        float dot = Vector3.Dot(baseTransform.right, baseDirection);
        if (Mathf.Abs(dot) > 0.025f)
        {
            baseTransform.Rotate(Vector3.up, Mathf.Sign(dot) * Time.deltaTime * turnSpeed);
            return false;
        }
        return true;
    }

    public bool TurnGuns()
    {
        Vector3 gunsViewDirection = -gunTransform.up;
        Vector3 directionToTarget = target.transform.position - gunTransform.position;
        float dot = Vector3.Dot(directionToTarget.normalized, gunsViewDirection.normalized);
        if(Mathf.Abs(dot) > 0.0001f)
        {
            gunTransform.Rotate(Vector3.right, Mathf.Sign(dot) * Time.deltaTime * turnSpeed);
            return false;
        }
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SpaceshipMainComponent>() != null && other.GetComponent<SpaceshipMainComponent>().Team != Team)
        {
            target = other.transform;
            sphereCollider.enabled = false;
        }
    }
}
