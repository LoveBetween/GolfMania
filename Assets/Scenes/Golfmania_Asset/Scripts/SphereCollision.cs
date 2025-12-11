using UnityEngine;

public class SphereCollision : MonoBehaviour
{
  public GameObject[] objectsColliders;

  public float radius;
  private Vector3 center;
  public bool enableDebug = false;

  [Range(0f, 1f)]
  public float alpha = 0.5f;
  public Renderer r;

  bool collided = false;

  private Vector3 collisionNormal = Vector3.zero;


  void Start()
  {
    r = GetComponent<MeshRenderer>();
    center = transform.position;

  }
  void FixedUpdate()
  {
    collided = Collided();
  }
  void Update()
  {
    if (collided) {
      r.material.SetColor("_BaseColor", Color.red);
    }
    else
    {
      r.material.SetColor("_BaseColor", Color.white);
    }

  }

  public bool GetCollision()
  {
    return collided;
  }
  public Vector3 GetNormal()
  {
      return collisionNormal;
  }

  //Find closest point on a box collision to the sphere center
  private Vector3 ComputeBoxNormal(BoxCollision box)
  {
      Vector3 closestPoint = new Vector3(
          Mathf.Clamp(transform.position.x, box.min_x, box.max_x),
          Mathf.Clamp(transform.position.y, box.min_y, box.max_y),
          Mathf.Clamp(transform.position.z, box.min_z, box.max_z)
      );

      return (transform.position - closestPoint).normalized;
  }
  private Vector3 ComputeBoxNormal(SphereCollision sphere)
  {
      Vector3 sphereCenter = sphere.center;

      return (transform.position - sphereCenter).normalized;
  }

  private bool Collided()
  {

    bool collisionHappend = false;
    for (int i =0;i<objectsColliders.Length;i++) {
      bool isColliding;
      if (objectsColliders[i].name == "Sphere")
      {
        SphereCollision sphere = objectsColliders[i].GetComponent<SphereCollision>();
        float dist = Vector3.Distance(transform.position, sphere.transform.position);
        float sumRadius = radius + sphere.radius;
        isColliding = dist <= sumRadius;
        if (isColliding)
        {
         collisionHappend = true;
         collisionNormal = ComputeBoxNormal(sphere);

            //Corriger la position pour ne pas avoir de depassement
            // float penetration = sumRadius - dist;
            // transform.position += collisionNormal * penetration;
            
        }
      }
      else
      {
        BoxCollision box = objectsColliders[i].GetComponent<BoxCollision>();
        isColliding = (transform.position.x+radius >= box.min_x &&
                       transform.position.x-radius <= box.max_x &&
                       transform.position.y+radius >= box.min_y &&
                       transform.position.y-radius <= box.max_y &&
                       transform.position.z+radius >= box.min_z &&
                       transform.position.z-radius <= box.max_z);

                       if (isColliding)
                       {
                         collisionHappend = true;
                         collisionNormal = ComputeBoxNormal(box);

                      //   //Corriger la position pour ne pas avoir de depassement
                      //    Vector3 closestPoint = new Vector3(
                      //     Mathf.Clamp(transform.position.x, box.min_x, box.max_x),
                      //     Mathf.Clamp(transform.position.y, box.min_y, box.max_y),
                      //     Mathf.Clamp(transform.position.z, box.min_z, box.max_z)
                      // );
                      //
                      // Vector3 diff = transform.position - closestPoint;
                      // float dist = diff.magnitude;
                      //
                      // float penetration = radius - dist;
                      //
                      // if (penetration > 0f)
                      //     transform.position += collisionNormal * penetration;
                       }
      }




    }

    return collisionHappend;
  }

  private void OnDrawGizmos()
  {
      if (enableDebug) {
        // Set the color with custom alpha.
        Gizmos.color = new Color(1f, 0f, 0f, alpha); // Red with custom alpha
        // Draw the sphere.
        Gizmos.DrawSphere(transform.position, radius);

        // Draw wire sphere outline.
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
      }

  }
}
