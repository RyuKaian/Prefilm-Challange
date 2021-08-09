using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public GameObject currentActive;
    public Image Animations;
    public Image LightControl;
    public TextMeshProUGUI XPosition;
    public TextMeshProUGUI YPosition;
    public TextMeshProUGUI ZPosition;
    public Slider RotationSlider;
    public Slider IntensitySlider;

    public void SetActiveGameObject(GameObject activeobj)
    {
        currentActive = activeobj;
        if (activeobj)
        {
            SetInitialRotation();
            if (activeobj.CompareTag("Character"))
            {
                Animations.gameObject.SetActive(true);
                LightControl.gameObject.SetActive(false);
            }
            else if (activeobj.CompareTag("Environment"))
            {
                SetInitialIntensity();
                Animations.gameObject.SetActive(false);
                LightControl.gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if(currentActive)
        {
            XPosition.text = "X: " + currentActive.transform.position.x.ToString("F2");
            YPosition.text = "Y: " + currentActive.transform.position.y.ToString("F2");
            ZPosition.text = "Z: " + currentActive.transform.position.z.ToString("F2");
        }
    }

    public void SetInitialRotation()
    {
        RotationSlider.value = currentActive.transform.localEulerAngles.y;
    }

    public void RotateObj(float rotation)
    {
        currentActive.transform.localEulerAngles = new Vector3(0, rotation, 0);
    }

    public void MoveObj()
    {
        Factory.MoveObject(currentActive);
    }

    public void DeleteObj()
    {
        Destroy(currentActive);
        TooltipSystem.Hide();
    }
    public void IdleAnim()
    {
        currentActive.GetComponent<CharacterAnimation>().Idle();
    }
    public void LaughingAnim()
    {
        currentActive.GetComponent<CharacterAnimation>().Laughing();
    }
    public void ToggleLight()
    {
        Light temp = currentActive.GetComponentInChildren<Light>();
        temp.enabled = !temp.enabled;
    }

    public void SetInitialIntensity()
    {
        IntensitySlider.value = currentActive.GetComponentInChildren<Light>().intensity;
    }
    public void SetIntensityObj(float intensity)
    {
        currentActive.GetComponentInChildren<Light>().enabled = true;
        currentActive.GetComponentInChildren<Light>().intensity = intensity;
    }
}
