using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Linq;
using System;



[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
[RequireComponent(typeof(XRGeneralGrabTransformer))]
//[RequireComponent(typeof(BoxCollider))]
public class Grabable : MonoBehaviour
{
    //[SerializeField]
    //private BoxCollider col;

    private string[] specialCase = new string[]
    {
        //"ray_store_bakery",
        "ray_store_beef_001",
        //"ray_store_beef_002",
        //"ray_store_dairy",
        //"ray_store_dairy (1)",
        //"ray_store_fish",
        //"ray_store_fish (1)",
        //"ray_store_fish_fence",
        //"ray_store_fish_fence (1)",
        "ray_store_flower",
        "ray_store_flower (1)",
        //"ray_store_fridge",
        //"ray_store_fridge_door_L",
        //"ray_store_fridge_door_R",
        //"ray_store_frozen (1)",
        //"ray_store_frozen_door_01",
        //"ray_store_frozen_door_02",
        //"ray_store_frozen_door_03",
        //"ray_store_frozen_door_04",
        "ray_store_fruits_001",
        "ray_store_fruits_001 (1)",
        "ray_store_fruits_002",
        "ray_store_fruits_002 (1)",
        "ray_store_fruits_003",
        "ray_store_fruits_003 (1)",
    };

    [SerializeField]
    private LODGroup lodGroup;
    private LOD[] lod;
    // Start is called before the first frame update
    void Awake()
    {
      //  bool speCase = true;
      //  //col = this.GetComponent<BoxCollider>();
      //  //Debug.Log(this.gameObject.name);
      //if(specialCase.Contains(this.gameObject.transform.parent.name))
      //{
            
      //      foreach (Transform child2 in this.transform)
      //      {
      //          if ((this.gameObject.transform.childCount > 0) && (speCase))
      //          {
      //              lodGroup = child2.GetComponent<LODGroup>();
      //              lod = lodGroup.GetLODs();
      //              BoxCollider bc = (lodGroup != null) ? lod[0].renderers[0].gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider : child2.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
      //              child2.gameObject.isStatic = false;
      //              foreach (Transform child3 in child2.transform)
      //              {
      //                  child3.gameObject.isStatic = false;
      //              }
      //              XRGrabInteractable ig = child2.GetComponent<XRGrabInteractable>();
      //              ig.colliders.Add(bc);
      //          }
      //          else
      //          {
      //              BoxCollider bc = child2.transform.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
      //              child2.gameObject.isStatic = false;
      //              foreach (Transform child3 in child2.transform)
      //              {
      //                  child3.gameObject.isStatic = false;
      //              }
      //              XRGrabInteractable ig = child2.GetComponent<XRGrabInteractable>();
      //              ig.colliders.Add(bc);
      //              //Debug.Log("2:"+this.gameObject.transform.name);
      //          }
      //      }

            
      //      speCase = false;

      //      Debug.Log("1");
      //  }
      if ((this.gameObject.transform.childCount > 0 ))
      {
            Collider bc;
            lodGroup = this.GetComponent<LODGroup>();
            lod = lodGroup.GetLODs();
            Debug.Log("2");
            if (this.gameObject.layer == 6) { bc = (lodGroup != null) ? lod[0].renderers[0].gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider : transform.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider; ((MeshCollider)bc).convex = true; }
            else { bc = (lodGroup != null) ? lod[0].renderers[0].gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider : transform.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider; }
            gameObject.isStatic = false;
            foreach (Transform child in transform)
            {
                child.gameObject.isStatic = false;
            }
            XRGrabInteractable ig = this.GetComponent<XRGrabInteractable>();
            ig.colliders.Add(bc);
            //Debug.Log("1:"+this.gameObject.transform.name);
        }
      else
      {
            BoxCollider bc = transform.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
            gameObject.isStatic = false;
            foreach (Transform child in transform)
            {
                child.gameObject.isStatic = false;
            }
            XRGrabInteractable ig = this.GetComponent<XRGrabInteractable>();
            ig.colliders.Add(bc);
            //Debug.Log("2:"+this.gameObject.transform.name);
       }
      
       
        

      // Debug.Log(lod[0].renderers[0].transform.localEulerAngles);
      // Vector3 lod0Rot = lod[0].renderers[0].transform.localEulerAngles;
      // Vector3 oldRot = transform.localEulerAngles;
      // lod[0].renderers[0].transform.localEulerAngles =new Vector3(0,0,0);
      // transform.localEulerAngles = new Vector3(0,0,0);



      //Bounds bounds = lod[0].renderers[0].GetComponent<MeshFilter>().mesh.bounds;
      //col.size = new Vector3(bounds.size.x, bounds.size.y,bounds.size.z);
      //col.center = new Vector3( bounds.center.x, bounds.center.y,bounds.center.z);
      // lod[0].renderers[0].transform.localEulerAngles = lod0Rot;
      // transform.localEulerAngles = oldRot;
      // Debug.Log(lod[0].renderers[0].transform+":"+lod0Rot);
    }




    // void Awake()
    // {
    //   col = this.GetComponent<BoxCollider>();
    //   lodGroup = this.GetComponent<LODGroup>();
    //   lod =lodGroup.GetLODs();
    //
    //   Debug.Log(lod[0].renderers[0].transform.localEulerAngles);
    //   // Vector3 lod0Rot = new Vector3(lod[0].renderers[0].transform.localEulerAngles.x-360,lod[0].renderers[0].transform.localEulerAngles.y-360,lod[0].renderers[0].transform.localEulerAngles.z-360);
    //   // Vector3 oldRot = new Vector3(transform.localRotation.eulerAngles.x,transform.localRotation.eulerAngles.y,transform.localRotation.eulerAngles.z);
    //   // Debug.Log(lod[0].renderers[0].transform+":"+lod0Rot);
    //   // lod[0].renderers[0].transform.localEulerAngles = new Vector3(0,0,0);
    //   // transform.localEulerAngles = new Vector3(0,0,0);
    //   // Bounds bounds = lod[0].renderers[0].GetComponent<MeshFilter>().mesh.bounds;
    //   // col.size = new Vector3(bounds.size.x, bounds.size.y,bounds.size.z);
    //   // col.center = new Vector3( bounds.center.x, bounds.center.y,bounds.center.z);
    //   // lod[0].renderers[0].transform.localEulerAngles = lod0Rot;
    //   // transform.localEulerAngles = oldRot;
    //   // Debug.Log(lod[0].renderers[0].transform+":"+lod0Rot);
    // }


}
