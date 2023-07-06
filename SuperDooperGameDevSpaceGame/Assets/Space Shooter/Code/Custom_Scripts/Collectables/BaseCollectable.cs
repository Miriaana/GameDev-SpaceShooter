using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectable : MonoBehaviour
{
    public int pointsToScore = 10;
    public float ammoChargeIncrease = 1f;
    [SerializeField] float moveSpeed = 5f;
    Vector3 moveDirection;
    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, -0.75f)).normalized * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = moveDirection;
        if (transform.position.y != 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SpaceshipMainComponent>() != null)
        {
            other.gameObject.GetComponent<SpaceshipMainComponent>().score += pointsToScore;
            other.gameObject.GetComponent<SpaceshipMainComponent>().AddAmmoCharge(ammoChargeIncrease);

            Destroy(gameObject);
        }
    }
}
