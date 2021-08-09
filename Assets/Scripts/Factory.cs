using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject[] Models;
    public GameObject[] Lights;

    private GameObject currentObject;
    private bool holdingObject = false;

    public void CreateJames()
    {
        currentObject = Instantiate(Models[0], transform);
        holdingObject = true;
    }

    public void CreateMegan()
    {
        currentObject = Instantiate(Models[1], transform);
        holdingObject = true;
    }

    public void CreateLightbox()
    {
        currentObject = Instantiate(Lights[0], transform);
        holdingObject = true;
    }

    void Update()
    {
        if (!holdingObject)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                CreateJames();
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                CreateMegan();
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                CreateLightbox();
        } else
        {
            Plane plane = new Plane(Vector3.up, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
                currentObject.transform.position = ray.GetPoint(distance);

            if (Input.GetMouseButtonDown(0))
                holdingObject = false;

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                Destroy(currentObject);
                holdingObject = false;
            }
        }
    }
}
