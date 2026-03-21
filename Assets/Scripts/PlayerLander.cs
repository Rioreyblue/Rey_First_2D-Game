using System;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerLander : MonoBehaviour
{

    private Rigidbody2D _playerLander;
    [Header("Player Components")]
    [SerializeField] float _playerLanderSpeed;  
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

        // this player 2

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


    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        // 1. Get the impact velocity (how hard we hit)
    float impactSpeed = collision2D.relativeVelocity.magnitude;

    // 2. Define our safety thresholds
    float maxSafeSpeed = 5f; 
    float maxSafeAngle = 15f; // degrees from upright

    // 3. Check the angle of the lander (0 is perfectly upright)
    float landerAngle = Mathf.Abs(transform.rotation.eulerAngles.z);
    // Adjusting for Unity's 0-360 rotation logic
    if (landerAngle > 180) landerAngle = 360 - landerAngle;

    if (impactSpeed < maxSafeSpeed && landerAngle < maxSafeAngle)
    {
        Debug.Log($"Safe Landing! Speed: {impactSpeed:F2}, Angle: {landerAngle:F2}");
        // You could trigger a "Level Complete" UI here
    }
    else
    {
        Debug.Log($"CRASH! Speed: {impactSpeed:F2} (Max: {maxSafeSpeed}), Angle: {landerAngle:F2}");
        // You could trigger an explosion effect or restart the level here
        
    }
    }
}
