using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wipage : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 3f)]
    private float wipageSpeed = 1f;

    private Image image; 

    private enum WipageMode { NotBlocked, WipingToNotBlocked, Blocked, WipingToBlocked}

    private WipageMode wipeMode = WipageMode.NotBlocked;

    private float wipeProgress;

    public bool isDone { get; private set; }


    private void Awake()
    {
        image = GetComponentInChildren<Image>();
    }

    public void ToggleWipe(bool blockScreen)
    {
        isDone = false;
        if (blockScreen)
            wipeMode = WipageMode.WipingToBlocked;
        else
            wipeMode = WipageMode.WipingToNotBlocked;
    }

    // Update is called once per frame
    void Update()
    {
        switch (wipeMode)
        {
            case WipageMode.WipingToBlocked:
                WipeToBlocked();
                break;
            case WipageMode.WipingToNotBlocked:
                WipeToNotBlocked();
                break;

        }
    }

    private void WipeToBlocked()
    {
        wipeProgress += Time.deltaTime * (1f / wipageSpeed);
        image.fillAmount = wipeProgress;
        if (wipeProgress >= 1f)
        {
            isDone = true;
            wipeMode = WipageMode.Blocked;
        }
    }

    private void WipeToNotBlocked()
    {
        wipeProgress -= Time.deltaTime * (1f / wipageSpeed);
        image.fillAmount = wipeProgress;
        if (wipeProgress <= 0)
        {
            isDone = true;
            wipeMode = WipageMode.NotBlocked;
        }
    }


    [ContextMenu("Block")]
    private void Block() { ToggleWipe(true); }
    [ContextMenu("Clear")]
    private void Clear() { ToggleWipe(false); }
}
