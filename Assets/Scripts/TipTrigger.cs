using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private string message;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TipsManager.displayTipEvent?.Invoke(message);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TipsManager.disableTipEvent?.Invoke();
        }
    }

}
