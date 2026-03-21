using UnityEngine;
using Movements;

public class PlayerLander : MovementScript
{
    [Header("Landing Requirements")]
    [SerializeField] float _maxSafeSpeed = 5f; 
    [SerializeField] float _maxSafeAngle = 15f;

    // private MovementScript _mover;

    protected override void Awake()
    {
        // Runs the Rigidbody setup in MovementScript
        // _mover = GetComponent<MovementScript>();
        base.Awake();
        // Application.targetFrameRate = 60;
    }

    protected override void FixedUpdate()
    {
        // Runs HandleThrust and HandleRotation in MovementScript
        base.FixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        // 1. Calculate impact severity
        float impactSpeed = collision2D.relativeVelocity.magnitude;

        // 2. Calculate angle (0 is upright)
        float landerAngle = Mathf.Abs(transform.rotation.eulerAngles.z);
        if (landerAngle > 180) landerAngle = 360 - landerAngle;

        // 3. Determine Landing Outcome
        if (impactSpeed < _maxSafeSpeed && landerAngle < _maxSafeAngle)
        {
            Debug.Log($"Safe Landing! Speed: {impactSpeed:F2}, Angle: {landerAngle:F2}");
        }
        else
        {
            Debug.Log($"CRASH! Speed: {impactSpeed:F2} (Max: {_maxSafeSpeed}), Angle: {landerAngle:F2}");
        }
    }
}