using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Camera my_camera;

    private Slider slider;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    private void Start() {
        my_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.back, my_camera.transform.rotation * Vector3.up); 
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
