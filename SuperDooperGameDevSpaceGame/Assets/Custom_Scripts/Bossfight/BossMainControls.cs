using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMainControls : MonoBehaviour
{
    [SerializeField] Turret[] laserTurrets, rocketTurrets;
    [SerializeField] BossHealthBar healthBar;
    [SerializeField] DestroyableObject destroyableObject;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        destroyableObject = GetComponent<DestroyableObject>();
        healthBar.InitializeSlider(destroyableObject.GetMaxHealth());
        StartBossFight();//Remove This!!!
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetRedSliderValues(destroyableObject.GetCurHealth());
    }

    public void StartBossFight()
    {
        active = true;
        ToggleLaserTurrets(true);
    }

    void ToggleLaserTurrets(bool activeState)
    {
        for (int i = 0; i < laserTurrets.Length; i++)
        {
            laserTurrets[i].active = true;
        }
    }

    void ToggleRocketTurrets(bool activeState)
    {
        for (int i = 0; i < rocketTurrets.Length; i++)
        {
            rocketTurrets[i].active = true;
        }
    }
}
