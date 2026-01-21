using UnityEngine;

public class GameFinished : MonoBehaviour
{

    public GameObject golfBall;
    public GameObject winMenu;

    public bool isGameFinished;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cacher le canva de fin de niveau
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //si la boule touche le trou, afficher le canva de fin de niveau
        if (Vector3.Distance(golfBall.transform.position, transform.position) < 0.5f)
        {
            winMenu.SetActive(true);
        }
    }

    public void ReplayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
