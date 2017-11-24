using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
	void Start(){
		Time.timeScale = 1f;

	}
	//
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
}