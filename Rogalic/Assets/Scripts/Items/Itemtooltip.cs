using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Itemtooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title_text;
    [SerializeField] TextMeshProUGUI content_text;

    [SerializeField] Camera my_camera;
    [SerializeField] CanvasGroup my_group;

    private void Start()
    {
        my_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        my_group = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.back, my_camera.transform.rotation * Vector3.up);
    }

    public void Show()
    {
        my_group.alpha = 1;
    }

    public void Hide()
    {
        my_group.alpha = 0;
    }

    public void SetTitleText(string newTitleText)
    {

    }

    public void SetContentText(string newContentText)
    {

    }
}
