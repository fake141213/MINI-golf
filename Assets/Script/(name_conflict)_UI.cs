using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{

    public int SceneNUM;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneNUM = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextScene()
    {
        SceneManager.LoadScene(SceneNUM+1);
    }
    public void Restart()
{
    SceneManager.LoadScene(SceneNUM);
}
public void MainMenu()
{
    SceneManager.LoadScene(0);
}
public void ExitGame()
{

    UnityEditor.EditorApplication.isPlaying = false;

    Application.Quit();
// test Test
}
}
