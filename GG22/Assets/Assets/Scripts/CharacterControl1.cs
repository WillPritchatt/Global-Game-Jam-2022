using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class CharacterControl1 : MonoBehaviour
{ 
    //Vector2 move;

    //public int CrabNumber;

    //PlayerControls control;

    //PlayerInput playerInput;

    //public int PlayerNumber;

    ////public CrabBase Crab1, Crab2;

    //public float speed = 1f;
    //public float jumpHeight = 3f;
    //float clawChange;
    //bool canChange = true;
    //bool grounded = true;
    //float jumped;

    //public Rigidbody2D rb2d;
    //public GameObject topClaw, midClaw, botClaw, dwnClaw;

    //public enum claws
    //{
    //    TopClaw,
    //    MidClaw,
    //    BotClaw,
    //    DwnClaw,
    //}
    //public claws activeClaw;


    //private void Awake()
    //{
    //    playerInput = GetComponent<PlayerInput>();
    //    Debug.Log(playerInput.playerIndex);

    //    control = new PlayerControls();
    //    control.AllP1.Enable();

    //    //Crab1 = GetComponentsInChildren<CrabBase>()[0];
    //    //Crab2 = GetComponentsInChildren<CrabBase>()[1];

    //    rb2d = gameObject.GetComponent<Rigidbody2D>();
    //    topClaw = transform.Find("TOP CLAW").gameObject;
    //    midClaw = transform.Find("MID CLAW").gameObject;
    //    botClaw = transform.Find("BOT CLAW").gameObject;
    //    dwnClaw = transform.Find("DWN CLAW").gameObject;
    //    activeClaw = claws.MidClaw;


    //    control.Left.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    //    control.Left.Move.canceled += ctx => move = Vector2.zero;
    //    control.Right.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    //    control.Right.Move.canceled += ctx => move = Vector2.zero;

    //    control.Left.ClawSwap.performed += ctx => clawChange = ctx.ReadValue<Vector2>().y;
    //    control.Right.ClawSwap.performed += ctx => clawChange = ctx.ReadValue<Vector2>().y;

    //    control.Left.Jump.performed += ctx => jumped = ctx.ReadValue<float>();
    //    control.Right.Jump.performed += ctx => jumped = ctx.ReadValue<float>();

    //    control.Left.Strike.performed += ctx => Strike();
    //    control.Right.Strike.performed += ctx => Strike();

    //    if (gameObject.name == "Crab1")
    //    {
    //        control.Left.Enable();
    //    }
    //    else if (gameObject.name == "Crab2")
    //    {
    //        control.Right.Enable();
    //    }
    //}

    //void Update()
    //{
    //    Vector2 j;
    //    if (grounded && jumped != 0)
    //    {
    //        grounded = false;
    //        j = new Vector2(0, 1) * jumpHeight;
    //        rb2d.AddForce(j, ForceMode2D.Impulse);
    //    }
    //    jumped = 0;

    //    if (clawChange != 0 && canChange)
    //        if ((clawChange == 1 && activeClaw != claws.TopClaw) || (clawChange == -1 && activeClaw != claws.DwnClaw))
    //        {
    //            Debug.Log(control.Right.ClawSwap.ReadValue<Vector2>());
    //            ChangeClaw(clawChange);
    //        }


    //    if (clawChange == 0 && !canChange)
    //        canChange = !canChange;
    //}

    //private void FixedUpdate()
    //{
    //    Vector3 m = new Vector2(move.x, 0) * speed * Time.deltaTime;
    //    Vector2 vel = rb2d.velocity;
    //    m.y = vel.y;
    //    rb2d.AddForce(new Vector2(0, -15.0f), ForceMode2D.Force);
    //    rb2d.velocity = m;
    //}

    ////public void OnMoveLeft(InputAction.CallbackContext context)
    ////{
    ////    move = context.ReadValue<Vector2>();
    ////    Crab1.MoveObject(move);
    ////}

    ////public void OnMoveRight(InputAction.CallbackContext context)
    ////{
    ////    move = context.ReadValue<Vector2>();
    ////    Crab2.MoveObject(move);
    ////}

    //public void ChangeClaw(float dir)
    //{
    //    canChange = !canChange;
    //    switch (activeClaw)
    //    {
    //        case claws.TopClaw:
    //            {
    //                topClaw.SetActive(false);
    //                activeClaw = claws.MidClaw;
    //                midClaw.SetActive(true);
    //                break;
    //            }

    //        case claws.MidClaw:
    //            {
    //                midClaw.SetActive(false);
    //                if (dir > 0)
    //                {
    //                    activeClaw = claws.TopClaw;
    //                    topClaw.SetActive(true);
    //                }
    //                else if (dir < 0)
    //                {
    //                    activeClaw = claws.BotClaw;
    //                    botClaw.SetActive(true);
    //                }
    //                break;
    //            }

    //        case claws.BotClaw:
    //            {
    //                botClaw.SetActive(false);
    //                if (dir > 0)
    //                {
    //                    activeClaw = claws.MidClaw;
    //                    midClaw.SetActive(true);
    //                }
    //                else if (dir < 0)
    //                {
    //                    activeClaw = claws.DwnClaw;
    //                    dwnClaw.SetActive(true);
    //                }
    //                break;
    //            }

    //        case claws.DwnClaw:
    //            {
    //                dwnClaw.SetActive(false);
    //                activeClaw = claws.BotClaw;
    //                botClaw.SetActive(true);
    //                break;
    //            }
    //    }
    //}

    //private void Strike()
    //{
    //    Debug.Log("Strike");
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Floor")
    //    {
    //        grounded = true;
    //    }

    //    if (collision.gameObject.tag == "Crab1" || collision.gameObject.tag == "Crab2")
    //    {
    //        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>());
    //    }
    //}

    //private int GetPlayerNo()
    //{
    //    int count = 0;
    //    foreach(var obj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
    //    {
    //        if(obj.name == "Player(Clone)")
    //        {
    //            count++;
    //        }
    //    }
    //    return count;
    //}
}
