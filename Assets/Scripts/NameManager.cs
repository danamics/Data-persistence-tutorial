using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }


    public void SaveName(GameObject input)
    {
        string text = input.GetComponent<TMP_InputField>().text;
        NameData.Instance.user_name = text;
    }
}
