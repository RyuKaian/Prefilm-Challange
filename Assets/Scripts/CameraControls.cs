using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraControls : MonoBehaviour
{
    public TMP_InputField FocalLength;
    public TMP_InputField SensorSizeX;
    public TMP_InputField SensorSizeY;

    public void Awake()
    {
        FocalLength.text = Camera.main.focalLength + "";
        SensorSizeX.text = Camera.main.sensorSize.x + "";
        SensorSizeY.text = Camera.main.sensorSize.y + "";
    }
    public void SetFocalLengthObj(string focalLength)
    {
        Camera.main.focalLength = float.Parse(focalLength);
    }
    public void SetSensorSizeX(string x)
    {
        Camera.main.sensorSize.Set(float.Parse(x), Camera.main.sensorSize.y);
    }
    public void SetSensorSizeY(string y)
    {
        Camera.main.sensorSize.Set(Camera.main.sensorSize.x, float.Parse(y));
    }
}
