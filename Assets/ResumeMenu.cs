using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeMenu : MonoBehaviour
{
    public GameObject resumeMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && resumeMenu.activeSelf)
        {
            resumeMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !resumeMenu.activeSelf)
        {
            resumeMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        resumeMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
}
