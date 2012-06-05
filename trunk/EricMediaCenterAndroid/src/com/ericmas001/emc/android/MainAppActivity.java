package com.ericmas001.emc.android;

import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class MainAppActivity extends ListActivity {
	public void onCreate(Bundle icicle) {
		super.onCreate(icicle);
		String[] values = new String[] { "TvSchedule", "Test", "Login", "WatchSeries" };
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_1, values);
		setListAdapter(adapter);
	}


	@Override
	protected void onListItemClick(ListView l, View v, int position, long id) {

        final MainAppActivity currentActivity = this;  
        Intent intent = new Intent();
		String item = (String) getListAdapter().getItem(position);
		if( item.equals("TvSchedule") )
	        intent.setClass(currentActivity, TvScheduleSelectDayActivity.class);
		else if ( item.equals("Test") )
	        intent.setClass(currentActivity, TestAppActivity.class);
		else if ( item.equals("Login") )
	        intent.setClass(currentActivity, LoginActivity.class);
		else if ( item.equals("WatchSeries") )
		{
			intent.setClass(currentActivity, WatchSeriesSelectSerieActivity.class);
    		Bundle b = new Bundle();
    		b.putString("url", "http://emc.ericmas001.com/WatchSeries/GetPopulars" );
    		intent.putExtras(b);
		}
		else
			intent = null;
		if( intent != null )
			startActivity(intent);
	}
}