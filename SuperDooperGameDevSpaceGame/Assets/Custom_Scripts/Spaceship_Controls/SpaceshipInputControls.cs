using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipInputControls : MonoBehaviour
{
    [SerializeField] SpaceshipMovement shipMovement;
    [SerializeField] GameObject [] spaceshipPrefab;
    Vector2 moveInputs;
    bool primaryFire, secondaryFire;

    private void Start()
    {
        shipMovement = Instantiate(spaceshipPrefab[Random.Range(0, spaceshipPrefab.Length)], transform.position, transform.rotation).GetComponent<SpaceshipMovement>();
        GameStateManager.Instance.AddSpaceshipToList(shipMovement.gameObject.GetComponent<SpaceshipMainComponent>());
    }

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
