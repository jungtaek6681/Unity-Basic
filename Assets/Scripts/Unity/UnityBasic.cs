using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
	[Header("This GameObject")]
	public GameObject thisGameObject;
	public string thisName;
	public bool thisActive;
	public string thisTag;
	public int thisLayer;

	[Header("Find GameObject")]
	public GameObject findWithName;
	public GameObject findWithTag;
	public GameObject[] findsWithTag;

	[Header("New & Destory GameObject")]
	public GameObject newGameObject;
	public GameObject destroyGameObject;

	[Space(30)]

	[Header("GetComponent On SameGameObject")]
	public AudioSource gameObjectGetComponent;
	public AudioSource componentGetComponent;

	[Header("GetComponent On OtherGameObject")]
	public GameObject otherGameObject;

	public AudioSource component;
	public AudioSource childComponent;
	public AudioSource parentComponent;
	public AudioSource[] components;
	public AudioSource[] childComponents;
	public AudioSource[] parentComponents;

	[Header("Find Component")]
	public Rigidbody findWithType;
	public Rigidbody[] findsWithType;

	[Header("Add & Destroy Component")]
	public GameObject addComponent;
	public Component destroyComponent;

	private void Start()
	{
		GameObjectBasic();
		ComponentBasic();
	}

	void GameObjectBasic()
	{
		// <게임오브젝트 접근>
		// 컴포넌트가 붙어있는 게임오브젝트는 gameObject 속성을 이용하여 접근가능
		thisGameObject = gameObject;                // 컴포넌트가 붙어있는 게임오브젝트

		thisName = gameObject.name;					// 게임오브젝트의 이름 접근
		thisActive = gameObject.activeSelf;			// 게임오브젝트의 활성화 여부 접근
		thisTag = gameObject.tag;					// 게임오브젝트의 태그 접근
		thisLayer = gameObject.layer;               // 게임오브젝트의 레이어 접근

		// <씬 내의 게임오브젝트 탐색>
		findWithName = GameObject.Find("FindGameObject");           // 이름으로 찾기
		findWithTag = GameObject.FindGameObjectWithTag("MyTag");    // 태그로 하나 찾기
		findsWithTag = GameObject.FindGameObjectsWithTag("MyTag");	// 태그로 모두 찾기

		// <게임오브젝트 생성>
		newGameObject = new GameObject();

		// <게임오브젝트 삭제>
		if (destroyGameObject != null)
			Destroy(destroyGameObject);
	}

	void ComponentBasic()
	{
		// <게임오브젝트 내 컴포넌트 접근>
		// GetComponent를 이용하여 게임오브젝트 내 컴포넌트 접근
		gameObjectGetComponent = GetComponent<AudioSource>();
		// 컴포넌트에서 GetComponent를 사용할 경우 부착되어 있는 게임오브젝트를 기준으로 접근
		componentGetComponent = GetComponent<AudioSource>();    // == gameObject.GetComponent<AudioSource>();

		component = otherGameObject.GetComponent<AudioSource>();					// 게임오브젝트의 컴포넌트 접근
		components = otherGameObject.GetComponents<AudioSource>();					// 게임오브젝트의 컴포넌트들 접근
		childComponent = otherGameObject.GetComponentInChildren<AudioSource>();		// 자식 게임오브젝트 포함 컴포넌트 접근
		childComponents = otherGameObject.GetComponentsInChildren<AudioSource>();	// 자식 게임오브젝트 포함 컴포넌트들 접근
		parentComponent = otherGameObject.GetComponentInParent<AudioSource>();		// 부모 게임오브젝트 포함 컴포넌트 접근
		parentComponents = otherGameObject.GetComponentsInParent<AudioSource>();	// 부모 게임오브젝트 포함 컴포넌트들 접근

		// <씬 내의 컴포넌트 탐색>
		findWithType = FindObjectOfType<Rigidbody>();								// 씬 내의 컴포넌트 하나 찾기
		findsWithType = FindObjectsOfType<Rigidbody>();								// 씬 내의 컴포넌트 모두 찾기

		// <컴포넌트 추가>
		// Rigidbody rigid = new Rigidbody();	// 가능하나 의미없음, 컴포넌트는 게임오브젝트에 부착되어 동작함에 의미가 있음
		Rigidbody rigid = addComponent.AddComponent<Rigidbody>();					// 게임오브젝트에 컴포넌트 추가

		// <컴포넌트 삭제>
		Destroy(destroyComponent);
	}
}
