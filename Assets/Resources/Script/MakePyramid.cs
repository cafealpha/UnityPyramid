using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePyramid : MonoBehaviour {

    void Start () {
        CUSTOM_VERTEX[] vt = {
            //전면
            new CUSTOM_VERTEX(new Vector3(-1.0f, 0.0f, -1.0f), new Vector3(0f, 0.707f, -0.707f), Color.white),
            new CUSTOM_VERTEX(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(0f, 0.707f, -0.707f), Color.white),
            new CUSTOM_VERTEX(new Vector3(1.0f, 0.0f, -1.0f), new Vector3(0f, 0.707f, -0.707f), Color.white),

            //왼쪽 측면
            new CUSTOM_VERTEX(new Vector3(-1.0f, 0.0f, 1.0f), new Vector3(-0.707f, 0.707f, 0.0f), Color.white),
            new CUSTOM_VERTEX(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(-0.707f, 0.707f, 0.0f), Color.white),
            new CUSTOM_VERTEX(new Vector3(-1.0f, 0.0f, -1.0f), new Vector3(-0.707f, 0.707f, 0.0f), Color.white),

            //오른쪽 측면
            new CUSTOM_VERTEX(new Vector3(1.0f, 0.0f, -1.0f), new Vector3(0.707f, 0.707f, 0.0f), Color.white),
            new CUSTOM_VERTEX(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(0.707f, 0.707f, 0.0f), Color.white),
            new CUSTOM_VERTEX(new Vector3(1.0f, 0.0f, 1.0f), new Vector3(0.707f, 0.707f, 0.0f), Color.white),

            //후면
            new CUSTOM_VERTEX(new Vector3(1.0f, 0.0f, 1.0f), new Vector3(0.0f, 0.707f, 0.707f), Color.white),
            new CUSTOM_VERTEX(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(0.0f, 0.707f, 0.707f), Color.white),
            new CUSTOM_VERTEX(new Vector3(-1.0f, 0.0f, 1.0f), new Vector3(0.0f, 0.707f, 0.707f), Color.white),
        };

        //인덱스가 없는 버텍스 리스트이므로 인덱스버퍼에 순서대로 넣어주기만 하면 된다.
        int[] triangles = new int[vt.Length];
        for(int i =0; i< triangles.Length; i++)
        {
            triangles[i] = i;
        }

        //노말과 버텍스 컬러는 입력할 필요 없다.
        //노말은 이미 버텍스 구조체 안에 들어있음.

        //버텍스 리스트 추출
        Vector3[] vtl = new Vector3[vt.Length];
        for (int i = 0; i < vt.Length; i++)
        {
            vtl[i] = vt[i].pos;
        }

        //노말 추출
        Vector3[] nl = new Vector3[vt.Length];
        for (int i = 0; i < vt.Length; i++)
        {
            nl[i] = vt[i].normal;
        }

        //매쉬 생성
        Mesh mesh = new Mesh();
        mesh.vertices = vtl;
        mesh.triangles = triangles;
        mesh.normals = nl;

        foreach (var item in mesh.normals)
        {
            Debug.Log(item.ToString());
        }


        //인스턴스화할 게임오브젝트를 만듬.        
        GameObject obj = new GameObject();
        obj.name = "Pyramid";
        
        //매쉬 필터와 렌더러를 붙여주고 캐시함
        MeshFilter mf = obj.AddComponent<MeshFilter>();
        MeshRenderer mr = obj.AddComponent<MeshRenderer>();
        //매쉬 필터에 적용
        mf.mesh = mesh;
        //머티리얼 적용
        Material mat = new Material(Shader.Find("Custom/BasicShader"));
        mr.material = mat;

        //Instantiate(obj);

    }

}
