using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuizManager : MonoBehaviour
{
    public List<Toggle> toggleOptions;
    public TextMeshProUGUI questionHolder;
    public TextMeshProUGUI[] optionsHolder;
    public GameObject scoreUI;
    public TextMeshProUGUI scoreText;

    public QuizSO quizSO;
    int rightOptionID;

    int score = 0, QID = 0;
    private void Start()
    {
        AssignQuestionFromSO(QID);
       
    }
    public void AssignQuestionFromSO(int qID)
    {
        questionHolder.text = quizSO.quizList[qID].question;
        
        for(int i=0;i<4;i++)
        {
            optionsHolder[i].text = quizSO.quizList[qID].options[i];
        }

        rightOptionID = quizSO.quizList[qID].rightAns;
        
    }

   
    public Toggle selectedToggle, correctToggle;
    Animator RightAnimator, WrongAnimator;
    public IEnumerator ValidateAnswer()
    {
        foreach (var toggle in toggleOptions)
        {
            if (toggle.name == rightOptionID.ToString())
                correctToggle = toggle;

            if (toggle.isOn)
            {
                selectedToggle = toggle;
            }
        }

        selectedToggle.isOn = false;

        
        RightAnimator = correctToggle.GetComponent<Animator>();
        RightAnimator.Play("RightAnswer");

        if (selectedToggle == correctToggle)
        {
            score++;
        }
        else
        {
            WrongAnimator = selectedToggle.GetComponent<Animator>();
            WrongAnimator.Play("WrongAnswer");
        }

        QID++;
        yield return new WaitForSeconds(4);
        if (RightAnimator != null)
            RightAnimator.Play("Normal");
        if (WrongAnimator != null)
            WrongAnimator.Play("Normal");

        if (QID < 5)
            AssignQuestionFromSO(QID);
        else
            ShowFinalScore();

    }

    public void onClickedNext()
    {   
         StartCoroutine(ValidateAnswer());
    }

    void ShowFinalScore()
    {
        scoreUI.SetActive(true);
        scoreText.text = score + "/5"; 
    }

}
