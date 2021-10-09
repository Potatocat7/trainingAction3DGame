using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Main");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
