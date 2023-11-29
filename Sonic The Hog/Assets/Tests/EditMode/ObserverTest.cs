using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ObserverTest : Observer
{
    public ObserverTest()
    {
    }
    public ObserverTest(Subject subject)
    {
        this.subject = subject;
        this.subject.Attach(this);
    }

    public override void Update()
    {
        string newState = subject.GetState();

        Debug.Log($"Observer received update with new state: {newState}");
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void ObserverClassPasses()
    {
        subject = new Subject();
        new ObserverTest(subject);
        subject.SetState("passed");
        Assert.AreEqual("passed", subject.GetState());

    }

}
