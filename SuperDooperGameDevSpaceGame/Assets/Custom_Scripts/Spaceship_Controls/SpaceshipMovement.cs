using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpaceshipMainComponent))]
public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] float baseMovementSpeed = 10f, curMovementSpeed = 10f, maxTurnAngle = 20f;
    public SpaceshipMainComponent spaceshipMain;
    public float maxCarryingWeight = 100f;
    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void MoveShip(Vector3 newDir)
    {
        if (transform.position.x < -120f && newDir.x < 0f || transform.position.x > 120f && newDir.x > 0f)
        {
            newDir.x = 0f;
        }
        if(transform.position.y > 50f && newDir.y > 0f || transform.position.y < -50f && newDir.y < 0f)
        {
            newDir.y = 0f;
        }
        //
        body.velocity = newDir;
        body.angularVelocity = Vector3.zero;
        if(transform.position.y != 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
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
}
