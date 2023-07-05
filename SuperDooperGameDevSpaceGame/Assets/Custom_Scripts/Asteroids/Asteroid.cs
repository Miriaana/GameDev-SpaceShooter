using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f, directionRandomizer = 0f;
    [SerializeField] Vector3 rotationSpeeds;
    [SerializeField] GameObject collisionInst;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        SlurryMovement(directionRandomizer);
        if(transform.position.z < -70f)
        {
            Destroy(gameObject);
        }
    }

    public void RandomizeRotationSpeeds()
    {
        rotationSpeeds = new Vector3(Random.Range(-rotationSpeeds.x, rotationSpeeds.x), Random.Range(-rotationSpeeds.y, rotationSpeeds.y), Random.Range(-rotationSpeeds.z, rotationSpeeds.z));
    }

    public void RandomizeDirection()
    {
        directionRandomizer = Random.Range(-1f, 1f);
    }

    void SlurryMovement(float dir = 0f)
    {
        body.velocity = (-Vector3.forward + Vector3.right * dir).normalized * moveSpeed;
        transform.eulerAngles += rotationSpeeds * Time.deltaTime;
        if(transform.position.y != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * 0.5f * Time.deltaTime, transform.position.z);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(collisionInst, collision.contacts[0].point, transform.rotation);
        if(collision.collider.gameObject.tag == "Spaceship")
        {
            collision.collider.gameObject.GetComponent<DestroyableObject>().DamageHull(50f / moveSpeed, 1f);
            GetComponent<DestroyableObject>().DamageHull(5f, 1f);
        }
    }
}
