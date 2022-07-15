using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    public void playGame()
    {
        string clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        GameManager.selectedCharacter = clickedObj;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
