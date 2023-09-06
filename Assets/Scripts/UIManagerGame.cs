using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManagerGame : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] hideUI;

    [SerializeField]
    private RectTransform scoresUI;

    [SerializeField]
    private TextMeshProUGUI damageText,
        killsText,
        timeText,
        bestTimeText,
        timeBonusText,
        totalScoresText,
        balanceText,
        damageCount,
        killsCount,
        timeCount,
        bestTimeCount,
        timeBonusCount,
        totalScoresCount,
        balanceCount;

    private YandexAds ads;
    private int adsCount;

    private Sequence showScoresBoardAnim,
        showScoresAnim;

    public void EndGame(GameEndData endData)
    {
        ads = FindAnyObjectByType<YandexAds>();
        HideGameUI();
        PrepareAnim(endData);
        showScoresBoardAnim.Play();
    }

    private void HideGameUI()
    {
        foreach (RectTransform rt in hideUI)
        {
            DOTween
                .To(
                    () => rt.anchoredPosition,
                    x => rt.anchoredPosition = x,
                    new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y * -10),
                    1
                )
                .Play();
        }
    }

    private void PrepareAnim(GameEndData endData)
    {
        balanceText.text = Localization.CurrentLanguage["BalanceText"];
        damageText.text = Localization.CurrentLanguage["DamageText"];
        killsText.text = Localization.CurrentLanguage["KillsText"];
        timeText.text = Localization.CurrentLanguage["TimeText"];
        bestTimeText.text = Localization.CurrentLanguage["BestTimeText"];
        timeBonusText.text = Localization.CurrentLanguage["TimeBonusText"];
        totalScoresText.text = Localization.CurrentLanguage["TotalScoresText"];

        balanceCount.text = endData.Balance;
        showScoresBoardAnim = DOTween.Sequence();
        showScoresBoardAnim.Append(
            DOTween.To(
                () => scoresUI.anchoredPosition,
                x => scoresUI.anchoredPosition = x,
                new Vector2(0, 0),
                1.5f
            )
        );
        showScoresBoardAnim.AppendCallback(() =>
        {
            Debug.Log("BOARDCallBAck");
#if UNITY_WEBGL && !UNITY_EDITOR
            adsCount++;
            if (adsCount == 3)
            {
                adsCount = 0;
                Debug.Log("BOARDCallBAckADS");
                ads.ShowFSADS(this);
            }
            else
            {
                ShowScores();
            }
#else
            Debug.Log("BOARDCallBAckSHowScores");
            ShowScores();
#endif
            Debug.Log("BOARDCallBAckend");
        });

        showScoresAnim = DOTween.Sequence();

        showScoresAnim.AppendCallback(() =>
        {
            AudioManager.PlayShootSound();
            damageCount.text = endData.Damage;
        });
        showScoresAnim.Append(
            damageCount.transform.parent.DOPunchScale(
                damageCount.transform.parent.localScale * 1.1f,
                0.1f
            )
        );

        showScoresAnim.AppendCallback(() =>
        {
            AudioManager.PlayShootSound();

            killsCount.text = endData.Kills;
        });
        showScoresAnim.Append(
            killsCount.transform.parent.DOPunchScale(
                killsCount.transform.parent.localScale * 1.1f,
                0.1f
            )
        );

        showScoresAnim.AppendCallback(() =>
        {
            AudioManager.PlayShootSound();
            bestTimeCount.text = endData.BestTime;
        });
        showScoresAnim.Append(
            bestTimeCount.transform.parent.DOPunchScale(
                bestTimeCount.transform.parent.localScale * 1.1f,
                0.1f
            )
        );

        showScoresAnim.AppendCallback(() =>
        {
            AudioManager.PlayShootSound();
            timeCount.text = endData.Time;
        });
        showScoresAnim.Append(
            timeCount.transform.parent.DOPunchScale(
                timeCount.transform.parent.localScale * 1.1f,
                0.1f
            )
        );

        showScoresAnim.AppendCallback(() =>
        {
            AudioManager.PlayShootSound();
            timeBonusCount.text = endData.TimeBonus;
        });
        showScoresAnim.Append(
            timeBonusCount.transform.parent.DOPunchScale(
                timeBonusCount.transform.parent.localScale * 1.1f,
                0.1f
            )
        );

        showScoresAnim.AppendCallback(() =>
        {
            AudioManager.PlayShootSound();
            totalScoresCount.text = endData.TotalScores;
        });
        showScoresAnim.Append(
            totalScoresCount.transform.parent.DOPunchScale(
                totalScoresCount.transform.parent.localScale * 1.1f,
                0.1f
            )
        );

        showScoresAnim.AppendCallback(() =>
        {
            AudioManager.PlayShootSound();
            balanceCount.text = endData.NewBalance;
        });
        showScoresAnim.Append(
            balanceCount.transform.parent.DOPunchScale(
                balanceCount.transform.parent.localScale * 1.1f,
                0.1f
            )
        );
    }

    public void ShowScores()
    {
        Debug.Log("SHOWSCORES");
        showScoresAnim.Restart();
    }
}
