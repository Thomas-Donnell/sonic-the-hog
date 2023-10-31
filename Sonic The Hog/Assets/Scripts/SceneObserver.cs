using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObserver : Observer
{
    public SceneObserver(Subject subject)
    {
        this.subject = subject;
        this.subject.Attach(this);
    }

    public override void Update()
    {
        string newState = subject.GetState();

        switch (newState)
        {
            case "start":
                ChangeScene("StartSceneName");
                break;
            case "end":
                ChangeScene("EndSceneName");
                break;
            case "pause":
                ChangeScene("PauseSceneName");
                break;
            case "play":
                ChangeScene("PlaySceneName");
                break;
        }

        Debug.Log($"Observer received update with new state: {newState}");
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
