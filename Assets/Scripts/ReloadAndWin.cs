using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadAndWin : MonoBehaviour
{
    public static ReloadAndWin instance;

    public GameObject winObject;

    private void Awake()
    {
        instance = this;

        winObject.SetActive(false);
    }

    public void Win()
    {
        winObject.SetActive(true);
    }
    public void Button_Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
