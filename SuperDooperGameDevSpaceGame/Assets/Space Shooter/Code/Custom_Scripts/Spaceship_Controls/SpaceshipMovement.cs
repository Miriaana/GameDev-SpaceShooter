using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpaceshipMainComponent))]
public class SpaceshipMovement : MonoBehaviour
{
    public bool aiControlled = false;
    [SerializeField] float curMovementSpeed = 10f, maxTurnAngle = 20f;
    [SerializeField] GameObject collisionImpact;
    public SpaceshipMainComponent spaceshipMain;
    public float maxCarryingWeight = 100f, bumpTimer = 0f, explosionForceMod = 1000f;
    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void MoveShip(Vector3 newDir)
    {
        if (!aiControlled)
        {
            if (transform.position.x < -120f && newDir.x < 0f || transform.position.x > 120f && newDir.x > 0f)
            {
                newDir.x = 0f;
            }
            if (transform.position.z > 30f && newDir.z > 0f || transform.position.z < -65f && newDir.z < 0f)
            {
                newDir.z = 0f;
            }
        }
        else
        {
            newDir = -Vector3.forward;
        }
        //
        if(body != null && bumpTimer == 0)
        {
            body.velocity = newDir;
            body.angularVelocity = Vector3.zero;
        }
        if(transform.position.y != 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
    }

    private void Update()
    {
        bumpTimer -= Time.deltaTime;
        bumpTimer = Mathf.Clamp(bumpTimer, 0f, 1f);
    }

    public Vector3 SteerHor(float dir)
    {
        transform.eulerAngles = new Vector3(0f, 0f, -maxTurnAngle * dir);
        return Vector3.right * dir * curMovementSpeed;
    }

    public Vector3 SteerVert(float dir)
    {
        return Vector3.forward * dir * curMovementSpeed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<SpaceshipMovement>() != null)
        {
            bumpTimer = 0.25f;
            collision.rigidbody.AddExplosionForce(explosionForceMod, transform.position, 25f);
            collision.collider.gameObject.GetComponent<DestroyableObject>().DamageHull(body.velocity.magnitude, 1f);
        }
        if(collisionImpact != null)
        {
            Instantiate(collisionImpact, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
