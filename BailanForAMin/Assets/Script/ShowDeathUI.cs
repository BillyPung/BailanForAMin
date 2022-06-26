using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDeathUI : MonoBehaviour
{
    public Image img;
    public float time;
    public Color deathColor;
    public Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void showDeathUI()
    {
        StartCoroutine(show());
    }

    IEnumerator show()
    {
        img.color = deathColor;
        Time.timeScale = 0;
        pauseGame();
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
       Time.timeScale = 1;
    }
    public void pauseGame()
    {
        StartCoroutine(GamePauser());
    }
    public IEnumerator GamePauser(){
        Debug.Log ("Inside PauseGame()");
        yield return new WaitForSeconds (3);
        Debug.Log("Done with my pause");
    }
}
