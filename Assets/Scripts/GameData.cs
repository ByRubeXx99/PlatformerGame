using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
public static int TotalScore = 0;
    public TextMeshProUGUI FinalText; 
    void Start()
    {
        if (FinalText != null)
        {
            FinalText.text = "Puntuación Final: " + TotalScore;
        }
    }
    public static void RestartPoints()
    {
        TotalScore = 0;
    }
}
