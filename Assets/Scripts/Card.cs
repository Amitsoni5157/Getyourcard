using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    /*[HideInInspector]*/ public int id;
    public Sprite cardBack;
    /*[HideInInspector]*/ public Sprite cardFront;

    private Image image;
    private Button button;

    private bool isFlippingOpen;
    private bool isFlippingClose;
    private bool flipped;//true == cardFront
    private float flipAmount = 1;

    public float flipSpeed = 4;

    public bool isMatched;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void FlipCard()
    {
        if(CardManager.Instance.Choice1 == 0)
        {
            SoundManager.Instance.PlayCardFlipMusic();
            CardManager.Instance.Choice1 = id;
            CardManager.Instance.AddChoosenCard(this.gameObject);

            isFlippingOpen = true;
            StartCoroutine(FlipOpen());

            button.interactable = false;
        }else if (CardManager.Instance.Choice2 == 0)
        {
            SoundManager.Instance.PlayCardFlipMusic();
            CardManager.Instance.Choice2 = id;
            CardManager.Instance.AddChoosenCard(this.gameObject);

            isFlippingOpen = true;
            StartCoroutine(FlipOpen());

            button.interactable = false;

            StartCoroutine(CardManager.Instance.CompareCards());

        }
    }

    IEnumerator FlipOpen()
    {
        while (isFlippingOpen && flipAmount > 0)
        {
            flipAmount -= Time.deltaTime * flipSpeed;
            flipAmount = Mathf.Clamp01(flipAmount);
            transform.localScale = new Vector3(flipAmount,transform.localScale.y,transform.localScale.z);
            if(flipAmount <= 0)
            {
                image.sprite = cardFront;
                isFlippingOpen = false;
                isFlippingClose = true;
            }
            yield return null;
        }
        while (isFlippingClose && flipAmount < 1)
        {
            flipAmount += Time.deltaTime * flipSpeed;
            flipAmount = Mathf.Clamp01(flipAmount);
            transform.localScale = new Vector3(flipAmount, transform.localScale.y, transform.localScale.z);
            if (flipAmount >= 1)
            {
                isFlippingClose = false;
            }
            yield return null;
        }
    }

    IEnumerator FlipClose()
    {
        while (isFlippingOpen && flipAmount > 0)
        {
          
            flipAmount -= Time.deltaTime * flipSpeed;
            flipAmount = Mathf.Clamp01(flipAmount);
            transform.localScale = new Vector3(flipAmount, transform.localScale.y, transform.localScale.z);
            if (flipAmount <= 0)
            {
                image.sprite = cardBack;
                isFlippingOpen = false;
                isFlippingClose = true;
            }
            yield return null;
        }
        while (isFlippingClose && flipAmount < 1)
        {
           
            flipAmount += Time.deltaTime * flipSpeed;
            flipAmount = Mathf.Clamp01(flipAmount);
            transform.localScale = new Vector3(flipAmount, transform.localScale.y, transform.localScale.z);
            if (flipAmount >= 1)
            {
                isFlippingClose = false;
            }
            yield return null;
        }
        button.interactable = true;
    }

    public void CloseCard()
    {
        isFlippingOpen = true;
        StartCoroutine(FlipClose());
    }
}
