using System.Collections.Generic;
using System;
using UnityEngine;

namespace Unity
{
    public class UnitySerialization : MonoBehaviour
    {
        /*********************************************************************
         * 직렬화 (Serialization)
         * 
         * 데이터 구조 또는 게임오브젝트 상태를 보관하고 관리하는 기법
         * 인스펙터 창에서 오브젝트의 직렬화된 멤버변수 값을 보여줌
         * 이를 이용하여 소스코드의 수정 없이 유니티 에디터에서 값을 변경 가능
         **********************************************************************/

        // <데이터 직렬화>
        // 오브젝트의 멤버변수 값을 확인하거나 변경
        // 오브젝트의 멤버변수 참조를 드래그 앤 드랍 방식으로 연결

        [Header("Value")]
        // C# Type
        public bool boolValue;
        public int intValue;
        public float floatValue;
        public string stringValue;

        // Unity Type
        public Vector3 vector3;
        public Vector3Int vector3Int;
        public Vector2 vector2;
        public Vector2Int vector2Int;
        public Color color;
        public Rect rect;
        public LayerMask layerMask;
        public AnimationCurve curve;
        public Gradient gradient;

        // 열거형
        public ForceMode mode;

        // 직렬화 가능한 필드의 배열 및 List<T>
        public int[] array;
        public List<int> list;

        [Header("Reference")]
        // Object Type
        public new GameObject gameObject;
        public new Transform transform;
        public new Rigidbody rigidbody;
        public new Collider collider;



        // <어트리뷰트>
        // 클래스, 속성 또는 함수 위에 명시하여 특별한 동작을 나타낼 수 있는 마커

        [Space(30)]

        [Header("Unity Attribute")]

        [SerializeField]
        private int privateValue;

        [HideInInspector]
        public int publicValue;

        [Range(0, 10)]
        public float rangeValue;

        [TextArea(3, 5)]
        public string textField;

        [Serializable] // 구조체에 직렬화 가능 속성을 포함
        public struct StructType
        {
            public int value1;
            public string value2;
        }
        public StructType structField;

        [Serializable] // 클래스에 직렬화 가능 속성을 포함
        public class ClassType
        {
            public int value1;
            public string value2;
        }
        public ClassType classField;
    }
}