using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerLander : MonoBehaviour
{

    private Rigidbody2D _playerLander;
   private void Awake()
    {
        _playerLander = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            float force = 800f;
            _playerLander.AddForce(force * transform.up * Time.deltaTime);
        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            float turnSpeed = +100f;
            _playerLander.AddTorque(turnSpeed * Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            float turnSpeed = -100f;
            _playerLander.AddTorque(turnSpeed * Time.deltaTime);
        }

        if (Keyboard.current.wKey.isPressed)
        {
    
            float force = 800f;
            _playerLander.AddForce(force * transform.up * Time.deltaTime);
        
        }

        if (Keyboard.current.dKey.isPressed)
        {
    
             float turnSpeed = -100f;
            _playerLander.AddTorque(turnSpeed * Time.deltaTime);
        
        }

        if (Keyboard.current.aKey.isPressed)
        {
    
            float turnSpeed = +100f;
            _playerLander.AddTorque(turnSpeed * Time.deltaTime);
        
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("The Lander OnCollisionEnter2D");
    }
}
