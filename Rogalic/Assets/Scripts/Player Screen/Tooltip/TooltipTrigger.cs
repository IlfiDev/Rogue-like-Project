using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string tooltipTitle = "";
    [SerializeField] private string tooltipContent = "Some text";

    private IEnumerator wait = null;

    private bool pointerIsEnter = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        wait = Wait();
        StartCoroutine(wait);

        pointerIsEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine(wait);
        TooltipSystem.Hide();

        pointerIsEnter = false;
    }

    private void Update()
    {
        if(pointerIsEnter)
        {
            TooltipSystem.SetTextTooltip(tooltipContent, tooltipTitle);
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        TooltipSystem.Show(tooltipContent, tooltipTitle);
    }

    public void SetText(string content_text, string title_text = "")
    {
        tooltipContent = content_text;
        tooltipTitle = title_text;
    }
}
