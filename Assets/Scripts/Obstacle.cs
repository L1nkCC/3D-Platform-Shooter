using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    public float speed = 30f;

    [SerializeField]
    public Transform end;

    [SerializeField]
    public float despawnTime = 3f;

    public System.Action onKill = () => { };

    Sequence m_sequence;
    // Start is called before the first frame update
    void Start()
    {
        m_sequence = DOTween.Sequence();
        m_sequence.Append(transform.DOMove(end.position, speed).SetEase(Ease.Linear));
        m_sequence.onKill += () => { onKill?.Invoke(); Destroy(this.gameObject, despawnTime); };
        
    }

    public void KillMoving()
    {
        m_sequence?.Kill();
    }

    public void PauseMoving()
    {
        m_sequence?.Pause();
    }

    private void OnDestroy()
    { 
        m_sequence?.Kill(false);
    }
}
