using UnityEngine;


public class teleportation : MonoBehaviour
{
    public Transform player;
    public Transform teleportationTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //mettre le joueur en face de la boule de teleportation
        player.position = teleportationTarget.position - new Vector3(0, 0, 2);

    }

    // Update is called once per frame
    void Update()
    {
        //quand la boule de teleportation est touchée, teleporter le joueur a nouvelle position
        if (Vector3.Distance(player.position, transform.position) < 1f)
        {
            player.position = teleportationTarget.position;
        }
    }
}
