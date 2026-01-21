using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class ManuelClub : MonoBehaviour
{
    public Transform rightHandController;
    public Vector3 rotationOffsetEuler;
    private Vector3 lastPosition;
    private Vector3 velocity;

    void Start()
    {
        XROrigin xrOrigin = GameObject.FindAnyObjectByType<XROrigin>();
        rightHandController = xrOrigin.transform.Find("Camera Offset").Find("Right Controller");
        lastPosition = rightHandController.position;
    }

    void Update()
    {
        transform.position = rightHandController.position;

        Vector3 up = -rightHandController.forward;

        Vector3 right = Vector3.Cross(rightHandController.up, up).normalized;
        Vector3 forward = Vector3.Cross(up, right);

        transform.rotation = Quaternion.LookRotation(forward, up);

        transform.rotation *= Quaternion.Euler(rotationOffsetEuler);

        velocity = (rightHandController.position - lastPosition) / Time.deltaTime;
        lastPosition = rightHandController.position;
        //velocity = (transform.position - lastPosition) / Time.deltaTime;
        //lastPosition = transform.position;
        Debug.DrawRay(transform.position, transform.up, Color.green);      // UP du club
        Debug.DrawRay(transform.position, rightHandController.forward, Color.blue); // Raycast controller
        Debug.DrawRay(transform.position, velocity, Color.red);           // Velocity
    }

    public Vector3 GetVelocity()
    {
        return velocity;
    }
}

//public class ManuelClub : MonoBehaviour
//{
//  public float moveSpeed = 8f;
//  public float rotationSpeed = 120f;

//  private Vector3 lastPosition;
//  private Vector3 velocity;



//  void Start()
//  {
//      lastPosition = transform.position;
//  }

//  void Update()
//  {
//      float h = Input.GetAxis("Horizontal");
//      float v = Input.GetAxis("Vertical");

//      Vector3 move = transform.TransformDirection(new Vector3(h, 0f, v)) * moveSpeed * Time.deltaTime;
//      transform.position += move;

//      float rotation = 0f;

//      if (Input.GetKey(KeyCode.Q))
//          rotation -= 1f;

//      if (Input.GetKey(KeyCode.E))
//          rotation += 1f;

//        transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);


//      velocity = (transform.position - lastPosition) / Time.deltaTime;
//      lastPosition = transform.position;

//      Debug.DrawRay(transform.position, velocity, Color.blue);
//  }

//  public Vector3 GetVelocity()
//  {
//    return velocity;
//  }

//}
