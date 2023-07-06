using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlInstanceManager : MonoBehaviour
{
    public static PlayerControlInstanceManager Instance;
    List<SpaceshipInputControls> allInputs = new List<SpaceshipInputControls>();
    [SerializeField] UIShipSelection[] selectionUI;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        foreach(UIShipSelection obj in selectionUI)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public bool CheckGlobalConfirmationState()
    {
        for (int i = 0; i < allInputs.Count; i++)
        {
            if(!selectionUI[i].confirmed)
            {
                return false;
            }
        }
        return true;
    }

    public void AddInputToList(SpaceshipInputControls newInput)
    {
        selectionUI[allInputs.Count].gameObject.SetActive(true);
        newInput.selectionUI = selectionUI[allInputs.Count];
        allInputs.Add(newInput);
    }

    public void InstantiateSpaceships()
    {
        for (int i = 0; i < allInputs.Count; i++)
        {
            GameObject obj = selectionUI[i].GetSelectedSpaceship();
            GameObject instantiatedObj = Instantiate(obj, transform.position + Vector3.right * 15f * (i - allInputs.Count / 2), transform.rotation);
            allInputs[i].selectionUI = null;
            allInputs[i].shipMain = instantiatedObj.GetComponent<SpaceshipMainComponent>();
        }
    }
}
