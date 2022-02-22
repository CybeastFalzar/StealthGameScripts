using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    
    public static bool Caught;

    float angle;
    float smoothInputMagnitude;
    float smoothMoveVelocity;
    Vector3 velocity;

   
  public static int score;
    
    new Rigidbody rigidbody;

    void Start()

    {
        
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        float inputMagnitude = inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

        float targetAngle =  Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothInputMagnitude;

        
    }
   
    void FixedUpdate()
    {
        
        
      rigidbody.MoveRotation(Quaternion.Euler(Vector3.up * (angle + 270)));
      
        
     rigidbody.MovePosition(rigidbody.position + velocity * (Time.deltaTime ));
    }


    void OnCollisionEnter(Collision win)
    {
        if (win.transform.tag == "win")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
