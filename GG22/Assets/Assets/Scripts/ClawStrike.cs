using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawStrike : MonoBehaviour
{
    private List<GameObject> CurrentColision = new List<GameObject>();
    public float Strike;
    public bool canHit = true;

    private void Update()
    {
        if (Strike == 0 && !canHit)
        {
            canHit = !canHit;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CrabBase>())
        {
            CurrentColision.Add(collision.gameObject);
            foreach (GameObject gObject in CurrentColision)
            {
                print(gObject.name);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Strike == 1 && canHit)
        {
            canHit = !canHit;
            if (collision.gameObject.GetComponent<CrabBase>())
            {
                foreach (GameObject gObject in CurrentColision)
                {
                    Debug.Log(gObject.name);
                    if (gameObject.GetComponentInParent<CrabBase>().Team != gObject.gameObject.GetComponent<CrabBase>().Team)
                    {
                        gObject.gameObject.GetComponent<CrabBase>().TakeDamage();
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CrabBase>())
        {
            CurrentColision.Remove(collision.gameObject);
            foreach (GameObject gObject in CurrentColision)
            {
                print(gObject.name);
            }
        }
    }
}
