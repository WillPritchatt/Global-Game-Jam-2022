using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTeam : MonoBehaviour
{
    int count;
    int count2;
    SpriteRenderer render, clawRender;
    private void Awake()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == gameObject.name)
            {
                count++;
            }
        }
        GameObject tempObj = null;
        foreach (Transform child in transform)
        {

            if (child.GetComponent<CrabBase>())
            {
                count2++;
                child.GetComponent<CrabBase>().Team = count;
            }

            if (count2 == 1)
            {
                tempObj = child.gameObject;
            }

            if(count2 == 2)
            {
                if (child.GetComponent<CrabBase>())
                {
                    child.GetComponent<CrabBase>().Ally = tempObj;
                    tempObj.GetComponent<CrabBase>().Ally = child.gameObject;
                }
            }

            if (count > 1)
            {
                render = child.GetComponent<SpriteRenderer>();
                if (count2 == 1)
                    render.color = new Color32(0x70, 0xBD, 0x23, 0xFF);
                else if (count2 == 2)
                    render.color = new Color32(0x9C, 0x54, 0xB8, 0xFF);
                
                ChangeClawColor();
            }
        }
    }

    private void ChangeClawColor()
    {
        foreach (Transform child in render.transform)
        {
            clawRender = child.GetComponent<SpriteRenderer>();
            if (count2 == 1)
                clawRender.color = new Color32(0x4D, 0x82, 0x18, 0xFF);
            else if (count2 == 2)
                clawRender.color = new Color32(0x70, 0x3C, 0x84, 0xFF);
            
        }
    }
}
