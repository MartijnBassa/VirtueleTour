using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerController : Singleton<VideoPlayerController>
{
    [SerializeField] RawImage _rawImage;

    public UnityEvent OnPrepared;

    public UnityEvent OnPlayed;
    public UnityEvent OnPaused;
    public UnityEvent OnRestarted;
    public UnityEvent OnStopped;

    public UnityEvent<float> OnVolumeChanged;
    public UnityEvent<bool> OnMuteChanged;

    private VideoPlayer _videoPlayer;
    private RenderTexture _videoRT;

    public bool IsPlaying => _videoPlayer.isPlaying;
    public bool IsLooping => _videoPlayer.isLooping;
    public bool IsPrepared => _videoPlayer.isPrepared;
    public double Time => _videoPlayer.time;
    public double NTime => Time / Duration;
    public ulong Duration => (ulong)(_videoPlayer.frameCount / _videoPlayer.frameRate);
    public float Volume => IsPrepared ? _videoPlayer.GetDirectAudioVolume(0) : 1f;
    public bool IsMuted => IsPrepared ? _videoPlayer.GetDirectAudioMute(0) : false;

    public bool IsSeeking { get; private set; }

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        
        IsSeeking = false;

    }

    private void OnEnable()
    {
        _videoPlayer.prepareCompleted += PrepareCompleted;
        _videoPlayer.seekCompleted += SeekCompleted;
    }

    private void OnDisable()
    {
        _videoPlayer.prepareCompleted -= PrepareCompleted;
        _videoPlayer.seekCompleted -= SeekCompleted;
    }

    public void LoadVideoFromFile(string path)
    {
        _videoPlayer.url = path;
        _videoPlayer.Prepare();
    }

    public void PlayVideo()
    {
        if (!IsPrepared)
            return;

        _videoPlayer.Play();
        OnPlayed?.Invoke();
    }

    public void PauseVideo()
    {
        if (!IsPrepared && !IsPlaying)
            return;

        _videoPlayer.Pause();
        OnPaused?.Invoke();
    }

    public void StopVideo()
    {
        if (!IsPrepared && !IsPlaying)
            return;

        _videoPlayer.Stop();
        OnStopped?.Invoke();
    }

    public void RestartVideo()
    {
        if (!IsPrepared)
            return;

        PauseVideo();
        OnRestarted?.Invoke();
    }

    public void Seek(float nTime)
    {
        if (!IsPrepared)
            return;

        IsSeeking = true;

        nTime = Mathf.Clamp(nTime, 0, 1);
        _videoPlayer.time = nTime * Duration;
    }

    public void SetVolume(float volume)
    {
        _videoPlayer.SetDirectAudioVolume(0, volume);
        OnVolumeChanged?.Invoke(volume);
    }

    public void SetMute(bool mute)
    {
        _videoPlayer.SetDirectAudioMute(0, mute);
        OnMuteChanged?.Invoke(mute);
    }

    public void Clear()
    {
        if (_videoRT != null)
        {
            _videoRT.Release();
            Destroy(_videoRT);
            _videoRT = null;
            _videoPlayer.targetTexture = null;
        }
    }

    private void PrepareCompleted(VideoPlayer source)
    {
        _videoRT = new RenderTexture((int)_videoPlayer.width, (int)_videoPlayer.height, 0, RenderTextureFormat.ARGB32, 0);
        _videoPlayer.targetTexture = _videoRT;
        _rawImage.texture = _videoRT;

        OnVolumeChanged?.Invoke(Volume);
        OnMuteChanged?.Invoke(IsMuted);

        OnPrepared?.Invoke();

        PlayVideo();
    }

    private void SeekCompleted(VideoPlayer source)
    {
        IsSeeking = false;
    }
}
