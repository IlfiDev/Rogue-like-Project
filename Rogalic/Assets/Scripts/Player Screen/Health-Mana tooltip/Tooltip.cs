using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title_text;
    [SerializeField] private TextMeshProUGUI content_text;
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private int max_characters = 10;

    private RectTransform rectTransform;
    private LayoutElement layoutElement;

    private bool makeFadeAnimationIn = false;
    private bool makeFadeAnimationOut = false;
    private bool changeToolTipPosition = false;

    private void Start()
    {
        layoutElement = GetComponent<LayoutElement>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string newContentText, string newTitleText = "")
    {
        if(string.IsNullOrEmpty(newTitleText))
        {
            title_text.gameObject.SetActive(false);
        } else
        {
            title_text.gameObject.SetActive(true);
            title_text.text = newTitleText;
        }

        content_text.gameObject.SetActive(true);
        content_text.text = newContentText;

        int title_length = title_text.text.Length;

        int content_length = content_text.text.Length;

        if (title_length > max_characters || content_length > max_characters)
        {
            layoutElement.enabled = true;
        }
        else
        {
            layoutElement.enabled = false;
        }
    }

    public void FadeAnimationIn()
    {
        canvasGroup.alpha = 0;
        makeFadeAnimationIn = true;
        changeToolTipPosition = true;
    }

    public void FadeAnimationOut()
    {
        makeFadeAnimationIn = false;
        makeFadeAnimationOut = true;
        changeToolTipPosition = false;
        
    }

    private void Update()
    {
        if(changeToolTipPosition)
        {
            Vector2 mousePosition = Input.mousePosition;
            transform.position = mousePosition;

            float pivotX = mousePosition.x / Screen.width;
            float pivotY = mousePosition.y / Screen.height;

            rectTransform.pivot = new Vector2(pivotX, pivotY);
        }

        if(makeFadeAnimationIn && canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 5;
            if(canvasGroup.alpha >= 1)
            {
                makeFadeAnimationIn = false;
            }
        }


        if(makeFadeAnimationOut && canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 5;
            if(canvasGroup.alpha <= 0)
            {
                makeFadeAnimationOut = false;
            }
        }


    }

}
