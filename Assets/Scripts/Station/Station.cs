using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Station
{
    public abstract class Station<TLevel> : MonoBehaviour where TLevel : StationLevel

    {
    public SpriteRenderer SpriteRenderer;
    protected GameManager Manager => GameManager.Instance;

    public int Level
    {
        get => PlayerPrefs.GetInt($"maker_{GetInstanceID()}", 0);
        set
        {
            var val = value < Levels.Count ? value : 0;
            PlayerPrefs.SetInt($"maker_{GetInstanceID()}", val);
            SpriteRenderer.sprite = Levels[Level].Sprite;
        }
    }

    public List<TLevel> Levels;

    protected void SetTimeout(float time, Action end = null, Action<float> update = null)
    {
        IEnumerator coroutine()
        {
            var start = Time.time;
            while (Time.time - start < time)
            {
                update?.Invoke((Time.time - start) / time);
                yield return null;
            }

            end?.Invoke();
        }

        StartCoroutine(coroutine());
    }
    }
}
