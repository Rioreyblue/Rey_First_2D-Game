using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLander : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float _thrustForce = 800f;
    [SerializeField] float _torqueForce = 200f;
    private Rigidbody2D _rb;
   

    private void Awake()
    {
     _rb = GetComponent<Rigidbody2D>();
     Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
       HandleThrust();
       HandleRotation();
    }

    #region Player Movements
    private void HandleThrust()
    {
        if(Keyboard.current == null) return;
        if(Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            _rb.AddForce(transform.up * _thrustForce * Time.fixedDeltaTime);
        }
    }

    private void HandleRotation()
    {
         float rotationInput = 0;

        if(Keyboard.current == null) return;
        if(Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) rotationInput += +1f;
        if(Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) rotationInput = -1f;
        
        _rb.AddTorque(rotationInput * _torqueForce * Time.fixedDeltaTime);

    }
    #endregion

#region Player Collision

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(!collision2D.gameObject.TryGetComponent(out LandingPad landingPad))
        {
            Debug.Log("Crash on Terrain");
        }
        // if(collision2D.gameObject.TryGetComponent(out Terain terain))
        // {
        //     Debug.Log("Lander has crash");
        // }
    }
   
#endregion
}