using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class VirtualButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image _image;
    private float _scale;

    public VirtualButtonConfig config;
    [Space]
    public UnityEvent OnClick;

    void Awake()
    {
        _image = GetComponent<Image>();
        _scale = transform.localScale.x;
        OnClick = new UnityEvent();

        if(_scale <= 0)
        {
            _scale = 1;
        }

        if(!config.isDisabled)
            _image.sprite = config.DefaultImage;
        else
            _image.sprite = config.DisabledImage;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.sprite = config.HowerImage;
        if(config.IsScaleble)
        {
            transform.DOScale(new Vector3(config.HowerScale, config.HowerScale, config.HowerScale), 0.5f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = config.DefaultImage;

        if (config.IsScaleble)
        {
            transform.DOScale(new Vector3(_scale, _scale, _scale), 0.5f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = config.PressedImage;
        if (config.IsScaleble)
        {
            transform.DOScale(new Vector3(config.PressedScale, config.PressedScale, config.PressedScale), 0.5f);
        }

        OnClick?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = config.HowerImage;
        if (config.IsScaleble)
        {
            transform.DOScale(new Vector3(config.HowerScale, config.HowerScale, config.HowerScale), 0.5f);
        }
    }

    public void AddListener(UnityAction action)
    {
        OnClick.RemoveAllListeners();

        OnClick.AddListener(action);
    }
}
