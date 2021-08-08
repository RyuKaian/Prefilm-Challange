using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public GameObject[] Models;

    private GameObject current;
    private bool holding_character = false;

    public void CreateJames()
    {
        current = Instantiate(Models[0]);
        holding_character = true;
    }

    public void CreateMegan()
    {
        current = Instantiate(Models[1]);
        holding_character = true;
    }


    void Update()
    {
        if (!holding_character)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                CreateJames();
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                CreateMegan();

        } else
        {
            Plane plane = new Plane(Vector3.up, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
                current.transform.position = ray.GetPoint(distance);

            if (Input.GetMouseButtonDown(0))
                holding_character = false;

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                Destroy(current);
                holding_character = false;
            }
        }
    }
}
