using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform player;
    private Transform camera;

    private float distanceFromMouse;
    private float distanceFromPlayer;

    private bool moveSwitcher = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = gameObject.GetComponentInChildren<Camera>().GetComponent<Transform>();
        camera.LookAt(player);
    }

    private void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, player.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            distanceFromMouse = Vector3.Distance(player.position, targetpoint);
            //try
            //{
            //    if (Vector3.Distance(camera.position, transform.position) < 35f)
            //    {
            //        camera.position = Vector3.Lerp(camera.position, targetpoint, Time.deltaTime * 7f);
            //    }
            //    else
            //    {

            //    }
            //}
            //catch { }
        }
        distanceFromPlayer = Vector3.Distance(transform.position, player.position);
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * 7f);
    }
}
