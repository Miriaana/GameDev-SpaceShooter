using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : BaseDamagingProjectile
{
    float yAxisRotation = 0f;
    float moveSpeedSave => moveSpeed;



    protected override void ProjectileFlight()
    {
        base.ProjectileFlight();
        moveSpeed += Time.deltaTime * 10f;
        moveSpeed = Mathf.Clamp(moveSpeed, 0f, moveSpeedSave * 2f);
        transform.eulerAngles += Vector3.up * yAxisRotation * Time.deltaTime;
        if(Random.Range(0f, 1f) < 0.1f)
        {
            yAxisRotation += Random.Range(-1f, 1f);
        }
    }
}
