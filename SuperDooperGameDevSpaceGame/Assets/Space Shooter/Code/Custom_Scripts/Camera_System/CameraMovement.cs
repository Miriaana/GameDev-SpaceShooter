using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance;
    public enum ViewPoint { BattleView, SelectionView, TransitionView }
    [SerializeField] Transform camViewPoint, camViewDirection;
    [SerializeField] CameraViewpoint[] allViewPoints;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        SetNewPosition(ViewPoint.SelectionView);
    }

    public void SetNewPosition(ViewPoint newViewpoint)
    {
        for (int i = 0; i < allViewPoints.Length; i++)
        {
            if(newViewpoint == allViewPoints[i].GetViewPoint())
            {
                camViewPoint.position = allViewPoints[i].GetViewPosition();
                camViewDirection.position = allViewPoints[i].GetViewDirection();
            }
        }
    }
}
