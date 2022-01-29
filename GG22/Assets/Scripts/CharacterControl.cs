using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{

    public PlayerControls controls;
    Vector2 move;

    public float speed = 1f;
    public float jumpHeight = 3f;
    float jump;
    float clawChange;
    bool canChange = true;
    bool canJump = true;
    public Rigidbody2D rb2d;
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
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        topClaw = transform.Find("TOP CLAW").gameObject;
        midClaw = transform.Find("MID CLAW").gameObject;
        botClaw = transform.Find("BOT CLAW").gameObject;
        dwnClaw = transform.Find("DWN CLAW").gameObject;
        activeClaw = claws.MidClaw;

        controls = new PlayerControls();
        controls.Gameplay.Enable();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.ClawSwap.performed += ctx => clawChange = ctx.ReadValue<Vector2>().y;
        controls.Gameplay.Jump.performed += ctx => jump = ctx.ReadValue<float>();
        controls.Gameplay.Strike.performed += ctx => Strike();
    }

    void Update()
    {
        Vector2 j;
        if (jump != 0 && canJump)
        {
            j = new Vector2(0, jump) * jumpHeight;
            rb2d.AddForce(j, ForceMode2D.Impulse);
            canJump = !canJump;
        }
        jump = 0;

        if (clawChange != 0 && canChange)
            if((clawChange == 1 && activeClaw != claws.TopClaw) || (clawChange == -1 && activeClaw != claws.DwnClaw))
            {
                Debug.Log(controls.Gameplay.ClawSwap.ReadValue<Vector2>());
                ChangeClaw(clawChange);
            }


        if (clawChange == 0 && !canChange)
            canChange = !canChange;
        

    }

    private void FixedUpdate()
    {
        Vector3 m = new Vector2(move.x, 0) * speed * Time.deltaTime;
        Vector2 vel = rb2d.velocity;
        m.y = vel.y;
        rb2d.AddForce(new Vector2(0, -15.0f), ForceMode2D.Force);
        rb2d.velocity = m;
    }

    private void ChangeClaw(float dir)
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

    private void Strike()
    {
        Debug.Log("Strike");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }

        if(collision.gameObject.tag == "Crab1" || collision.gameObject.tag == "Crab2")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
