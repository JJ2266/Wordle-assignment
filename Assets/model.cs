using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model : MonoBehaviour
{
    public int currentAttempt;
    public Cell[,] cells;
    [SerializeField] TextAsset possibleAnswersAsset;
    [SerializeField] TextAsset allowedWordsAsset;

    public string answer;
    string[] possibleAnswers;
    string[] allowedWords;

    public void setup()
    {
        cells = new Cell[6, 5];
        for(int i = 0; i < 6;i++)
        {
            for (int j = 0; j < 5;j++)
            {
                cells[i, j] = new Cell();
            }
        }
        possibleAnswers = possibleAnswersAsset.text.Split("/n");
        allowedWords = allowedWordsAsset.text.Split("/n");

        answer = possibleAnswers[Random.Range(0,possibleAnswers.Length)];
    }

    public void ApplyGuessToRow(string guess)
    {
        for(int i = 0;i < 5;i++)
        {
            char letter = guess[i];

            cells[currentAttempt, i].letter = letter;

            if (answer[i]==letter)
            {
                cells[currentAttempt, i].color = Color.green;
            }
            else if (answer.Contains(letter))
            {
                cells[currentAttempt, i].color = Color.yellow;
            }
            else 
            {
                cells[currentAttempt, i].color = Color.gray;
            }

        }
        currentAttempt++;
    }

    public bool isAllowed(string guess)
    {
        foreach(string s in possibleAnswers) 
        {
            if (s.Trim() == guess.Trim())
                return true;
        }
        foreach (string s in allowedWords)
        {
            if (s.Trim() == guess.Trim())
                return true;
        }
        return false;
    }
}
