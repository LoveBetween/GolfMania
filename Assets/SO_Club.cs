using UnityEngine;


[CreateAssetMenu(fileName = "Club", menuName = "Clubs", order = 1)]
public class SO_Club : ScriptableObject
{


    public float length, lie, loft, head_mass;
    public string club_name;
    public float stifness;

    public int nbFlexPoint;


    public GameObject PF_shaftSegment;

}
