using UnityEngine;
using UnityEngine.InputSystem;
public class TowerSelection : MonoBehaviour
{
    private Tower _selectedTower;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPostion = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPostion, Vector2.zero);
            if(hit.collider != null)
            {
                Tower tower = hit.collider.transform.root.GetComponent<Tower>();
                if (tower != null)
                {
                    _selectedTower = tower;
                    Debug.Log("Selected Tower: " + _selectedTower.name);
                }
                else
                {
                    Debug.Log("Collider found, but no Tower component in parent!");
                }
            }
            else
            {
                Debug.Log("Nothing hit!");
            }
        }
        }
           
    }
     

