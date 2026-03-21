using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [Header("Movement Settings")]
    public float bobSpeed = 2f;      // How fast it moves up and down
    public float bobHeight = 0.5f;   // How far up and down it goes
    
    [Header("Rotation Settings")]
    public float rotateSpeed = 100f; // Degrees per second

    private Vector3 startPos;
    private float randomOffset;

    void Start()
    {
        // Record the starting position of the coin
        startPos = transform.position;
        randomOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        // 1. Calculate the new Y position using a Sine wave
        // float newY = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        
        // 2. Apply the movement relative to the start position
        // transform.position = startPos + new Vector3(0, newY, 0);
        //randomize
        float newY = Mathf.Sin((Time.time + randomOffset) * bobSpeed) * bobHeight;
    transform.position = startPos + new Vector3(0, newY, 0);

        // 3. Optional: Spin the coin
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

   // Use OnTriggerEnter2D for 2D games!
private void OnTriggerEnter2D(Collider2D foreignObject) 
{
    // Check the tag of the 2D object that entered
    if (foreignObject.CompareTag("Player"))
    {
        Debug.Log("Coin Collected!"); // Check your Console to see if this appears
        Destroy(gameObject);
    }
}

    void CollectCoin()
    {
        // 1. (Optional) Play a sound or spawn a particle effect here
        // AudioSource.PlayClipAtPoint(coinSound, transform.position);

        // 2. Add to the player's score (if you have a ScoreManager)
        // ScoreManager.instance.AddScore(1);

        // 3. Remove the coin from the game
        Destroy(gameObject);
    }
}