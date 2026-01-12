using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySceneManager : MonoBehaviour
{
    public GameObject UICanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneSwitcher.Instance.successfulEvacuation)
            UICanvas.SetActive(true);
    }

    public void SetBoolEvacuation(bool val)
    {
        SceneSwitcher.Instance.successfulEvacuation = val;
    }
 
}
