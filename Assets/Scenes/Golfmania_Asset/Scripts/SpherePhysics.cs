using UnityEngine;

public class SpherePhysics : MonoBehaviour
{
  [SerializeField]
  private float gravity = 9.81f;

  private Vector3 velocity;

  [Range(0f, 1f)]
  public float coeff_restit = 0.8f;

  private SphereCollision sphereCollider;

  public float friction = 0.5f;
  private Vector3 angularVelocity;

  public float mass = 1f;

  void Start()
  {
      sphereCollider = GetComponent<SphereCollision>();
      velocity = new Vector3(0f, 0f, 0f);
  }

  void Update()
  {
      Debug.DrawRay(transform.position, velocity.normalized, Color.red);
  }

  void FixedUpdate()
  {
      //Gravity only if there is no collision
      if (!sphereCollider.GetCollision() || velocity.y > 0f)
      {
          velocity += Vector3.down * gravity * Time.fixedDeltaTime;
      }

      transform.position += velocity * Time.fixedDeltaTime;


      if (sphereCollider.GetCollision())
      {
          Vector3 normal = sphereCollider.GetNormal().normalized;

          //Reflection
          //====================================================================
          //To know if the sphere is moving into the collider and by how much
          float sphereToCollider = Vector3.Dot(velocity, normal);
          if (sphereToCollider < 0f)
          {
              //Reflection/Bounce
              velocity = velocity - (1 + coeff_restit) * sphereToCollider * normal;

              //Remove jittering/Stuttering
              if (velocity.magnitude < 0.01f)
                  velocity = Vector3.zero;
          }
          //====================================================================
          //Friction
          //====================================================================
          Vector3 tangent = velocity - Vector3.Dot(velocity, normal) * normal;
          tangent *= (1f - friction * Time.fixedDeltaTime);
          velocity = tangent + Vector3.Dot(velocity, normal) * normal;
          //====================================================================
      }

      //Angular velocity
      //==========================================================================
      //angularVelocity formula w = velocity/rayon
      //Get a perpendicular vector to both vector
      angularVelocity = Vector3.Cross(Vector3.up, velocity) / sphereCollider.radius;
      // Apply rotation
      transform.Rotate(angularVelocity * Mathf.Rad2Deg * Time.fixedDeltaTime,Space.World);
      //==========================================================================
  }

  public void AddImpulse(Vector3 impulse)
  {
      velocity += impulse / mass;
  }

  public Vector3 GetVelocity()
  {
    return velocity;
  }

}
