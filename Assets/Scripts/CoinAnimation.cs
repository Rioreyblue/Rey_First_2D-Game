using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [Header("Movement Settings")]
    public float bobSpeed = 2f;      
    public float bobHeight = 0.5f;   
    
    [Header("Rotation Settings")]
    public float rotateSpeed = 100f; 

    private Vector3 startPos;
    private float randomOffset;

    void Start()
    {
        startPos = transform.position;
        randomOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        // Smooth bobbing
        float newY = Mathf.Sin((Time.time + randomOffset) * bobSpeed) * bobHeight;
        transform.position = startPos + new Vector3(0, newY, 0);

        // Spin the coin
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

   private void OnTriggerEnter2D(Collider2D foreignObject)
{
    // This looks for the TAG assigned in the Inspector, not a script name
    if (foreignObject.CompareTag("Player"))
    {
        Debug.Log("Coin collected by the Tagged Player!");
        CollectCoin();
    }
}

    void CollectCoin()
    {
        // We simply destroy the coin object itself (gameObject)
        Destroy(gameObject);
    }
}