using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string goToLevel;
    public GameObject screenFadeThing;

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == Globals.playerObject)
        {
            if (screenFadeThing)
                StartCoroutine(Fade());
            else
                SceneManager.LoadScene(goToLevel);//Fix level 2 which we didn't make a screenFadeThing for.
        }
    }

    //Coroutine
    //Just a function that happens OVER TIME automatically
    //Almost always has a loop and use yield inside that loop.
   IEnumerator Fade()
   { 
        SpriteRenderer sr = screenFadeThing.GetComponent<SpriteRenderer>();
        while (sr.color.a < 1)
        {
            sr.color = new Color(0, 0, 0, sr.color.a + .01f);
            yield return new WaitForEndOfFrame(); 
        }
        SceneManager.LoadScene(goToLevel);
    }
}
