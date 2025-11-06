using UnityEngine;

public class mouse_look_around_andMove : MonoBehaviour
{
    // Paramètres pour la rotation, le zoom et le déplacement de la caméra
    public float rotationSpeed = 2.0f; // Vitesse de rotation
    public float movementSpeed = 1.0f; // Vitesse de déplacement

    private float pitch = 0.0f; // Contrôle de la rotation verticale
    private float yaw = 90.0f; // Contrôle de la rotation horizontale

  

    void Update()
    {

        // Rotation de la caméra avec la souris
        if (Input.GetMouseButton(0)) // Bouton droit de la souris
        {

            yaw += rotationSpeed * Input.GetAxis("Mouse X");
            pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -50, 50); // Limiter la rotation verticale

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); // Appliquer la rotation
        }

        // Déplacement de la caméra avec les touches WASD ou les touches fléchées
        Vector3 movement = new Vector3(
            Input.GetAxis("Horizontal"), // "D" pour droite, "A" pour gauche
            0,
            Input.GetAxis("Vertical") // "W" pour avant, "S" pour arrière
        );

        // Appliquer la transformation selon l'orientation de la caméra
        movement = transform.TransformDirection(movement) * movementSpeed * Time.deltaTime;

        transform.position += movement; // Mettre à jour la position de la caméra

    }
}
