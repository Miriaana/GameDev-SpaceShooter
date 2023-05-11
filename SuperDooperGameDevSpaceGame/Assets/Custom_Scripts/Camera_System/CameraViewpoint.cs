using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewpoint : MonoBehaviour
{
    [SerializeField] CameraMovement.ViewPoint thisViewPoint;
    [SerializeField] Transform viewPosition, lookDirection;

    public CameraMovement.ViewPoint GetViewPoint()
    {
        return thisViewPoint;
    }

    public Vector3 GetViewPosition()
    {
        return viewPosition.position;
    }

    public Vector3 GetViewDirection()
    {
        return lookDirection.position;
    }
}
