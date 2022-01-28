using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{


    public float speed = 1f;
    public Rigidbody2D rb2d;
    public GameObject topClaw, midClaw, botClaw, dwnClaw;

    private bool LeftKeyDown, RightKeyDown = false;

    public enum claws
    {
        TopClaw,
        MidClaw,
        BotClaw,
        DwnClaw,
    }
    public claws activeClaw;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        topClaw = transform.Find("TOP CLAW").gameObject;
        midClaw = transform.Find("MID CLAW").gameObject;
        botClaw = transform.Find("BOT CLAW").gameObject;
        dwnClaw = transform.Find("DWN CLAW").gameObject;
        activeClaw = claws.MidClaw;
    }

    void Update()
    {
        if (Input.GetButtonDown("Left"))
            LeftKeyDown = true;
        else if (Input.GetButtonUp("Left"))
            LeftKeyDown = false;
        if (Input.GetButtonDown("Right"))
            RightKeyDown = true;
        else if (Input.GetButtonUp("Right"))
            RightKeyDown = false;
        if (Input.GetButtonDown("Jump"))
            Jump();
        if (Input.GetButtonDown("ClawUp") && activeClaw != claws.TopClaw)
            ChangeClaw(0);
        if (Input.GetButtonDown("ClawDown") && activeClaw != claws.DwnClaw)
            ChangeClaw(1);
    }

    private void FixedUpdate()
    {
        if (LeftKeyDown || RightKeyDown)
            Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 tempVect = new Vector2(h, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb2d.MovePosition(rb2d.transform.position + tempVect);
    }

    private void Jump()
    {

    }

    private void ChangeClaw(int dir)
    {
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
                        if (dir == 0)
                        {
                            activeClaw = claws.TopClaw;
                            topClaw.SetActive(true);
                        }
                        else
                        {
                            activeClaw = claws.BotClaw;
                            botClaw.SetActive(true);
                        }
                        break;
                    }

            case claws.BotClaw:
                {
                    botClaw.SetActive(false);
                    if (dir == 0)
                    {
                        activeClaw = claws.MidClaw;
                        midClaw.SetActive(true);
                    }
                    else
                    {
                        activeClaw = claws.DwnClaw;
                        dwnClaw.SetActive(true);
                    }
                    break;
                }

            case claws.DwnClaw:
                    {
                        botClaw.SetActive(false);
                        activeClaw = claws.BotClaw;
                        midClaw.SetActive(true);
                        break;
                    }
            }
    }

    private void Strike()
    {

    }
}
