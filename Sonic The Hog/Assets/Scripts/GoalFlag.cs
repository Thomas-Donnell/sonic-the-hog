using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlag : MonoBehaviour
{
    public ParticleSystem animator;
    public GameSceneManage sceneManage;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "sonic")
        {
            animator.Play();
            StartCoroutine(delay());
        }
    }

    private IEnumerator delay()
    {
        // Wait for 2 seconds before destroying the GameObject
        yield return new WaitForSeconds(2f);
        sceneManage.EndScreen();
    }
}
