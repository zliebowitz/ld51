using UnityEngine;
using System.Collections;

public class FrontlineSupplier : MonoBehaviour
{
    private CardManager cardManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void Awake()
    {
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        cardManager.Draw();
        cardManager.Draw();
    }


    private void OnDestroy()
    {
        cardManager.DecreaseNextHandSize();
    }
}
