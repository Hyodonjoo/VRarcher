using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string Bow_Scene; // �̵��� ���� �̸�
   

    public void ChangeScene()
    {
        SceneManager.LoadScene(Bow_Scene);        
    }
}
