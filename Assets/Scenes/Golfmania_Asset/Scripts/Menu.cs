using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject information_window;
    public TMP_Text club_name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Tab) && !information_window.activeSelf)
      {
        OpenMenu();
      }
      else if (Input.GetKeyDown(KeyCode.Tab) && information_window.activeSelf)
      {
        CloseButton();
      }
    }

    private void Update_Info_Menu(SO_Club so)
    {
      club_name.text = so.club_name;
    }
    public void Select_Club(SO_Club so)
    {

      Update_Info_Menu(so);
      information_window.SetActive(true);
    }

    public void CloseButton()
    {
      Cursor.lockState = CursorLockMode.Locked;
      information_window.SetActive(false);
    }

    public void OpenMenu()
    {
      Cursor.lockState = CursorLockMode.None;
      information_window.SetActive(true);
    }
}
