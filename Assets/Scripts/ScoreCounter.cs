using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private int maxCount;

    [SerializeField] private TextMeshProUGUI countLabel;

    [SerializeField] private Color32 matchColor;
    [SerializeField] private Color32 defaultColor;
    [SerializeField] private Color32 overflowtColor;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            count--;
            ScoreCounterShow();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cup"))
        {
            count++;
            ScoreCounterShow();
        }
    }
    private void ScoreCounterShow()
    {
        countLabel.text = count.ToString();
        if (count == maxCount)
        {
            countLabel.color = matchColor;
        }
        else if (count > maxCount)
        {
            countLabel.color = overflowtColor;
        }
        else
        {
            countLabel.color = defaultColor;
        }
    }
}
