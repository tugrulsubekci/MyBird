using UnityEngine;
using TMPro;

public class FramePerSecond : MonoBehaviour
{
    public TextMeshProUGUI fpsTxt;

    float pollingTime = 1f;
    float time;
    int frameCount;

    void Update()
    {
        time += Time.deltaTime;
        frameCount++;
        if (time > pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsTxt.text = $"FPS: {frameRate}";
            time -= pollingTime;
            frameCount = 0;
        }
    }
}