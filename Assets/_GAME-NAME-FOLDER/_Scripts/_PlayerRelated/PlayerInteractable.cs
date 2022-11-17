using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class PlayerInteractable : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] Animator _thisComponentAnimator;
    [SerializeField] Transform _parent;
    [SerializeField] List<Transform> _pointsToSpawn;
    [SerializeField] GameObject PotionImage;
    [SerializeField] GameObject ImageContainerTransform;
    public List<Transform> _appearedPersonContainer;
    int counter;
  
    public static int value;
    public static float _ratingCalculator;
    public int Payment;
    public int _boxOfficeAmount;   

    [SerializeField] ShakeCameras _shakeCam;
    [SerializeField] UIScript _uiscript;

    [SerializeField] WaitForSeconds _waitForSeconds;
    Vector3 _rotation;
    [SerializeField] ParticleSystem _appearParticle;
    [SerializeField] Transform[] _appearPerson;
    int _appearIndex;
    int countForGameOver;

    ////////End Scene 2D Pictures Appointments;
    public Image[] _endLevelspriteR;
    public Image[] _endLevelspriteName;
    public Sprite[] _castingPictures;
    public Sprite[] _castingNames;
    private void Start()
    {
        _appearedPersonContainer = new List<Transform>();
        _ratingCalculator = 0;
        _rotation = new Vector3(180, 0, 0);
        _waitForSeconds = new WaitForSeconds(.5f);
        counter = -1;
        // _totalMoney.text = 0.ToString();
        value = 0;
        value = GameManager.Instance.totalCoins;
        _uiscript.itemCountText.text = "$" + (value).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            other.gameObject.SetActive(false);
            for (int i = 0; i < 2; i++)
            {
                GameObject moneys = Instantiate(PotionImage, Camera.main.WorldToScreenPoint(other.transform.localPosition + new Vector3(.1f, 0, 2f)), 
                                               Quaternion.Euler(Vector3.zero), ImageContainerTransform.transform);
                
                moneys.name = i.ToString();
            }
            value += 100;
            Debug.Log("Value ++" + value);
            _uiscript.itemCountText.text = "$" + (value).ToString();

            MMVibrationManager.Haptic(HapticTypes.SoftImpact, false, true, this);
        }
       
        if (other.CompareTag("BeforeLights"))
        {
            StartCoroutine(SlowAndSpeed(other));
        }
    }
    IEnumerator SlowAndSpeed(Collider other)
    {
        other.GetComponent<Collider>().enabled = false;
        _thisComponentAnimator.speed = .7f;
        _playerController._forwardSpeed = 5;
        for (int i = 0; i < _appearedPersonContainer.Count; i++)
        {
            _appearedPersonContainer[i].GetComponent<Animator>().speed = .7f;
            _appearedPersonContainer[i].GetComponent<Animator>().speed = .7f;
        }
        yield return new WaitForSeconds(.5f);
        _thisComponentAnimator.speed = 1f;
        _playerController._forwardSpeed = 10;
        for (int i = 0; i < _appearedPersonContainer.Count; i++)
        {
            _appearedPersonContainer[i].GetComponent<Animator>().speed = 1f;
            _appearedPersonContainer[i].GetComponent<Animator>().speed = 1f;
        }
    }
    IEnumerator EnableAndDisable(Collider other)
    {
        other.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return _waitForSeconds;
        other.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        Debug.Log("ActiveAndDeactive");
    }
    IEnumerator FirstOnComplete(Transform otherDoor)
    {
        yield return new WaitForSeconds(.3f);
        otherDoor.DOLocalJump(_pointsToSpawn[counter].localPosition + new Vector3(0, .5f, 0), 1, 1, .3f).SetEase(Ease.InCubic);
        otherDoor.DOLocalRotate(_rotation, .3f);
        otherDoor.DOScale(new Vector3(.2f, .2f, .2f), .3f).SetDelay(.2f).OnComplete(() => OnCompleteFunc(_pointsToSpawn[counter].position, otherDoor));
    }
    void OnCompleteFunc(Vector3 playPosition, Transform otherMove)
    {
        otherMove.DOScale(Vector3.zero, 1);
        _appearParticle.transform.position = playPosition;
        _appearParticle.Play();
        Transform _appearPersons = Instantiate(_appearPerson[_appearIndex - 1], _pointsToSpawn[counter].position, Quaternion.identity, _parent);
        _appearedPersonContainer.Add(_appearPersons);
        _thisComponentAnimator.Play("YesLayer.Victory");
    }  
}

