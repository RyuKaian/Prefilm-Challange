using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject[] Models;
    public GameObject[] Lights;

    private static GameObject currentObject;
    private static bool holdingObject = false;

    public void CreateJames()
    {
        currentObject = Instantiate(Models[0], transform);
        TooltipSystem.ShowSelected(currentObject);
        holdingObject = true;
    }

    public void CreateMegan()
    {
        currentObject = Instantiate(Models[1], transform);
        TooltipSystem.ShowSelected(currentObject);
        holdingObject = true;
    }

    public void CreateLightbox()
    {
        currentObject = Instantiate(Lights[0], transform);
        TooltipSystem.ShowSelected(currentObject);
        holdingObject = true;
    }

    public static void MoveObject(GameObject obj)
    {
        currentObject = obj;
        holdingObject = true;
    }

    void Update()
    {
        if (!holdingObject)
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //    CreateJames();
            //else if (Input.GetKeyDown(KeyCode.Alpha2))
            //    CreateMegan();
            //else if (Input.GetKeyDown(KeyCode.Alpha3))
            //    CreateLightbox();
        } else
        {
            Plane plane = new Plane(Vector3.up, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 temp = ray.GetPoint(distance);
                temp.x = Mathf.Clamp(temp.x, -10, 10);
                temp.z = Mathf.Clamp(temp.z, -10, 10);
                currentObject.transform.position = temp;
            }

            if (Input.GetMouseButtonDown(0))
            {
                holdingObject = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                Destroy(currentObject);
                TooltipSystem.Hide();
                holdingObject = false;
            }
        }
    }
}
