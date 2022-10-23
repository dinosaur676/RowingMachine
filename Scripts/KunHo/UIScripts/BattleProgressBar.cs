using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattleProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image progressBar_frame;

    [SerializeField]
    private Image progressBar_mine;

    [SerializeField]
    private Image progressBar_enemy;

    [SerializeField]
    private Image playerIcon;

    [SerializeField]
    private Image enemyIcon;

    public Image GoalIcon;
    public Text percentText;


    void Start()
    {
        GoalIcon.rectTransform.localPosition = new Vector3(progressBar_frame.rectTransform.sizeDelta.x / 2,
            GoalIcon.rectTransform.localPosition.y, GoalIcon.rectTransform.localPosition.z);
    }
    void Update()
    {
        progressUpdate(progressBar_mine, MesureManager.Instance.Distance);
        progressUpdate(progressBar_enemy, EnemyController.instance.Distance);

        iconUpdate(playerIcon, progressBar_mine.fillAmount);
        iconUpdate(enemyIcon, progressBar_enemy.fillAmount);

        percentText.text = Math.Round(progressBar_mine.fillAmount * 100, 1) + " %";
    }

    private void progressUpdate(Image progressImage, float distance)
    {
        progressImage.fillAmount = distance / TimeAttackManager.instance.GoalDistance;
    }

    private void iconUpdate(Image icon, float fillAmount)
    {
        float x = progressBar_frame.rectTransform.sizeDelta.x * progressBar_frame.rectTransform.localScale.x;
        float positionX = x * fillAmount - (x / 2);
        icon.rectTransform.localPosition = new Vector3(positionX, icon.rectTransform.localPosition.y,
            icon.rectTransform.localPosition.z);
    }
}
