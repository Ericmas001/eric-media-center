package com.ericmas001.emc.android;

import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.SearchView;
import android.widget.Toast;

public class MainWatchSeriesActivity extends ListActivity {
	WatchSeriesMenu ws_menu;
	public void onCreate(Bundle icicle) {
		super.onCreate(icicle);
		//String[] values = new String[] { "Browse by Letter", "Browse By Genre", "Favorites" };
		String[] values = new String[0];
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_1, values);
		setListAdapter(adapter);
		ws_menu = new WatchSeriesMenu(this);
	}

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
    	ws_menu.inflateMenu(menu);
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
    	ws_menu.performMenuItem(item);
    	return super.onOptionsItemSelected(item);
    }
    
	@Override
	protected void onListItemClick(ListView l, View v, int position, long id) {

//        final MainWatchSeriesActivity currentActivity = this;  
//        Intent intent = new Intent();
//		String item = (String) getListAdapter().getItem(position);
//		if ( item.equals("Browse by Letter") )
//			intent = null;
//		else if ( item.equals("Browse By Genre") )
//			intent = null;
//		else if ( item.equals("Favorites") )
//			intent = null;
//		else
//			intent = null;
//		if( intent != null )
//			startActivity(intent);
//		else
    		Toast.makeText(MainWatchSeriesActivity.this, "TODO !", Toast.LENGTH_SHORT).show();
			
	}
}