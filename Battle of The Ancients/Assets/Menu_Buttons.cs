using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Buttons : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject LevelSelectPanel;
    // Start is called before the first frame update
   void Start()
    {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLevelPanel()
    {
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

