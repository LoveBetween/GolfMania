using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{







  public void PlayButton()
  {
    SceneManager.LoadScene("Golfmania", LoadSceneMode.Single);
  }
  public void SettingsButton()
  {

  }

  public void QuitButton()
  {
    Application.Quit();
  }
}
