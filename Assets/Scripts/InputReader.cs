using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InputReader : MonoBehaviour
{
    string nom;

    [SerializeField]
    private TMP_Text txtComponenet;
    public GameObject mainCanvas;
    public GameObject player;
    public GameObject logsManager;
    public Canvas listeCvs;

    public bool isStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<CharacterController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            nom = txtComponenet.text;
            mainCanvas.SetActive(false);
            player.GetComponent<CharacterController>().enabled = true;
            logsManager.SetActive(true);
            logsManager.GetComponent<LogsManager>().isStarted = true;
            listeCvs.enabled = false ;
        }
       
        
    }

    public string getNom()
    {
        return nom;
    }
}
