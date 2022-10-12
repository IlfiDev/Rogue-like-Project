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

    private bool fadeIn = false;
    private Coroutine coroutine = null;

    private void Awake()
    {
        my_group = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        my_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.back, my_camera.transform.rotation * Vector3.up);
    }

    public void ShowAnim()
    {
        if (my_group.alpha == 1) return;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        fadeIn = true;
        coroutine = StartCoroutine(FadeAnim());
    }

    public void Show()
    {
        if (my_group.alpha == 1) return;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = null;

        my_group.alpha = 1;
    }

    public void HideAnim()
    {
        if (my_group.alpha == 0) return;


        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        fadeIn = false;
        coroutine = StartCoroutine(FadeAnim());
    }

    public void Hide()
    {
        if (my_group.alpha == 0) return;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = null;

        my_group.alpha = 0;
    }

    IEnumerator FadeAnim()
    {
        if(fadeIn)
        {

            for(float i = 0; i <= 0.25f; i += Time.deltaTime)
            {
                my_group.alpha = i;

                yield return null;
            }
            my_group.alpha = 1;

        } else
        {

            for(float i = 0.25f; i >= 0; i -= Time.deltaTime)
            {
                my_group.alpha = i;
                
                yield return null;
            }
            my_group.alpha = 0;

        }
    }

    public void SetTitleText(string newTitleText)
    {
        title_text.text = newTitleText;
    }

    public void SetContentText(string newContentText)
    {
        content_text.text = newContentText;
    }
}
