using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        }
    }



    public void PlayButton()
  {
    SceneManager.LoadScene("Golfmania", LoadSceneMode.Single);
  }
    public void SoftButton()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void SettingsButton()
  {

  }

  public void QuitButton()
  {
    Application.Quit();
  }
}
