using UnityEngine;
using UnityEngine.SceneManagement; 

public class FinishLine : MonoBehaviour
{
    public string nextSceneName = "Level2"; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            Debug.Log("Load...");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}