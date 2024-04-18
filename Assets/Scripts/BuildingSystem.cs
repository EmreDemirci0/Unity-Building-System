using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance { get; private set; }

    [SerializeField] private BuildItem item;
    [SerializeField] private KeyCode _interactableShowTempKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _interactableInstantiateKey = KeyCode.Mouse1;

    [SerializeField] private float _rayLenght = 5;
    [SerializeField] private float _rotateSpeed = 100;
    [SerializeField, Range(0.01f, 1)] private float _itemDuration = .5f;


    private GameObject _handTempItem;
    public bool isPlacementRestriction = true;

    public enum PlaceState
    {
        None,
        Green,
        Red,
        White
    }
    public PlaceState placeState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _handTempItem = Instantiate(item.tempObjectPrefab, item.HandPosition, Quaternion.Euler(item.HandRotation));
        _handTempItem.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        _handTempItem.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_interactableShowTempKey))
        {
            if (placeState == PlaceState.None)
            {
                _handTempItem.SetActive(true);
                _handTempItem.transform.localPosition = item.HandPosition;
                _handTempItem.transform.localRotation = Quaternion.Euler(item.HandRotation);

                placeState = PlaceState.Green;
            }

        }
        else if (Input.GetKeyDown(_interactableInstantiateKey))
        {
            if ((placeState == PlaceState.Green))
            {

                Instantiate(item.mainObjectPrefab, _handTempItem.transform.position, Quaternion.Euler(_handTempItem.transform.rotation.eulerAngles));
                _handTempItem.SetActive(false);
                _handTempItem.transform.localPosition = item.HandPosition;
                _handTempItem.transform.localRotation = Quaternion.Euler(item.HandRotation);

                placeState = PlaceState.None;
            }

        }

        if (placeState != PlaceState.None)
        {
            Place();
        }
        if (placeState == PlaceState.Green)
        {
            ChangeObjectColor(Color.green);
        }
        else if (placeState == PlaceState.Red)
        {
            ChangeObjectColor(Color.red);
        }
        else if (placeState == PlaceState.White)
        {
            ChangeObjectColor(Color.white);
            _handTempItem.transform.DOLocalMove(item.HandPosition, _itemDuration);
            _handTempItem.transform.DOLocalRotate(item.HandRotation, _itemDuration);
        }
    }

    private void Place()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out RaycastHit _hit, _rayLenght))
        {
            _handTempItem.SetActive(true);
            _handTempItem.transform.DOMove(_hit.point, _itemDuration);
            RotateWithScroll();

            if (_hit.transform.gameObject.CompareTag("Ground") && isPlacementRestriction)
            {
                placeState = PlaceState.Green;
            }
            else
            {
                placeState = PlaceState.Red;
            }
        }
        else
        {
            placeState = PlaceState.White;

        }
    }
    private void RotateWithScroll()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0f)
        {
            float rotationAmount = scrollWheelInput * _rotateSpeed;
            float roundedRotation = Mathf.Round(rotationAmount / 15f) * 15f;
            //if (roundedRotation<180)
            //{
            //    roundedRotation += 180;
            //}
            _handTempItem.transform.Rotate(Vector3.up, roundedRotation);
        }
    }


    private void ChangeObjectColor(Color color)
    {
        if (_handTempItem.GetComponent<MeshRenderer>().material.color != color)
        {
            _handTempItem.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
