using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public Transform[] SpawnLocations;
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Joined");
        playerInput.gameObject.GetComponent<CharacterControl>().playerID = playerInput.playerIndex + 1;

        playerInput.gameObject.GetComponent<CharacterControl>().startPos = SpawnLocations[playerInput.playerIndex].position;

    }


}
