using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour
{

    public void OnMouseEnter()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && !TooltipSystem.IsActive())
            TooltipSystem.Show(gameObject);
    }
    public void OnMouseOver()
    {
        if (!TooltipSystem.IsActive() && Input.GetKey(KeyCode.LeftAlt))
            TooltipSystem.Show(gameObject);
    }

    public void OnMouseExit()
    {
        if(!TooltipSystem.selected)
            TooltipSystem.Hide();
    }

    private void Update()
    {
        if (!TooltipSystem.selected && Input.GetKeyUp(KeyCode.LeftAlt))
            TooltipSystem.Hide();

        if(TooltipSystem.selected && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)))
        {
            TooltipSystem.selected = false;
            TooltipSystem.Hide();
        }
        if (TooltipSystem.IsActive() && Input.GetMouseButtonDown(0))
            TooltipSystem.selected = true;
    }
}
