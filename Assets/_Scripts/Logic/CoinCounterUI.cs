using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;

    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;
    //private void Start()
    //{
    //    current.SetText("0");
    //    toUpdate.SetText("0");
    //    containerInitPosition = coinTextContainer.localPosition.y + 58;
    //    moveAmount = current.rectTransform.rect.height;
    //    Debug.Log(containerInitPosition);
    //    Debug.Log(moveAmount);
    //}

    //public void UpdateScore(int score)
    //{
    //    // set the score to the masked text UI
    //    toUpdate.SetText($"{score}");
    //    // trigger the local move animation
    //    //coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
    //    coinTextContainer.DOLocalMoveY(173, duration).SetEase(animationCurve);
    //    StartCoroutine(ResetCoinContainer(score));
    //}

    private void Start()
    {
        current.SetText("0");
        toUpdate.SetText("0");
    }

    public void UpdateScore(int score)
    {
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score)
    {
        // this tells the editor to wait for a given period of time
        yield return new WaitForSeconds(duration);
        // we use duration since that's the same time as the animation
        current.SetText($"{score}"); // update the original score
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
        // then reset the y-localPosition of the coinTextContainer
    }


}