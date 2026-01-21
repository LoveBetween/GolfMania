using UnityEngine;

public class BoxCollision : MonoBehaviour
{

    public Vector3 center;
    public Vector3 size = new Vector3(1,1,1);

    public float radius = 0.1f;
    [Range(0f, 1f)]
    public float alpha = 1f;



    [SerializeField]
    private Vector3[] default_boxCollider_Points = new Vector3[8] {new Vector3(-0.5f,0.5f,0.5f),
                                                           new Vector3(-0.5f,0.5f,-0.5f),
                                                           new Vector3(0.5f,0.5f,0.5f),
                                                           new Vector3(0.5f,0.5f,-0.5f),
                                                           new Vector3(-0.5f,-0.5f,0.5f),
                                                           new Vector3(-0.5f,-0.5f,-0.5f),
                                                           new Vector3(0.5f,-0.5f,0.5f),
                                                           new Vector3(0.5f,-0.5f,-0.5f)};

    private Vector3[] world_boxCollider_Points = new Vector3[8];

    public float min_x,max_x,min_y,max_y,min_z,max_z;

    public Vector3 collisionPoint;

    public float normalDebugSize = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void FixedUpdate()
    {
      Update_BoxCollider_Position();
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 forward = transform.TransformDirection(Vector3.forward) * normalDebugSize;
      Debug.DrawRay(transform.position, forward, Color.green);

      Vector3 up = transform.TransformDirection(Vector3.up) * normalDebugSize;
      Debug.DrawRay(transform.position, up, Color.green);

      Vector3 down = transform.TransformDirection(Vector3.down) * normalDebugSize;
      Debug.DrawRay(transform.position, down, Color.green);

      Vector3 left = transform.TransformDirection(Vector3.left) * normalDebugSize;
      Debug.DrawRay(transform.position, left, Color.green);

      Vector3 right = transform.TransformDirection(Vector3.right) * normalDebugSize;
      Debug.DrawRay(transform.position, right, Color.green);

      Vector3 back = transform.TransformDirection(Vector3.back) * normalDebugSize;
      Debug.DrawRay(transform.position, back, Color.green);


    }
    private void Update_BoxCollider_Position()
    {
      for(int i=0;i<default_boxCollider_Points.Length;i++)
      {
        world_boxCollider_Points[i] = transform.TransformPoint(new Vector3(default_boxCollider_Points[i].x*size.x,
                                                                     default_boxCollider_Points[i].y*size.y,
                                                                     default_boxCollider_Points[i].z*size.z)+center);
      }

      min_x = world_boxCollider_Points[0].x;
      min_y = world_boxCollider_Points[0].y;
      min_z = world_boxCollider_Points[0].z;
      max_x = world_boxCollider_Points[0].x;
      max_y = world_boxCollider_Points[0].y;
      max_z = world_boxCollider_Points[0].z;

      for(int i=1;i<default_boxCollider_Points.Length;i++)
      {
        min_x = world_boxCollider_Points[i].x<=min_x?world_boxCollider_Points[i].x:min_x;
        min_y = world_boxCollider_Points[i].y<=min_y?world_boxCollider_Points[i].y:min_y;
        min_z = world_boxCollider_Points[i].z<=min_z?world_boxCollider_Points[i].z:min_z;
        max_x = world_boxCollider_Points[i].x>=max_x?world_boxCollider_Points[i].x:max_x;
        max_y = world_boxCollider_Points[i].y>=max_y?world_boxCollider_Points[i].y:max_y;
        max_z = world_boxCollider_Points[i].z>=max_z?world_boxCollider_Points[i].z:max_z;
      }
    }
    public void Set_CollisionPoint(Vector3 collisionPoint)
    {
      this.collisionPoint = collisionPoint;
    }

    public Vector3 Get_CollisionPoint()
    {
      return this.collisionPoint;
    }

    private void OnDrawGizmos()
    {

      if (default_boxCollider_Points.Length>0)
      {
        for (int i=0;i<8;i++) {



          if (Application.isPlaying) {
            Gizmos.color = new Color(1f, 0f, 0f, alpha); // Red with custom alpha
            Gizmos.DrawSphere(world_boxCollider_Points[i],radius);
            // Draw wire sphere outline.
            Gizmos.color = new Color(1f, 1f, 1f, alpha); // White with custom alpha
            Gizmos.DrawWireSphere(world_boxCollider_Points[i], radius);
          }
          else
          {
            Gizmos.color = new Color(1f, 0f, 0f, alpha); // Red with custom alpha
            Gizmos.DrawSphere(transform.TransformPoint(new Vector3(default_boxCollider_Points[i].x*size.x,
                                                                   default_boxCollider_Points[i].y*size.y,
                                                                   default_boxCollider_Points[i].z*size.z)+center),radius);
            Gizmos.color = new Color(1f, 1f, 1f, alpha); // White with custom alpha
            Gizmos.DrawWireSphere(transform.TransformPoint(new Vector3(default_boxCollider_Points[i].x*size.x,
                                                                   default_boxCollider_Points[i].y*size.y,
                                                                   default_boxCollider_Points[i].z*size.z)+center),radius);
          }


        }
      }

    }

    public void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.blue;

      Matrix4x4 old = Gizmos.matrix;
      Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
      Gizmos.DrawWireCube(center, size);
      Gizmos.matrix = old;
    }
}
