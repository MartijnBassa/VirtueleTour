using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VideoTrackSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private VideoPlayerController _videoPlayerController;
    private Slider _slider;

    private bool _isSliding;

    private void Awake()
    {
        _videoPlayerController = GetComponentInParent<VideoPlayerController>();
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (!_isSliding && !_videoPlayerController.IsSeeking && _videoPlayerController.IsPlaying)
            _slider.SetValueWithoutNotify((float)_videoPlayerController.NTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isSliding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _videoPlayerController.Seek(_slider.value);
        _isSliding = false;
    }
}
