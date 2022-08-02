using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;

    [SerializeField] public Tooltip tooltip;

    private void Start()
    {
        current = this;
    }

    public static void Show(string newContentText, string newTitleText = "")
    {
        current.tooltip.SetText(newContentText, newTitleText);
        current.tooltip.FadeAnimationIn();
    }

    public static void Hide()
    {
        current.tooltip.FadeAnimationOut();
    }
}
