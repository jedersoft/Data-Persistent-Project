using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    public void StartGame()
    {
        GameManager.Instance.StartGame(input.text);
    }
}
