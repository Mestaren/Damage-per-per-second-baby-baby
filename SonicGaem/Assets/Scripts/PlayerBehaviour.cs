using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerTakesDmg(20);
            Debug.Log(GameManager.gameManager._PlayerHealth.Health);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealing(10);
            Debug.Log(GameManager.gameManager._PlayerHealth.Health);
        }

    }

    private void PlayerTakesDmg(int dmg)
    {
        GameManager.gameManager._PlayerHealth.DmgUnits(dmg);
    }

    private void PlayerHealing(int healing)
    {
        GameManager.gameManager._PlayerHealth.HealUnits(healing);
    }


}
