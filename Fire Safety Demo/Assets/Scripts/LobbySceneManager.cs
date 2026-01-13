using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySceneManager : MonoBehaviour
{
    public GameObject UICanvas;
    public SceneFader sceneFader;
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
    

    public void GoToRedRoom()
    {
        SceneSwitcher.Instance.LoadThisScene("FireSimV2");
        sceneFader.FadeOut();
    }

    public void GoToGreenRoom()
    {
        SceneSwitcher.Instance.LoadThisScene("GreenRoom");
        sceneFader.FadeOut();
    }
}
