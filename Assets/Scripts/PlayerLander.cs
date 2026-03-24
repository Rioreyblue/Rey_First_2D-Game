using System;
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
        // Debug.Log(Vector2.Dot(new Vector2(0,1), new Vector2(0,1)));
        // Debug.Log(Vector2.Dot(new Vector2(0,1), new Vector2(0,1)));
        // Debug.Log(Vector2.Dot(new Vector2(0,1), new Vector2(0,1)));
        // Debug.Log(Vector2.Dot(new Vector2(0,1), new Vector2(0,1)));
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
            Debug.Log("Crash on Terrain or crash on Lanb");
        }

        float softLandingVelocityMagnitude = 4f;
        float relativeVelocityMagnitude = collision2D.relativeVelocity.magnitude;
        
        if( relativeVelocityMagnitude> softLandingVelocityMagnitude)
        {
            Debug.Log("Landed Too Hard");
            return;
        }
        // if(collision2D.relativeVelocity.magnitude > softLandingVelocityMagnitude)
        // {
        //     Debug.Log("Landed Too Hard");
        //     return;
        // }

        float dotVector = Vector2.Dot(Vector2.up, transform.up);
        float minDotVector = .90f;
        if(minDotVector < dotVector)
        {
            Debug.Log("Landed on steep angle");
            return;
        }

       
            Debug.Log("Successful Landing");

        float maxScoreAmountLandingAngle = 100f;
        float scoreDotVectorMultiplier = 10f;
        float landingAngleScore = maxScoreAmountLandingAngle - Mathf.Abs(dotVector -1f)* scoreDotVectorMultiplier * maxScoreAmountLandingAngle;

        float maxScoreAmountLandingSpeed =100f;
        float landingSpeedScore = (softLandingVelocityMagnitude - relativeVelocityMagnitude) * maxScoreAmountLandingSpeed;

        Debug.Log("landingAngleScore: "+ landingAngleScore);
        Debug.Log("landingSpeedScore: "+ landingSpeedScore);

        int score = Mathf.RoundToInt((landingAngleScore + landingSpeedScore) * landingPad.getScoreMultiplier());
          
    }
   
#endregion
}