using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMainControls : MonoBehaviour
{
    [SerializeField] Turret[] laserTurrets, rocketTurrets;
    [SerializeField] BossHealthBar healthBar;
    [SerializeField] DestroyableObject destroyableObject;
    public float maxHealth = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        destroyableObject = GetComponentInChildren<DestroyableObject>();
        int difficulty = PlayerControlInstanceManager.Instance.allInputs.Count;
        GetComponentInChildren<Hull>().maxHealth = maxHealth * difficulty;
        GetComponentInChildren<Hull>().curHealth = maxHealth * difficulty;
        healthBar.InitializeSlider(destroyableObject.GetMaxHealth());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetRedSliderValues(destroyableObject.GetCurHealth());
        if(destroyableObject.GetCurHealth() < destroyableObject.GetMaxHealth() / 2)
        {
            ToggleRocketTurrets(true);
        }
        if(destroyableObject.GetCurHealth() <= 0)
        {
            GameStateManager.Instance.EndGame();
        }
    }

    public void StartBossFight()
    {
        destroyableObject.Immortal = false;
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
