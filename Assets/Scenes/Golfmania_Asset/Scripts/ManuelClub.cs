using UnityEngine;

public class ManuelClub : MonoBehaviour
{
  public float moveSpeed = 8f;
  public float rotationSpeed = 120f;

  private Vector3 lastPosition;
  private Vector3 velocity;



  void Start()
  {
      lastPosition = transform.position;
  }

  void Update()
  {
      float h = Input.GetAxis("Horizontal");
      float v = Input.GetAxis("Vertical");

      Vector3 move = transform.TransformDirection(new Vector3(h, 0f, v)) * moveSpeed * Time.deltaTime;
      transform.position += move;

      float rotation = 0f;

      if (Input.GetKey(KeyCode.Q))
          rotation -= 1f;

      if (Input.GetKey(KeyCode.E))
          rotation += 1f;

        transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);


      velocity = (transform.position - lastPosition) / Time.deltaTime;
      lastPosition = transform.position;

      Debug.DrawRay(transform.position, velocity, Color.blue);
  }

  public Vector3 GetVelocity()
  {
    return velocity;
  }

}
