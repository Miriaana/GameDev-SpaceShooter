using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipInputControls : MonoBehaviour
{
    [SerializeField] SpaceshipMovement shipMovement;
    Vector2 moveInputs;
    bool primaryFire, secondaryFire;

    // Update is called once per frame
    void Update()
    {
        if(shipMovement != null)
        {
            shipMovement.MoveShip(shipMovement.SteerHor(moveInputs.x) + shipMovement.SteerVert(moveInputs.y));
            if (primaryFire)
            {
                shipMovement.spaceshipMain.FirePrimaryWeapons();
            }
            if (secondaryFire)
            {
                shipMovement.spaceshipMain.FireSecondaryWeapons();
            }
        }
    }

    public void GetMovementControls(InputAction.CallbackContext context)
    {
        moveInputs = context.ReadValue<Vector2>();
    }

    public void GetPrimaryFire(InputAction.CallbackContext context)
    {
        primaryFire = context.ReadValueAsButton();
    }

    public void GetSecondaryFire(InputAction.CallbackContext context)
    {
        secondaryFire = context.ReadValueAsButton();
    }
}
