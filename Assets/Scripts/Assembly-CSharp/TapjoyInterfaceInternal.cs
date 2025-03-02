using Glu;
using UnityEngine;

public class TapjoyInterfaceInternal : MonoBehaviour
{
	private class Logger : LoggerSingleton<Logger>
	{
		public Logger()
		{
			LoggerSingleton<Logger>.SetLoggerName("Package.Tapjoy.Internal");
		}
	}

	private const string _gameObjectName = "TapjoyPlugin";

	public uint serverTapjoyPoints;

	private bool _isVideoPlaying;

	public bool isOfferwallOpen;

	public Tapjoy.VideoAdStateChangedHandler videoAdStateChangedHandler;

	public Tapjoy.OfferwallStateChangedHandler offerwallStateChangedHandler;

	public bool isVideoPlaying
	{
		get
		{
			return _isVideoPlaying;
		}
	}

	public static TapjoyInterfaceInternal CreateInstance()
	{
		GameObject gameObject = GameObject.Find("TapjoyPlugin");
		if (gameObject == null)
		{
			gameObject = new GameObject("TapjoyPlugin");
		}
		Object.DontDestroyOnLoad(gameObject);
		return gameObject.AddComponent<TapjoyInterfaceInternal>();
	}

	private void Awake()
	{
	}

	private void OnApplicationPause(bool pause)
	{
		if (!pause)
		{
		}
	}

	private void GetTapPointsSucceededHandler(int points)
	{
	}

	private void VideoAdStartedHandler()
	{
		_isVideoPlaying = true;
		if (videoAdStateChangedHandler != null)
		{
			videoAdStateChangedHandler(true);
		}
	}

	private void VideoAdFailedHandler()
	{
		_isVideoPlaying = false;
		if (videoAdStateChangedHandler != null)
		{
			videoAdStateChangedHandler(false);
		}
	}

	private void VideoAdCompleteHandler()
	{
		_isVideoPlaying = false;
		if (videoAdStateChangedHandler != null)
		{
			videoAdStateChangedHandler(false);
		}
	}

	private void OfferwallFailedHandler()
	{
		if (offerwallStateChangedHandler != null)
		{
			offerwallStateChangedHandler(Tapjoy.OfferwallState.Failed);
		}
	}

	private void ViewClosedHandler(TapjoyViewType viewType)
	{
		if (viewType == TapjoyViewType.OFFERWALL)
		{
			isOfferwallOpen = false;
			if (offerwallStateChangedHandler != null)
			{
				offerwallStateChangedHandler(Tapjoy.OfferwallState.Closed);
			}
		}
	}
}
