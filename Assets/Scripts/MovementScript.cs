using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Movements {
public class MovementScript : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float _thrustForce = 800f;
        [SerializeField] float _torqueForce = 200f;

        private Rigidbody2D _playerLander;
        
        private void Awake()
        {
            _playerLander.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            HandleThrust();
            HandleRotation();
        }

        private void HandleThrust()
        {
        //     if (Keyboard.current.upArrowKey.isPressed||Keyboard.current.wKey.isPressed)
        //     {
        //         _playerLander.AddForce(transform.up * _thrustForce * Time.deltaTime);
        //     }

        //     _playerLander.AddForce((Keyboard.current.upArrowKey.isPressed||Keyboard.current.wKey.isPressed ? _thrustForce : 0)* transform.up * Time.deltaTime);

            float currentForce = Keyboard.current.upArrowKey.isPressed||Keyboard.current.wKey.isPressed? _thrustForce : 0;
            _playerLander.AddForce( transform.up * currentForce * Time.deltaTime);
        }

                private void HandleRotation()
        {
            // if(Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            // {
            //     _playerLander.AddTorque(_torqueForce * Time.deltaTime);
            // }

            // if(Keyboard.current.rightArrowKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            // {
            //     _playerLander.AddTorque(-_torqueForce * Time.deltaTime);
            // }


            float rotationInput = 0f;

            if(Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) rotationInput = +1f;
            if(Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) rotationInput = -1f;

            _playerLander.AddTorque(rotationInput * _torqueForce * Time.deltaTime);
        }
    }
}