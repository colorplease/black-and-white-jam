using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interpreter : MonoBehaviour
{
    [SerializeField] private int indexScene;
    List<string> response = new List<string>();

    public List<string> Interpret(string input)
    {
        response.Clear();

        string[] args = input.Split();

        if (args[0] == "//help")
        {
            //Return info
            response.Add("Available commands");
            response.Add("//quit - exit the game");
            response.Add("//start - start game");
            return response;
        } else if (args[0] == "//start")
        {
            SceneManager.LoadScene(indexScene);
            return response;
        }
        else if (args[0] == "//quit")
        {
            Application.Quit();
            return response;
        }
        else
        {
            response.Add($"{args[0]} command not recognized. Type //help for a list of commands");
            return response;
        }

    }
}
