using UnityEngine;
using UnityEngine.UI;//************************************

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;

    private int score = 0;

    public void ChangeScore(int changeInPoints)
    {
        score += changeInPoints;
        if (scoreText)
            scoreText.text = "Score: " + score.ToString();
    }
}
