using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class view : MonoBehaviour
{
    [SerializeField] GameObject[] rows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateView(Cell[,]grid)
    {
        for (int i = 0; i < 6; i++) 
        {
            for (int j = 0; j < 5; j++)
            {
                Cell c = grid[i,j];
                rows[i].transform.GetChild(j).GetComponent<Image>().color = c.color;
                rows[i].transform.GetChild(j).GetComponent<TMP_Text>().text = c.letter.ToString();
            }
        }
    }
}
