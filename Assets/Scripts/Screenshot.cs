using UnityEngine;
using System.IO;


public class Screenshot : MonoBehaviour
{
    private string screenshot_root_folder;

    void Start()
    {
        screenshot_root_folder = string.Format("{0}/Prefilm Screenshots/",
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));
    }

    private string ScreenShotName()
    {
        return string.Format("Screenshot {0}.png", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void TakeScrenshot()
    {
        if (!Directory.Exists(screenshot_root_folder))
            Directory.CreateDirectory(screenshot_root_folder);

        string filename = screenshot_root_folder + ScreenShotName();
        ScreenCapture.CaptureScreenshot(filename);

        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown("k"))
            TakeScrenshot();
    }
}
