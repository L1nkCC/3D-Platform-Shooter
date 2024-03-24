using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class ShowScoreUGUI : MonoBehaviour
{
    [SerializeField]
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        SetScore();
        score.Update += SetScore;
    }

    private void SetScore()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = score.StringScore();
    }

    public void Reset()
    {
        score.Reset();
    }

    private void OnDestroy()
    {
        score.Update -= SetScore;
    }
}
