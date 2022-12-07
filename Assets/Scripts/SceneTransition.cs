using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;

    private string sceneToLoad;
    public static bool isTransitioning;

    public void OnClick(Button button)
    {
        if (button.tag == "MainMenu")
        {
            FadeToScene("MainMenu");
        }
        if (button.tag == "Scene1")
        {
            FadeToScene("Scene1");
        }
        if (button.tag == "Scene2")
        {
            FadeToScene("Scene2");
        }
        if (button.tag == "QuitGame")
        {
            FadeToScene("QuitGame");
        }
    }

    public void FadeToScene(string sceneName)
    {
        sceneToLoad = sceneName;
        animator.SetTrigger("fadeOut");
        isTransitioning = true;
    }

    public void FadeIntoScene()
    {
        isTransitioning = true;
    }

    public void FadeIntoSceneComplete()
    {
        isTransitioning = false;
    }

    public void OnFadeComplete()
    {
        if (sceneToLoad == "QuitGame")
        {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
        isTransitioning = false;
        SceneManager.LoadScene(sceneToLoad);
    }
}
