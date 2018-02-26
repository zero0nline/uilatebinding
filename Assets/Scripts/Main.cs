using System;
using System.Collections.Generic;
using loading;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
	public Canvas Canvas;

	public Button SpriteButton;
	public Button UiButton;

	private const string Bundle1Name = "prefabs/bundle_1";
	private const string Bundle2Name = "prefabs/items";
	
	private readonly Dictionary<string, SpriteAtlas> _atlases = new Dictionary<string, SpriteAtlas>();
	private	readonly BundleLoader _bundleLoader = new BundleLoader();

	void OnEnable()
	{
		SpriteAtlasManager.atlasRequested += SpriteAtlasManagerOnAtlasRequested;
		
		SpriteButton.onClick.AddListener(() =>
		{
			var bundle = _bundleLoader.GetBundle(Bundle1Name);
			var go = bundle.LoadAsset<GameObject>("New Sprite");
			Instantiate(go);
		});
		
		UiButton.onClick.AddListener(() =>
		{
			var bundle = _bundleLoader.GetBundle(Bundle2Name);
			var go = bundle.LoadAsset<GameObject>("Items");
			go = Instantiate(go);
			go.transform.SetParent(Canvas.transform, false);
		});
	}

	void SpriteAtlasManagerOnAtlasRequested(string atlasTag, Action<SpriteAtlas> action)
	{
		Debug.Log(string.Format("On atlas requested, tag:{0}", atlasTag));
		
		if (_atlases.ContainsKey(atlasTag))
		{
			action.Invoke(_atlases[atlasTag]);
		}
		else
		{
			var bundle = AssetBundle.LoadFromFile(@"/Users/alt/Projects/Unity/uilatebinding/Bundles/atlases/ui");
			var atlas = bundle.LoadAsset<SpriteAtlas>(atlasTag);
			_atlases[atlasTag] = atlas;
			
			action.Invoke(atlas);
		}
	}
}
