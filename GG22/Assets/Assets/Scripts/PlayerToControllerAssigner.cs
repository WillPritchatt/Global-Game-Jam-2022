using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToControllerAssigner : MonoBehaviour
{
    private List<int> assignedController = new List<int>();
    private CrabBase[] crabs;
    private float nextBotTime;

    private void Awake()
    {
        crabs = FindObjectsOfType<CrabBase>();
    }

    private void Update()
    {
        for (int i = 1; i <= 2; i++)
        {
            if (assignedController.Contains(i))
            {
                AddPlayerController(i);
            }
        }
    }

    private void AddPlayerController(int i)
    {

    }
}
