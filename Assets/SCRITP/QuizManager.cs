using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] TMP_Text questionText;
    [SerializeField] TMP_Text[] answerTexts;
    [SerializeField] Button[] answerButtons;
    [SerializeField] float secondsBetweenQuestions;
    [SerializeField] Questions[] questions;
    [SerializeField] TMP_Text score ;
    [SerializeField] int score0 ;

    private int counter;

    private void Start()
    {
            int j=1,i; 
            questions = RandomizeArray(questions,ref j);
            foreach (Questions question in questions)
            {
                question.answers = RandomizeArray(question.answers,ref question.correctAnswers);
            }
            counter = 0;
            AssignToUI(questions[counter]);

                ///  Button btn = ba.GetComponent<Button>();
                 
                 
                   /////print(answerButtons.Length);
             /*  for (i = 0; i <answerButtons.Length; i++)
                {

                    answerButtons[i].onClick.AddListener(() => ButtonClicked(i));

                } /////error en la Matrix
              */



        answerButtons[0].onClick.AddListener(() => ButtonClicked(0));
        answerButtons[1].onClick.AddListener(() => ButtonClicked(1));
        answerButtons[2].onClick.AddListener(() => ButtonClicked(2));
        answerButtons[3].onClick.AddListener(() => ButtonClicked(3));
        
        score0 = 0 ;
        score.SetText("0");

    }
  
    private void AssignToUI(Questions question)
    {
        questionText.text = question.question;
        for (int i = 0; i < question.answers.Length; i++)
        {
            answerTexts[i].text = question.answers[i];
            
        }
    }

    private T[] RandomizeArray<T>(T[] array,ref int nrc)
    {
        for (int i = 0; i < array.Length; i++)
        {
            T tmp = array[i];
            int r = UnityEngine.Random.Range(i, array.Length);
            if (r == nrc) nrc = i;
            else if (i == nrc) nrc = r;
            array[i] = array[r];
            array[r] = tmp;
        }
        return array;
    }

    public void EvaluateQuestion(int index)
    {
       
        if (questions[counter].correctAnswers==index)
        {
            score0++;
           
            
            
            score.SetText(score0.ToString());
        }

        StartCoroutine(ShowAnswersRoutine(secondsBetweenQuestions));
    }

    private IEnumerator ShowAnswersRoutine(float seconds)
    {
        for (int i = 0; i < questions[counter].answers.Length; i++)
        {
            answerButtons[i].interactable = false;
            if(i== questions[counter].correctAnswers)////         if (questions[counter].answers[i].isRight)
            {
                answerButtons[i].image.color = Color.green;
            }
            else
            {
                answerButtons[i].image.color = Color.red;
            }
        }
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < questions[counter].answers.Length; i++)
        {
            answerButtons[i].interactable = true;
            answerButtons[i].image.color = Color.clear;
        }
        counter++;
        if (counter >= questions.Length)
        {
            if (score0 == questions.Length)
                //Change to Game Over.

                SceneManager.LoadScene("ganaste");

            else { SceneManager.LoadScene("perdiste"); }
      
        }
        else
        {
            AssignToUI(questions[counter]);
        }
    }


   /* void TaskOnClick(int i)
    {
        EvaluateQuestion(0);

    }*/

    void ButtonClicked(int indx)
    {
        EvaluateQuestion(indx);
    }
}


