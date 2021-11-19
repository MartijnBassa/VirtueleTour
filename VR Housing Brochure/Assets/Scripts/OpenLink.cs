using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    [SerializeField] private string _link;

    public void OpenURL()
    {
        Application.OpenURL(_link);
    }
}
