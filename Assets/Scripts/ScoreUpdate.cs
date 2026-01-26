using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{   
    private Text Points;
   private  void  Awake()
   {
        Points= GetComponent<Text>();
   }

    private void OnEnable()
    {
        UpdateScore.Update += ScreenPoints;
    }
    private void OnDisable()
    {
        UpdateScore.Update -= ScreenPoints;
    }
    private void ScreenPoints(int points)
    {
        Points.text =points.ToString();
    }

}
