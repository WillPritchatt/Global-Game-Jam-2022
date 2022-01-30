using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTeam : MonoBehaviour
{
    int count;
    private void Awake()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == gameObject.name)
            {
                count++;
            }
        }

        foreach (Transform child in transform)
        {
            child.GetComponent<CrabBase>().Team = count;
        }
    }
}
