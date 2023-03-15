using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

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

        if(player == null)
        {
            Debug.Log("spawn new");
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
