using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ToFirstScence : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public bool isWait = true;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        StartCoroutine(needWait());
    }

    IEnumerator needWait()
    {
        yield return new WaitForSeconds(3);
        print("Video player" + videoPlayer.isPlaying);
        if (!videoPlayer.isPlaying)
        {
            /*print("no Video");*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
