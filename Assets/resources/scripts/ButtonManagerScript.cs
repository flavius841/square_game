using UnityEngine;

public class ButtonManagerScript : MonoBehaviour
{


    public void Scene1Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void InvokeScene1Load()
    {
        Invoke("Scene1Load", 0.5f);
    }

    public void MenuLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void InvokeMenuLoad()
    {
        Invoke("MenuLoad", 0.5f);
    }

    public void Quit()
    {
        Application.Quit();
    }



}
