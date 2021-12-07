using UnityEngine.UI;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] private string _videoUrl;

    private Button _button;

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(SetVideoUrl);
    }

    private void SetVideoUrl()
    {
        VideoPlayerController.Get.gameObject.SetActive(true);
        VideoPlayerController.Get.LoadVideoFromFile(_videoUrl);
    }
}
