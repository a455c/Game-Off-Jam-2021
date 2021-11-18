using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Text hiscoreText;


    // Start is called before the first frame update
    void Start()
    {
        hiscoreText.text = System.Convert.ToString(HiScore.hiScore);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
