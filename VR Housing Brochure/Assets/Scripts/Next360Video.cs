using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next360Video : MonoBehaviour
{
    [SerializeField] private Material[] _skyBoxes;
    [SerializeField] private int _videoIndex = 0;

    [SerializeField] private GameObject[] _equirectangularVideoClips;

    // Set skybox to 360 video texture, activate object to play video
    public void NextVideo()
    {
        _videoIndex++;
        if (_videoIndex > _skyBoxes.Length - 1)
        {
            _videoIndex = 0;
        }

        RenderSettings.skybox = _skyBoxes[_videoIndex];

        // Deactivate every 360 video clip object
        for(int i = 0; i < _equirectangularVideoClips.Length; i++)
        {
            _equirectangularVideoClips[i].SetActive(false);
        }

        // Activate 360 video clip object with same index as skybox
        _equirectangularVideoClips[_videoIndex].SetActive(true);


    }
}
