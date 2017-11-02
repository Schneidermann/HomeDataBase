using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour {


	const string baseurl = "http://localhost:52672//API";
    public Text Nome;
    public Text Descricao;
    public Text id;
    public Text poligonos;
    public Text tamanho;

	// Use this for initialization
	void Start () {
		StartCoroutine (GetItems ());
	}

	IEnumerator GetItems()
	{
		UnityWebRequest request = UnityWebRequest.Get (baseurl + "/Dados");
		yield return request.Send();

		if (request.isNetworkError || request.isHttpError) {
			Debug.Log (request.error);
		} else 
		{
			string response = request.downloadHandler.text;
			Debug.Log (response);
			byte[] bytes = request.downloadHandler.data;

			Item[] itens = JsonHelper.getJsonArray<Item> (response);
			foreach (Item i in itens)
			{
				ImprimirItem (i);
			}
		}


	}


	private void ImprimirItem(Item i)
	{
		Debug.Log ("====== Dados Objeto ======");
		Debug.Log ("Tipo: " + i.TipoItemID);
		Debug.Log ("Nome: " + i.Nome);
		Debug.Log ("Descrição: " + i.Descricao);
		Debug.Log ("Poligonos: " + i.Poligonos);
		Debug.Log ("Raridade: " + i.Tamanho);

        Nome.text = "Nome: " + i.Nome;
        Descricao.text = "Descrição: " + i.Descricao;
        poligonos.text = "Poligonos: " + i.Poligonos.ToString();
        tamanho.text = "Tamanho: " + i.Tamanho.ToString();
        id.text = "ItemID: " + i.TipoItemID.ToString();
    }

}
