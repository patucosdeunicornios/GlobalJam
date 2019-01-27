using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 1.2f;
    public float MaxSpeed = 10f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public float Run = 2f;
    public LayerMask Ground;

    private float SpeedInitial;
    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = false;
    private Transform _groundChecker;
    private bool isTransporting = false;

    public float maxStamina = 35;
    private float stamina;

    Animator anim;

    float delayed = 0;


    void Start()
    {

        stamina = maxStamina;
        SpeedInitial = Speed;
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);

        anim = GetComponentInChildren<Animator>();

        if (this.gameObject.active == false)
        {
            this.gameObject.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        gravity();
        movement();

    }

    bool isGrounded()
    {
        return  Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

    }

    void gravity()
    {
        if (isGrounded())
            return;
        Vector3 move = new Vector3(0, 0, 0);
        move.y = move.y - (20.0f * Time.deltaTime);
        _controller.Move(move * Time.deltaTime);
    }

    void movement()
    {
        if (!isGrounded())
            return;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = move.normalized;
        sprint();

        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        float moveAnim = _controller.velocity.magnitude;
        anim.SetFloat("speed", moveAnim);
    }


    void sprint()
    {


        if (delayed >= 0)
        {
            delayed -= Time.deltaTime;
            Speed = SpeedInitial;
            stamina += 5 * Time.deltaTime;
            return;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (delayed <=0)
            {
                Speed = MaxSpeed;
                stamina -= 8 * Time.deltaTime;
            }
        }
        else
        {
            Speed = SpeedInitial;
            stamina += 5 * Time.deltaTime;
            if (stamina > maxStamina)
                stamina = maxStamina;
        }

        if (stamina <= 3)
        {
            delayed = 2;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Obstaculo")
        {
            Debug.Log("Choque contra el obstaculo");
        }
    }


    public void teleport(Vector3 destination)
    {
        isTransporting = true;

        Debug.Log("teleporting");

        transform.position = destination;

        StartCoroutine(FinishTeleport());
    }

    IEnumerator FinishTeleport()
    {
        yield return new WaitForSeconds(1);
        isTransporting = false;
    }


}