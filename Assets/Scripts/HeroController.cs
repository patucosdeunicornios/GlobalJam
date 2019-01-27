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
    private bool _isGrounded = true;
    private Transform _groundChecker;
    private bool isTransporting = false;


    private float stamina = 50;

    Animator anim;


    void Start()
    {
        SpeedInitial = Speed;
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);

        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if (isTransporting)
            return;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = move.normalized;

        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 20)
        {
            Speed = MaxSpeed;
            stamina -= 10 * Time.deltaTime;
        }
        else
        {
            Speed = SpeedInitial;
            stamina += 5 * Time.deltaTime;
            if (stamina > 50)
                stamina = 50;
        }

        Debug.Log(stamina);

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

    }

    void OnCollisionEnter(Collision col)
    {
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