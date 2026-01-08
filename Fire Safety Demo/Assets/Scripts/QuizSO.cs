using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz", menuName = "ScriptableObjects/QuizScriptableObject")]
public class QuizSO : ScriptableObject
{   
    [SerializeField]
   public List<QuestionAndOptions> quizList;

}

[System.Serializable]
public class QuestionAndOptions
{   
    [SerializeField]
  public  string question;
    [SerializeField]
   public List<string> options;
    [SerializeField]
    public int rightAns;
}