package md57057eddc2fec9cc1e99465872191d85d;


public class DroidUrlTileLayer
	extends com.google.android.gms.maps.model.UrlTileProvider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getTileUrl:(III)Ljava/net/URL;:GetGetTileUrl_IIIHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.GoogleMaps.Android.DroidUrlTileLayer, Xamarin.Forms.GoogleMaps.Android, Version=2.2.1.2, Culture=neutral, PublicKeyToken=null", DroidUrlTileLayer.class, __md_methods);
	}


	public DroidUrlTileLayer (int p0, int p1)
	{
		super (p0, p1);
		if (getClass () == DroidUrlTileLayer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.GoogleMaps.Android.DroidUrlTileLayer, Xamarin.Forms.GoogleMaps.Android, Version=2.2.1.2, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public java.net.URL getTileUrl (int p0, int p1, int p2)
	{
		return n_getTileUrl (p0, p1, p2);
	}

	private native java.net.URL n_getTileUrl (int p0, int p1, int p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
