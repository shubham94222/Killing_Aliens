using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform cameraHolder;
    public float smoothTime = 0.1f;

    private Rigidbody rb;
    private Vector3 smoothVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get the player's input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the player in the appropriate direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Make the player jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Move the camera to follow the player
        Vector3 targetPosition = transform.position + Vector3.up * 1.5f - transform.forward * 2f;
        cameraHolder.position = Vector3.SmoothDamp(cameraHolder.position, targetPosition, ref smoothVelocity, smoothTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Stop the player's vertical movement when they hit the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }
    }
}
