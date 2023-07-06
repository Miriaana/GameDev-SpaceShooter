using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipInputControls : MonoBehaviour
{
    public SpaceshipMainComponent shipMain;
    public UIShipSelection selectionUI;
    public int totalPlayerScore = 0;
    Vector2 moveInputs;
    bool primaryFire, secondaryFire;

    private void Start()
    {
        PlayerControlInstanceManager.Instance.AddInputToList(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(shipMain != null)
        {
            shipMain.MoveShip(moveInputs);
            if (primaryFire)
            {
                shipMain.FirePrimaryWeapons();
            }
            if (secondaryFire)
            {
                shipMain.FireSecondaryWeapons();
            }
            totalPlayerScore = shipMain.score;
        }
        if(selectionUI != null)
        {
            selectionUI.SetIndex(Mathf.RoundToInt(moveInputs.x));
            if(primaryFire)
            {
                selectionUI.ConfirmSelection(true);
            }
            else if(secondaryFire)
            {
                selectionUI.ConfirmSelection(false);
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
