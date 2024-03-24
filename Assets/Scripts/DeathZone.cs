using JUTPS;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class DeathZone : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnEnterDeathZone; 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            JUHealth player = collision.gameObject.GetComponent<JUHealth>();
            if(player != null)
            {
                OnEnterDeathZone?.Invoke();
                player.DoDamage(player.MaxHealth);
            }
        }
    }
}
