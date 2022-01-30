using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private Rigidbody2D RB2D;
    private Vector3 playerVelocity;
    public bool groundedPlayer = true;
    public bool canHit = true;
    private BoxCollider2D Claw;
    private int Strike;

    private Vector2 MovementInput = Vector2.zero;
    private float Jumped;
    private float dir;
    private bool canChange = true;

    public GameObject topClaw, midClaw, botClaw, dwnClaw;

    public enum claws
    {
        TopClaw,
        MidClaw,
        BotClaw,
        DwnClaw,
    }
    public claws activeClaw;

    private void Awake()
    {
        RB2D = gameObject.GetComponent<Rigidbody2D>();
        topClaw = transform.Find("TOP CLAW").gameObject;
        midClaw = transform.Find("MID CLAW").gameObject;
        botClaw = transform.Find("BOT CLAW").gameObject;
        dwnClaw = transform.Find("DWN CLAW").gameObject;
        activeClaw = claws.MidClaw;

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
                Claw = child.GetComponent<BoxCollider2D>();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Jumped = context.ReadValue<float>();
    }

    public void OnStrike(InputAction.CallbackContext context)
    {
        Strike = (int)context.ReadValue<float>();
    }

    public void OnClawChange(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>().y;
    }

    void ChangeClaw()
    {
        canChange = !canChange;
        switch (activeClaw)
        {
            case claws.TopClaw:
                {
                    topClaw.SetActive(false);
                    activeClaw = claws.MidClaw;
                    midClaw.SetActive(true);
                    break;
                }

            case claws.MidClaw:
                {
                    midClaw.SetActive(false);
                    if (dir > 0)
                    {
                        activeClaw = claws.TopClaw;
                        topClaw.SetActive(true);
                    }
                    else if (dir < 0)
                    {
                        activeClaw = claws.BotClaw;
                        botClaw.SetActive(true);
                    }
                    break;
                }

            case claws.BotClaw:
                {
                    botClaw.SetActive(false);
                    if (dir > 0)
                    {
                        activeClaw = claws.MidClaw;
                        midClaw.SetActive(true);
                    }
                    else if (dir < 0)
                    {
                        activeClaw = claws.DwnClaw;
                        dwnClaw.SetActive(true);
                    }
                    break;
                }

            case claws.DwnClaw:
                {
                    dwnClaw.SetActive(false);
                    activeClaw = claws.BotClaw;
                    botClaw.SetActive(true);
                    break;
                }
        }
    }

    void Update()
    {
        Vector2 j;
        if (groundedPlayer && Jumped != 0)
        {
            groundedPlayer = false;
            j = new Vector2(0, 1) * jumpHeight; 
            RB2D.AddForce(j, ForceMode2D.Impulse);
        }
        Jumped = 0;

        if (canChange && dir != 0)
        {
            if ((dir == 1 && activeClaw != claws.TopClaw) || (dir == -1 && activeClaw != claws.DwnClaw))
            {
                ChangeClaw();
                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeInHierarchy)
                        Claw = child.GetComponent<BoxCollider2D>();
                }
            }
        }

        if (!canChange && dir == 0)
            canChange = !canChange;

        if(Strike == 0 && !canHit)
        {
            canHit = !canHit;
        }
    }

    IEnumerator TimerCoRoutine()
    {
        yield return new WaitForSeconds(1);
    }

    private void FixedUpdate()
    {
        Vector3 m = new Vector2(MovementInput.x, 0) * playerSpeed * Time.deltaTime;
        Vector2 vel = RB2D.velocity;
        m.y = vel.y;
        RB2D.AddForce(new Vector2(0, -15.0f), ForceMode2D.Force);
        RB2D.velocity = m;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            groundedPlayer = true;
        }

        if (collision.gameObject.tag == "Crab1" || collision.gameObject.tag == "Crab2")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Strike == 1 && canHit)
        {
            canHit = !canHit;
            if (collision.gameObject.GetComponent<CrabBase>())
                if(gameObject.GetComponent<CrabBase>().Team != collision.gameObject.GetComponent<CrabBase>().Team)
                    collision.gameObject.GetComponent<CrabBase>().TakeDamage();
        }
    }
}
