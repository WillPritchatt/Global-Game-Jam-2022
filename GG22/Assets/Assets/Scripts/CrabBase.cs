using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBase : MonoBehaviour
{
    public int Health;
    private int MaxHealth;
    public bool Connected;
    public bool CrabAlive;
    private float timer, timeUntilRespawn;
    private float respawnTime;
    public int Team;

    public GameObject Ally;

    public Sprite bodyAlive;
    public Sprite bodyDead;

    private void Awake()
    {
        Health = 2;
        MaxHealth = 2;
        Connected = false;
        respawnTime = 3;
        CrabAlive = true;
    }

    private void Update()
    {
        if (!Connected && Health == 2)
        {
            Health = 1;
        }
        
        timer += Time.deltaTime;
        if (Connected && !CrabAlive && Ally.GetComponent<CrabBase>().CrabAlive)
        {
            if (timer > timeUntilRespawn)
            {
                gameObject.GetComponent<CharacterControl>().enabled = true;
                gameObject.GetComponent<CharacterControl>().Claw.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().sprite = bodyAlive;
                CrabAlive = true;
                Health = 2;
                timer = 0;
            }
        }
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
        gameObject.GetComponent<CharacterControl>().Claw.SetActive(false);
        gameObject.GetComponent<CharacterControl>().enabled = false;
        //Dead State
        gameObject.GetComponent<SpriteRenderer>().sprite = bodyDead;
        CrabAlive = false;
        if (Connected)
        {
            timeUntilRespawn = timer + respawnTime;
        }
    }
}
