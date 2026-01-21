using UnityEngine;

public class Mov : MonoBehaviour
{
  private Rigidbody rb;

  private Vector3 direction;


  private float horizontalMove = 0f;
  private float verticalMove = 0f;

  public float walkSpeed = 4f;
  public float runSpeed = 7f;

  //Prevent sliding
  public float groundDrag;
  public float playerHeight;
  public LayerMask groundLayer;
  public bool isGrounded;

  public PhysicsMaterial physicMaterial;
  public CapsuleCollider playerCollider;


  public Rot cameraRotation;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    // QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
    Application.targetFrameRate = -1;
    rb = GetComponent<Rigidbody>();

  }

  // Update is called once per frame
  void Update()
  {

      horizontalMove = Input.GetAxisRaw("Horizontal");
      verticalMove = Input.GetAxisRaw("Vertical");

  }

  void FixedUpdate()
  {
    isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f+0.2f, groundLayer);
    if (isGrounded)
    {
      rb.linearDamping = groundDrag;
    }
    else
    {
      rb.linearDamping = 0;
    }
    Vector3 flatVel = new Vector3(rb.linearVelocity.x,0f,rb.linearVelocity.z);

    bool isRunning = IsRunning();

    float targetSpeed = isRunning ? runSpeed : walkSpeed;

    if (flatVel.magnitude>targetSpeed) {


      //animW.SetBool("isRunning",true);
      Vector3 limitedVel = flatVel.normalized * targetSpeed;
      rb.linearVelocity = new Vector3(limitedVel.x,rb.linearVelocity.y,limitedVel.z);

    }
    else
    {

      //animW.SetBool("isRunning",false);
    }
    direction = (transform.right * horizontalMove + transform.forward * verticalMove).normalized;

    if (isRunning) {
      rb.AddForce(direction.normalized * runSpeed*10f,ForceMode.Acceleration);

    }
    else
    {
      rb.AddForce(direction.normalized * walkSpeed*10f,ForceMode.Acceleration);

    }






  }


  public bool IsRunning()
  {
      return Input.GetKey(KeyCode.LeftShift) && verticalMove > 0.1f;
  }

}
