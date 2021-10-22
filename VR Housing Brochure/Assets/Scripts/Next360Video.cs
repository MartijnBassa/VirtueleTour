using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next360Video : MonoBehaviour
{
    [SerializeField] private Material[] _skyBoxes;

    [SerializeField] private int _videoIndex = 0;

    public void NextVideo()
    {
        _videoIndex++;
        if (_videoIndex > _skyBoxes.Length - 1)
        {
            _videoIndex = 0;
        }

        RenderSettings.skybox = _skyBoxes[_videoIndex];

    }
}
