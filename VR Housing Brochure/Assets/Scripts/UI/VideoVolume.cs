using UnityEngine;
using UnityEngine.UI;

public class VideoVolume : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Button _muteButton;
    [SerializeField] private Button _unmuteButton;

    private VideoPlayerController _videoPlayerController;

    private void Awake()
    {
        _videoPlayerController = GetComponentInParent<VideoPlayerController>();
    }

    private void Start()
    {
        _volumeSlider.SetValueWithoutNotify(_videoPlayerController.Volume);
        _muteButton.gameObject.SetActive(!_videoPlayerController.IsMuted);
        _unmuteButton.gameObject.SetActive(_videoPlayerController.IsMuted);
    }

    private void OnEnable()
    {
        _videoPlayerController.OnVolumeChanged.AddListener(OnVideoVolumeChanged);
        _videoPlayerController.OnMuteChanged.AddListener(OnVideoMuteChanged);

        _volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
        _muteButton.onClick.AddListener(OnMuteButtonClicked);
        _unmuteButton.onClick.AddListener(OnUnmuteButtonClicked);
    }

    private void OnDisable()
    {
        _videoPlayerController.OnVolumeChanged.RemoveListener(OnVideoVolumeChanged);
        _videoPlayerController.OnMuteChanged.RemoveListener(OnVideoMuteChanged);

        _volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderValueChanged);
        _muteButton.onClick.RemoveListener(OnMuteButtonClicked);
        _unmuteButton.onClick.RemoveListener(OnUnmuteButtonClicked);
    }

    private void OnVideoVolumeChanged(float volume)
    {
        _volumeSlider.SetValueWithoutNotify(volume);
    }

    private void OnVideoMuteChanged(bool isMuted)
    {
        _volumeSlider.SetValueWithoutNotify(isMuted ? 0 : _videoPlayerController.Volume);
        _muteButton.gameObject.SetActive(!isMuted);
        _unmuteButton.gameObject.SetActive(isMuted);
    }

    private void OnVolumeSliderValueChanged(float value)
    {
        _videoPlayerController.SetVolume(value);
        if (_videoPlayerController.IsMuted)
            _videoPlayerController.SetMute(false);
    }

    private void OnMuteButtonClicked()
    {
        _videoPlayerController.SetMute(true);
    }

    private void OnUnmuteButtonClicked()
    {
        _videoPlayerController.SetMute(false);
    }
}
