using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform player;
    private Transform camera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = gameObject.GetComponentInChildren<Camera>().GetComponent<Transform>();
        camera.LookAt(player);
    }

    private void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            if (Vector3.Distance(player.position, targetpoint) < 5f)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetpoint, 5f * Time.deltaTime);
            }
            else
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,Vector3.MoveTowards(player.position, targetpoint, 3f), 5f * Time.deltaTime);
            }
        }
    }
}
