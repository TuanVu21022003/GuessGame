using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objects; // Danh s�ch c�c v?t th? trong d�y
    public Transform[] emptySlots; // Danh s�ch c�c � tr?ng

    void Update()
    {
        // Ki?m tra khi ng??i ch?i click chu?t
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ki?m tra xem chu?t ?� ch?m v�o v?t th? n�o hay kh�ng
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.transform.gameObject;

                // Ki?m tra xem v?t th? ???c ch?n c� trong danh s�ch kh�ng
                if (System.Array.Exists(objects, obj => obj == clickedObject))
                {
                    // T�m v? tr� c?a v?t th? ???c ch?n trong danh s�ch
                    int objectIndex = System.Array.IndexOf(objects, clickedObject);

                    // Ki?m tra xem c� � tr?ng n�o kh�ng
                    if (objectIndex < emptySlots.Length)
                    {
                        // Di chuy?n v?t th? ???c ch?n ??n v? tr� c?a � tr?ng
                        clickedObject.transform.position = emptySlots[objectIndex].position;
                    }
                }
            }
        }
    }
}
