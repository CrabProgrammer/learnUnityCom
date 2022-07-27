using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;
   public void StartGame()
    {
        ScoreController.Instance.currentName = inputField.text;
        SceneManager.LoadScene(1);

    }
}
