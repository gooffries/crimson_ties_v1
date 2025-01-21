using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemCollection : MonoBehaviour
{
    private int Gem = 0;

    public TextMeshProUGUI GemText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gems")) // Ensure only objects tagged as "Gem" are collected
        {
            Gem++;
            GemText.text = "Gems: " + Gem.ToString();
            Debug.Log(Gem);
            Destroy(other.gameObject);
        }
    }
}
