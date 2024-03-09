using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controller : MonoBehaviour
{
    [SerializeField] TMP_InputField input;

    model model;
    view view;
    
    // Start is called before the first frame update
    void Start()
    {
        model = FindObjectOfType<model>();
        view = FindObjectOfType<view>();
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameSetup()
    {
        model.setup();
    }

    public void SubmitGuess()
    {
        string guess = input.text;
        if (guess.Length!=5)
        {
            return;
        }
        if (model.isAllowed(guess))
        {
            return;
        }

        model.ApplyGuessToRow(guess);
        view.UpdateView(model.cells);

        input.text = "";
    }
}
