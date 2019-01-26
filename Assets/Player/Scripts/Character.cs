using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 1.2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public float Run = 2f;
    public LayerMask Ground;

    private float SpeedInitial;
    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;


    void Start()
    {
        SpeedInitial= Speed;
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.LeftShift)){
                Speed *= Run;
            }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
                Speed = SpeedInitial;
            }
        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero){
            transform.forward = move ;
        }
       
        _velocity.y += Gravity * Time.deltaTime;

        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        _controller.Move(_velocity * Time.deltaTime);

    }
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Obstaculo")
        {
            Debug.Log("Choque contra el obstaculo");
        }
    }

}