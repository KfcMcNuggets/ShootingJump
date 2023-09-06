using UnityEngine;
using System.Runtime.InteropServices;

public class YandexAds : MonoBehaviour
{
    private UIManagerGame uimanager;

    [DllImport("__Internal")]
    private static extern void ShowFullscreen();

    [DllImport("__Internal")]
    private static extern void ShowRewarded();

    public void ShowFSADS(UIManagerGame uimanager)
    {
        Debug.Log("SHOFASD");
        this.uimanager = uimanager;
        ShowFullscreen();
    }

    public void ShowRewardADS()
    {
        ShowRewarded();
    }

    public void ContinueGame()
    {
        uimanager.ShowScores();
    }
}
