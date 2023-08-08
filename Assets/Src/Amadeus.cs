using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amadeus : MonoBehaviour
{
    //[SerializeField] float _crossfadeTime = 1f;
    [SerializeField] Transform _observerTarget;
    [SerializeField] float _observed;
    [SerializeField][Range(1f, 20f)] float _transitionPoint1 = 5f;
    [SerializeField][Range(1f, 20f)] float _transitionPoint2 = 10f;
    [SerializeField][Range(1f, 20f)] float _transitionPoint3 = 20f;

    [SerializeField] AudioSource _level1;
    [SerializeField] AudioSource _level2;
    [SerializeField] AudioSource _level3;
    [SerializeField] AudioSource _level4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn(_level1));
    }

    // Update is called once per frame
    void Update()
    {
        _observed = _observerTarget.localScale.x;
        if(_observed >= _transitionPoint1)
        {
            Debug.Log("Transitioning 1");
            StartCoroutine(FadeOut(_level1));
            StartCoroutine(FadeIn(_level2));

        }
        if(_observed >= _transitionPoint2)
        {
            Debug.Log("Transitioning 2");
            StartCoroutine(FadeOut(_level2));
            StartCoroutine(FadeIn(_level3));

        }
        if(_observed >= _transitionPoint3)
        {
            Debug.Log("Transitioning 3");
            StartCoroutine(FadeOut(_level3));
            StartCoroutine(FadeIn(_level4));

        }
    }

    IEnumerator FadeOut(AudioSource clip)
    {
        Debug.Log("Fadeout Corroutine started");
        clip.volume = Mathf.Lerp(100,50,0);
        yield return null;
    }
    IEnumerator FadeIn(AudioSource clip)
    {
        //Debug.Log("Fadein Corroutine started");
        clip.volume = Mathf.Lerp(0,50,100);
        yield return null;
    }

}
