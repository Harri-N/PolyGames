using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ce script doit être associé à chaque panneau d'un menu
//Il permet de définir le type de panneau et l'objet à sélectionner par défaut
//Il permet de changer l'état du panneau (ouvert ou fermé)

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
