using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBase : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public bool Connected;
    public bool CrabAlive;
    public int respawnTime;
    public int Team;

    private void Awake()
    {
        Health = 2;
        MaxHealth = 2;
    }

    private void Update()
    {
        if (!Connected && Health == 2)
        {
            Health = 1;
        }
    }

    IEnumerator TimerCoRoutine()
    {
        yield return new WaitForSeconds(respawnTime);
    }

    public void TakeDamage()
    {
        Health -= 1;
        Debug.Log(Health);
        if(Health <= 0)
        {
            KillCrab();
        }
    }

    public void KillCrab()
    {
        gameObject.GetComponent<CharacterControl>().enabled = false;
        //Dead State
        CrabAlive = false;
        TimerCoRoutine();
        if (Connected /*or if other crab is not dead*/)
        {
            gameObject.GetComponent<CharacterControl>().enabled = true;
            Health = 2;
        }
    }
}
