using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = objectToFollow.position - offset;    
    }
}
