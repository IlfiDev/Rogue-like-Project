using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string tooltipTitle = "";
    [SerializeField] private string tooltipContent = "Some text";

    private IEnumerator wait = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        wait = Wait();
        StartCoroutine(wait);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine(wait);
        TooltipSystem.Hide();
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        TooltipSystem.Show(tooltipContent, tooltipTitle);
    }
}
