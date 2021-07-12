using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Class to spawn the correct Player Sprite/Object Prefab

public class PlayerSpriteSpawner : MonoBehaviour
{
    [SerializeField] GameObject Elf_M_Prefab;
    [SerializeField] GameObject Elf_F_Prefab;
    [SerializeField] GameObject Lizard_Prefab;

    GameObject currentPlayer;

    public void SpawnPlayer()
    {
        if (FindObjectOfType<PlayerState>().isCrewMate)
            StartGameCrewmate();
        else
            StartGameImposter();
    }

    public void StartGameCrewmate()
    {
        if (Random.Range(0, 100) > 50)
            currentPlayer = Instantiate(Elf_M_Prefab, this.transform);
        else
            currentPlayer = Instantiate(Elf_F_Prefab, this.transform);
    }

    void StartGameImposter()
    {
        currentPlayer = Instantiate(Lizard_Prefab, this.transform);
    }
}
