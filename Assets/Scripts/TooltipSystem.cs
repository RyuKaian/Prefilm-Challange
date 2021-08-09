using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;
    public Tooltip tooltip;
    public static bool selected;
    public static bool hovering_something_withtooltip;

    private void Awake()
    {
        current = this;
    }

    public static bool IsActive()
    {
        return current.tooltip.gameObject.activeSelf;
    }

    public static void ShowSelected(GameObject obj)
    {
        selected = true;
        Show(obj);
    }

    public static void Show(GameObject obj)
    {
        current.tooltip.SetActiveGameObject(obj);
        current.tooltip.gameObject.SetActive(true);
    }
    
    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
        current.tooltip.SetActiveGameObject(null);
    }


}
