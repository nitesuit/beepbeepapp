using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BeepBeep
{
	[Activity (Label = "BeepBeep", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : TabActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			CreateTab(typeof(OptionsActivity), "whats_on", "Options", Resource.Drawable.ic_tab_whats_on);
			CreateTab(typeof(MapActivity), "speakers", "Map", Resource.Drawable.ic_tab_speakers);
			CreateTab(typeof(FillActivity), "sessions", "Fill", Resource.Drawable.ic_tab_sessions);
			CreateTab(typeof(ListActivity), "my_schedule", "List", Resource.Drawable.ic_tab_my_schedule);
			CreateTab(typeof(StatsActivity), "my_schedule", "Stats", Resource.Drawable.ic_tab_my_schedule);
		}


		private void CreateTab(Type activityType, string tag, string label, int drawableId )
		{
			var intent = new Intent(this, activityType);
			intent.AddFlags(ActivityFlags.NewTask);

			var spec = TabHost.NewTabSpec(tag);
			var drawableIcon = Resources.GetDrawable(drawableId);
			spec.SetIndicator(label, drawableIcon);
			spec.SetContent(intent);

			TabHost.AddTab(spec);
		}
	}
}


