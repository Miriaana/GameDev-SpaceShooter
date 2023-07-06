using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : BaseDamagingProjectile
{
    public float yAxisErrorRange = 1f;
    float yAxisRotation = 0f;
    float moveSpeedSave => moveSpeed;


    protected override void ProjectileFlight()
    {
        base.ProjectileFlight();
        moveSpeed += Time.deltaTime * 10f;
        moveSpeed = Mathf.Clamp(moveSpeed, 0f, moveSpeedSave * 2f);
        transform.eulerAngles += Vector3.up * yAxisRotation * Time.deltaTime;
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
        if(Random.Range(0f, 1f) < 0.1f)
        {
            yAxisRotation += Random.Range(-yAxisErrorRange / 2f, yAxisErrorRange / 2f);
        }
        if (transform.position.y != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Mathf.Sign(transform.position.y) * Time.deltaTime, transform.position.z);
        }
    }
}
