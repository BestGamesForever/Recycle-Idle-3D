using DG.Tweening;
using UnityEngine;

public class movePotion : MonoBehaviour
{
    Transform TargetTransform;
    Sequence potionAnimation;
    float delay;
    float result;
    void Start()
    {
        TargetTransform = GameObject.FindGameObjectWithTag("MyTarget").transform;
        delay = GetFloat(gameObject.name, 0);
        movePotions();

    }
    private float GetFloat(string stringValue, float defaultValue)
    {
        float result = defaultValue;
        float.TryParse(stringValue, out result);
        return result / 4;
    }
    void movePotions()
    {
        potionAnimation = DOTween.Sequence();
        potionAnimation.Append(transform.DOMove(TargetTransform.position, 1 + delay)
            .SetEase(Ease.OutBounce)).OnComplete(() => Destroy(gameObject));
    }
}
