using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    Button button;
    [SerializeField] TextMeshProUGUI nameTxt;

    void Start()
    {
        button = GetComponent<Button>();
    }

    public void LoadGameScene()
    {
        PersistentData.Instance.SetPlayerName(nameTxt.text);
        SceneManager.LoadScene(1);
    }
}