package satellitemenu;


public class SatelliteMenuButton_ClickAnimationListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.animation.Animation.AnimationListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationEnd:(Landroid/view/animation/Animation;)V:GetOnAnimationEnd_Landroid_view_animation_Animation_Handler:Android.Views.Animations.Animation/IAnimationListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onAnimationRepeat:(Landroid/view/animation/Animation;)V:GetOnAnimationRepeat_Landroid_view_animation_Animation_Handler:Android.Views.Animations.Animation/IAnimationListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onAnimationStart:(Landroid/view/animation/Animation;)V:GetOnAnimationStart_Landroid_view_animation_Animation_Handler:Android.Views.Animations.Animation/IAnimationListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("SatelliteMenu.SatelliteMenuButton/ClickAnimationListener, SatelliteMenu, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", SatelliteMenuButton_ClickAnimationListener.class, __md_methods);
	}


	public SatelliteMenuButton_ClickAnimationListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SatelliteMenuButton_ClickAnimationListener.class)
			mono.android.TypeManager.Activate ("SatelliteMenu.SatelliteMenuButton/ClickAnimationListener, SatelliteMenu, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public SatelliteMenuButton_ClickAnimationListener (satellitemenu.SatelliteMenuButton p0, int p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == SatelliteMenuButton_ClickAnimationListener.class)
			mono.android.TypeManager.Activate ("SatelliteMenu.SatelliteMenuButton/ClickAnimationListener, SatelliteMenu, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null", "SatelliteMenu.SatelliteMenuButton, SatelliteMenu, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public void onAnimationEnd (android.view.animation.Animation p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (android.view.animation.Animation p0);


	public void onAnimationRepeat (android.view.animation.Animation p0)
	{
		n_onAnimationRepeat (p0);
	}

	private native void n_onAnimationRepeat (android.view.animation.Animation p0);


	public void onAnimationStart (android.view.animation.Animation p0)
	{
		n_onAnimationStart (p0);
	}

	private native void n_onAnimationStart (android.view.animation.Animation p0);

	java.util.ArrayList refList;
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
