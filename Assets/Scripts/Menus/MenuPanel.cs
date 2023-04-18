using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class MenuPanel : MonoBehaviour
{
    [SerializeField] private PanelType type;

    [Header("Config")]
    [SerializeField] private GameObject selectedGameObject;

    private bool state;

    private Canvas canvas;
    private MenuController controller;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Init(MenuController _controller) {controller = _controller; }

    private void UpdateState()
    {
        canvas.enabled = state;
        if(state) controller.SetSelectedGameObject(selectedGameObject);
    }

    public void ChangeState()
    {
        state = !state;
        UpdateState();
    }

    public void ChangeState(bool _state)
    {
        state = _state;
        UpdateState();
    }

    #region Getter

    public PanelType GetPanelType() {return type;}

    #endregion
}
