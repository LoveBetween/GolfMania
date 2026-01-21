using UnityEngine;

public class Rot : MonoBehaviour
{
  public float rotationSensitivity = 100f;

  public Transform playerBody;

  public float xRotation = 0f;
  private float yawRotation = 0f;
  private float mouseX,mouseY;

  public Mov playerMovement;


  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;

  }

  // Update is called once per frame
void Update() {

    float mouseX = Input.GetAxisRaw("Mouse X") * rotationSensitivity * Time.deltaTime;
    float mouseY = Input.GetAxisRaw("Mouse Y") * rotationSensitivity * Time.deltaTime;

    // Pitch (clamp immediately so xRotation never drifts past limits)
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    // Apply pitch with recoil
    float finalPitch = xRotation;
    transform.localRotation = Quaternion.Euler(finalPitch, 0f, 0f);

    // Yaw (no clamp)
    yawRotation += mouseX;
    float finalYaw = yawRotation;
    playerBody.localRotation = Quaternion.Euler(0f, finalYaw, 0f);
    //Debug.Log(currentRecoil);

  }

}
