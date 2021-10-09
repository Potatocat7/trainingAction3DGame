using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTextAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var transformCache = transform;
        var defaultposition = transformCache.localPosition;
        transformCache.localPosition = new Vector3(0, 300f);
        transformCache.DOLocalMove(defaultposition, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() => 
            {
                Debug.Log("GAME OVER!!");
                transformCache.DOShakePosition(1.5f, 100);
            });
        DOVirtual.DelayedCall(10, () =>
         {
             SceneManager.LoadScene("Title");
         });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
