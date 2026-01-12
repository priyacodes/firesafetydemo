using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidManager : MonoBehaviour
{
    public List<GameObject> safetySets;

    public GameObject SafetyCanvas, QuizCanvas;

    int id = 0;
    public void Next()
    {
        safetySets[id].SetActive(false);
        id++;
        safetySets[id].SetActive(true);
      
    }

    public void Prev()
    {
        safetySets[id].SetActive(false);
        id--;
        safetySets[id].SetActive(true);
    }

    public void ShowQuizPanel()
    {
        SafetyCanvas.SetActive(false);
        QuizCanvas.SetActive(true);
    }
}

