using UnityEngine;

public class ManuelClub : MonoBehaviour
{
  public float moveSpeed = 8f;

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

      Vector3 move = new Vector3(h, 0f, v) * moveSpeed * Time.deltaTime;
      transform.position += move;


      velocity = (transform.position - lastPosition) / Time.deltaTime;
      lastPosition = transform.position;

      Debug.DrawRay(transform.position, velocity, Color.blue);
  }

  public Vector3 GetVelocity()
  {
    return velocity;
  }

}
