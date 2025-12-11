using UnityEngine;

public class boule_touche_pro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cacher le canva de fin de niveau
        GameObject.Find("Canvas_Fin_Niveau").GetComponent<Canvas>().enabled = false;

        //quand il clique sur le bouton rejouer, recharger la scene
        GameObject.Find("button_replay").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                Debug.Log("Rejouer le niveau");
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            });

    }

    // Update is called once per frame
    void Update()
    {
        //si la boule touche le trou, afficher le canva de fin de niveau
        if (Vector3.Distance(GameObject.Find("boule_gold").transform.position, transform.position) < 0.5f)
        {
            GameObject.Find("Canvas_Fin_Niveau").GetComponent<Canvas>().enabled = true;
        }
    }
}
