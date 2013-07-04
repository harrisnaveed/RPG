using UnityEngine;
using System.Collections;

public class ItemSlotSlider : MonoBehaviour {

    public int _iconNum = 1;
    public Texture _texture;
    public Transform diff;

    private GameItem _item;
    private bool _hasItem = false;
    private ItemDetailController _boxItem;
    private WindowCharacterController _windowChar;

	void Start () {

        _windowChar = GameObject.Find("WindowCharacter").GetComponent<WindowCharacterController>();
        _boxItem = GameObject.Find("BoxItemDetail").GetComponent<ItemDetailController>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (_hasItem)
        {
            GUI.DrawTextureWithTexCoords(
                    new Rect(guiTexture.pixelInset.x + 6, Screen.height - guiTexture.pixelInset.y - 38 - diff.position.y * Screen.height, 32, 32),
                    _texture, new Rect(0.05f * _iconNum, 0, 0.05f, 1f));
        }
    }

    public void addToSlot(GameItem slot)
    {
        _item = slot;
        Debug.Log(_item);
        _hasItem = true;
        _iconNum = slot.sprite;
    }

    public void removeItem()
    {
        _hasItem = false;
        _item = null;
    }

    void OnMouseDrag()
    {
        diff.GetComponent<ListItensController>().OnMouseDrag();
    }

    void OnMouseDown()
    {
        if (_hasItem)
        {
            _windowChar.currentItemSelected = _item;
            _boxItem.showItemDetail(this.gameObject);
        }
        
        diff.GetComponent<ListItensController>().OnMouseDown();
    }

    public GameItem item
    {
        get { return _item; }
        set { _item = value; }
    }
    public bool hasItem
    {
        get { return _hasItem; }
        set { _hasItem = value; }
    }
}
