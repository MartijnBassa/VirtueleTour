using UnityEngine;
using UnityEngine.UI;

public class VideoPlayPauseButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _pauseButton;

    private VideoPlayerController _videoPlayerController;

    private void Awake()
    {
        _videoPlayerController = GetComponentInParent<VideoPlayerController>();
    }

    private void OnEnable()
    {
        _videoPlayerController.OnPlayed.AddListener(OnVideoPlayed);
        _videoPlayerController.OnPaused.AddListener(OnVideoPaused);

        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);

        _playButton.gameObject.SetActive(!_videoPlayerController.IsPlaying);
        _pauseButton.gameObject.SetActive(_videoPlayerController.IsPlaying);
    }

    private void OnDisable()
    {
        _videoPlayerController.OnPlayed.RemoveListener(OnVideoPlayed);
        _videoPlayerController.OnPaused.RemoveListener(OnVideoPaused);

        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
    }

    private void OnVideoPlayed()
    {
        _playButton.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
    }

    private void OnVideoPaused()
    {
        _playButton.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
    }

    private void OnPlayButtonClicked()
    {
        _videoPlayerController.PlayVideo();
    }

    private void OnPauseButtonClicked()
    {
        _videoPlayerController.PauseVideo();
    }
}
