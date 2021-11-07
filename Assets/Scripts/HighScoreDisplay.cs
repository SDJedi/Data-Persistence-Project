using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI BestScore_Txt;

    void Start()
    {
        BestScore_Txt.text = "Best Score:" + PersistentData.Instance.GetHighScoreFromFile().ToString() + "\n" + " Name: " + PersistentData.Instance.GetNameFromFile();
    }
}
