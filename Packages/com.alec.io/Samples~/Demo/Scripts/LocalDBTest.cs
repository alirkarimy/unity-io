using System.Collections;
using UnityEngine;

public class LocalDBTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        LocalDB.Initialize((result) => { });
        yield return new WaitForSeconds(1);
        LocalDB.Queries.UpdateBook("Coexist", new System.Collections.Generic.Dictionary<string, object> { { "Coexist", "Coexist body" } });
    }

}
