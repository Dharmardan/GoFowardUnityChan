﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

	//Prefab
	public GameObject cubePrefab;
	//時間計測用の変数
	private float delta=0;
	//生成間隔
	private float span=1.0f;
	//生成位置、x座標
	private float genPosX=12;

	//生成位置オフセット
	private float offsetY=0.3f;
	//縦方向の間隔
	private float spaceY=6.9f;

	//生成位置オフセット
	private float offsetX=0.5f;
	//横方向の間隔
	private float spaceX=0.4f;

	//生成個数の上限
	private int maxBlockNum=4;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		//span秒以上の時間が経過したか調べる
		if (this.delta > this.span) {
			this.delta = 0;
			//生成するキューブ数をランダムに決める
			int n = Random.Range (1, maxBlockNum + 1);
			//指定した数だけキューブを生成する
			for (int i = 0; i < n; i++) {
				//キューブの生成
				GameObject go = Instantiate (cubePrefab)as GameObject;
				go.transform.position = new Vector2 (this.genPosX, this.offsetY+i * this.spaceY);
			}
			//次のキューブの生成時間を決める
			this.span = this.offsetX+ this.spaceX * n;
		}
	}
}