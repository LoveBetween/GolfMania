using System.ComponentModel;
using System.Net;
using Unity.Mathematics;
using UnityEngine;

public class Club : MonoBehaviour
{
    public SO_Club so_club;
    public float length,lie,loft,stifness;

    public float head_mass, head_width, head_height;

    public Vector3 speed, acceleration, force;

    public Transform prev_head_pos;
    public Transform head_pos;
    
    public Vector3 prev_hand_pos;
    public Vector3 hand_pos;
    public Vector3 heel_pos;


    public Vector3[] prev_flexPoints_pos;
    public Vector3[] flexPoints_pos;

    public GameObject[] shaftSegments;

    public Transform headObject;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.shaftObject = this.gameObject.transform.Find("Shaft");
        this.headObject = this.gameObject.transform.Find("Head");


        length = so_club.length;
        lie = so_club.lie;
        loft = so_club.loft;
        head_mass = so_club.head_mass;
        stifness = so_club.stifness;
        
        prev_head_pos = this.transform;
        head_pos = prev_head_pos;

        prev_flexPoints_pos = new Vector3[so_club.nbFlexPoint];
        flexPoints_pos = prev_flexPoints_pos;

        shaftSegments = new GameObject[so_club.nbFlexPoint + 1];

        heel_pos = prev_head_pos.position + new Vector3(0, 0, head_width / 2);
        prev_hand_pos = heel_pos + new Vector3(0, this.length * math.cos(math.radians(90 - this.lie)), this.length * math.sin(math.radians(90 - this.lie)));
        hand_pos = prev_hand_pos;
        Debug.Log("prev_head_pos: " + prev_head_pos.position);
        Debug.Log("prev_hand_pos: " + prev_hand_pos);

        float distFlexpoint;
        float segmentLength;

        if (so_club.nbFlexPoint == 1)
        {
            distFlexpoint = this.length / 4;
            segmentLength = distFlexpoint / 2;

            prev_flexPoints_pos[0] = heel_pos + new Vector3(0, distFlexpoint * math.cos(math.radians(90 - this.lie)), distFlexpoint * math.sin(math.radians(90 - this.lie)));
            flexPoints_pos[0] = prev_flexPoints_pos[0];

            shaftSegments[0] = Instantiate(so_club.PF_shaftSegment);
            shaftSegments[0].transform.position = heel_pos + new Vector3(0, segmentLength * math.cos(math.radians(90 - this.lie)), segmentLength * math.sin(math.radians(90 - this.lie)));
            shaftSegments[0].transform.localScale = new Vector3(1, segmentLength, 1);
            shaftSegments[0].transform.rotation = Quaternion.Euler(90 - this.lie, 0, 0);

            segmentLength = (this.length - this.length / 4)/2;

            shaftSegments[1] = Instantiate(so_club.PF_shaftSegment);
            shaftSegments[1].transform.position = heel_pos + new Vector3(0, segmentLength * math.cos(math.radians(90 - this.lie)), segmentLength * math.sin(math.radians(90 - this.lie))) + new Vector3(0, this.length / 4 * math.cos(math.radians(90 - this.lie)), this.length / 4 * math.sin(math.radians(90 - this.lie)));
            shaftSegments[1].transform.rotation = Quaternion.Euler(90 - this.lie, 0, 0);
            shaftSegments[1].transform.localScale = new Vector3(1, segmentLength, 1);

        }
        else if(so_club.nbFlexPoint >= 2)
        {
            distFlexpoint = this.length / (so_club.nbFlexPoint + 1);

            segmentLength = distFlexpoint/2;

            //shaftSegments[0] = Instantiate(so_club.PF_shaftSegment);
            //shaftSegments[0].transform.position = heel_pos + new Vector3(0, segmentLength * math.cos(math.radians(90 - this.lie)), segmentLength * math.sin(math.radians(90 - this.lie)));
            //shaftSegments[0].transform.localScale = new Vector3(1, segmentLength, 1);
            //shaftSegments[0].transform.rotation = Quaternion.Euler(90 - this.lie, 0, 0);

            for (int i = 0; i < so_club.nbFlexPoint; i++)
            {
                prev_flexPoints_pos[i] = heel_pos + new Vector3(0, distFlexpoint*  math.cos(math.radians(90 - this.lie)), distFlexpoint * math.sin(math.radians(90 - this.lie)));
                flexPoints_pos[i] = prev_flexPoints_pos[i];


                //shaftSegments[i+1] = Instantiate(so_club.PF_shaftSegment);
                //shaftSegments[i + 1].transform.position = heel_pos + new Vector3(0, distFlexpoint * math.cos(math.radians(90 - this.lie)), distFlexpoint * math.sin(math.radians(90 - this.lie))) + new Vector3(0, segmentLength * math.cos(math.radians(90 - this.lie)), segmentLength * math.sin(math.radians(90 - this.lie)));
                //shaftSegments[i + 1].transform.rotation = Quaternion.Euler(90 - this.lie, 0, 0);
                //shaftSegments[i + 1].transform.localScale = new Vector3(1, segmentLength, 1);

                distFlexpoint += this.length / (so_club.nbFlexPoint + 1);

            }
        }

        headObject.position = this.head_pos.position;
        headObject.rotation = Quaternion.Euler(0f, 0f, loft);
        headObject.localScale = new Vector3(headObject.localScale.x,this.head_height,this.head_width);




    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            for (int i = 0; i < so_club.nbFlexPoint; i++)
            {

                Gizmos.color = new Color(1f, 0f, 0f, 1f); // Red with custom alpha

                // Draw the sphere.
                Gizmos.DrawSphere(flexPoints_pos[i], 1f);
            }
            Gizmos.color = new Color(0f, 1f, 0f, 1f); // Red with custom alpha

            // Draw the sphere.
            Gizmos.DrawSphere(prev_hand_pos, 2f);

            Gizmos.color = new Color(0f, 0f, 1f, 1f);
            Gizmos.DrawSphere(prev_head_pos.position, 0.3f);


            Gizmos.DrawLine(prev_head_pos.position + new Vector3(0, 0, head_width / 2), hand_pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Actualisation des positions
        head_pos = this.transform;
        heel_pos = prev_head_pos.position + new Vector3(0, 0, head_width / 2);
        hand_pos = heel_pos + new Vector3(0, this.length * math.cos(math.radians(90 - this.lie)), this.length * math.sin(math.radians(90 - this.lie)));
        //float distFlexpoint;

        //if (so_club.nbFlexPoint == 1)
        //{
        //    distFlexpoint = this.length / 4;
        //    flexPoints_pos[0] = heel_pos + new Vector3(0, distFlexpoint * math.cos(math.radians(90 - this.lie)), distFlexpoint * math.sin(math.radians(90 - this.lie)));

        //}
        //else if (so_club.nbFlexPoint >= 2)
        //{
        //    distFlexpoint = this.length / (so_club.nbFlexPoint + 1);
        //    for (int i = 0; i < so_club.nbFlexPoint; i++)
        //    {
        //        flexPoints_pos[i] = heel_pos + new Vector3(0, distFlexpoint * math.cos(math.radians(90 - this.lie)), distFlexpoint * math.sin(math.radians(90 - this.lie)));
        //        distFlexpoint += this.length / (so_club.nbFlexPoint + 1);
        //    }
        //}

        headObject.position = this.head_pos.position;
        headObject.rotation = Quaternion.Euler(0f, 0f, loft);
        headObject.localScale = new Vector3(headObject.localScale.x, this.head_height, this.head_width);

        //Calcul des forces
        computeFlexPointsForces();



        //Verif collision

        prev_head_pos = head_pos;
        // prev_flexPoints_pos = flexPoints_pos;
        prev_hand_pos = hand_pos;
    }


    void computeFlexPointsForces()
    {
        float alpha = this.stifness;
        float segmentLength = length / (this.flexPoints_pos.Length - 1);
        Vector3 gravity = new Vector3(0, -9.81f, 0);
        float dt = Time.fixedDeltaTime;

        for (int  i = this.flexPoints_pos.Length - 1; i >= 2;i--)
        {

            this.flexPoints_pos[i - 2] += gravity * dt;

            Vector3 BA = this.flexPoints_pos[i] - this.flexPoints_pos[i - 1];
            Vector3 BC = this.flexPoints_pos[i-1] - this.flexPoints_pos[i - 2];

            Vector3 BA_unit = BA.normalized;
            Vector3 BC_unit = BC.normalized;

            float cosTheta = Mathf.Clamp(Vector3.Dot(BA_unit, BC_unit), -1f, 1f);
            float theta = Mathf.Acos(cosTheta);

            Vector3 axis = Vector3.Cross(BA_unit,BC_unit);

            

            if (axis.magnitude >= 0.0001f)
            {
                Vector3 BC_aligned = Quaternion.AngleAxis(-theta * Mathf.Rad2Deg * alpha, axis.normalized) * BC;

                this.flexPoints_pos[i - 2] = this.flexPoints_pos[i - 1] - BC_aligned.normalized * segmentLength;
            }
        }


    }

    
}
