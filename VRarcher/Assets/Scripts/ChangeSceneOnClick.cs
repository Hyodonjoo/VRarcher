using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string Bow_Scene; // 이동할 씬의 이름
   

    public void ChangeScene()
    {
        SceneManager.LoadScene(Bow_Scene);        
    }
}
