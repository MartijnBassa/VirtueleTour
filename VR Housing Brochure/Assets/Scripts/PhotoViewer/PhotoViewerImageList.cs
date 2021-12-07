using UnityEngine.UI;
using UnityEngine;

public class PhotoViewerImageList : MonoBehaviour
{

    [SerializeField] private Texture[] _images;
    [SerializeField] private PhotoViewer _photoViewer;

    private Button btn;

    // click photo viewer button
    // access gameObject
    // get list from script on gameObject
    // set list in PhotoViewerImageHolder as currentImages

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetPhotoViewerList);
    }

    private void SetPhotoViewerList()
    {
        _photoViewer.Images = _images;
    }
}
