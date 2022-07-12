using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headmove : MonoBehaviour
{
    [SerializeField] private float mouseSens = 1500f; 

    private Transform head_coordinates;

    private void Start()
    {
        head_coordinates = GameObject.Find("Head").transform;
    }

    void Update()
    {
        Lookatmouse();
    }
    void Lookatmouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            Quaternion targettotation = Quaternion.LookRotation(targetpoint - transform.position);
            head_coordinates.rotation = Quaternion.Slerp(transform.rotation, targettotation, mouseSens * Time.deltaTime);
            Physics.SyncTransforms();
        }
    }
}
