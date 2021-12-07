using System;
using TMPro;
using UnityEngine;

public class VideoTimer : MonoBehaviour
{
    private VideoPlayerController _videoPlayerController;
    private TMP_Text _timerText;

    private void Awake()
    {
        _videoPlayerController = GetComponentInParent<VideoPlayerController>();
        _timerText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        _timerText.text = _videoPlayerController.IsPrepared
            ? $"{GetTimerText(_videoPlayerController.Time)} / {GetTimerText(_videoPlayerController.Duration)}"
            : "0:00 / 0:00";
    }

    private string GetTimerText(double timeInSeconds)
    {
        double minutes = Math.Floor(timeInSeconds / 60);
        double seconds = Math.Floor(timeInSeconds % 60);
        return $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }
}
