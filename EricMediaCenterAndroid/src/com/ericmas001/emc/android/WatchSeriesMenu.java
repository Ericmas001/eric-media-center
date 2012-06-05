package com.ericmas001.emc.android;

import java.net.URLEncoder;

import android.app.Activity;
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

public class WatchSeriesMenu implements SearchView.OnQueryTextListener {

	Activity m_activity;

	public WatchSeriesMenu(Activity activity)
	{
		m_activity = activity;
    }
	public void inflateMenu(Menu menu)
	{
        MenuInflater inflater = m_activity.getMenuInflater();
        inflater.inflate(R.menu.watchseriesmenu, menu);
		((SearchView)menu.findItem(R.id.ws_menu_search).getActionView()).setOnQueryTextListener(this);
    }
	public void performMenuItem(MenuItem item)
	{
    	if(item.getItemId() == R.id.ws_menu_bfav)
    	{
            //do one thing
    	}
    	else if (item.getItemId() == R.id.ws_menu_bletter)
    	{
            //do another thing
    	}
    	else if (item.getItemId() == R.id.ws_menu_bgenre)
    	{
            //do another thing
    	}
    }

    public boolean onQueryTextSubmit(String query) {
    	searchSerie(query);
        return true;
    }

	public boolean onQueryTextChange(String newText) {
		// TODO Auto-generated method stub
		return true;
	}

	public void searchSerie(String query)
	{
    	if (query.length() > 0)
    	{
    		String search = URLEncoder.encode(query.trim()).replace("+", "%20");
    		String url = "http://emc.ericmas001.com/WatchSeries/Search/" + search.toString();
    		if( m_activity.getClass() == WatchSeriesSelectSerieActivity.class)
    			((WatchSeriesSelectSerieActivity)m_activity).populate(url);
    		else
    		{
	    		Intent intent = new Intent();
	    		intent.setClass(m_activity, WatchSeriesSelectSerieActivity.class);
	    		Bundle b = new Bundle();
	    		b.putString("url", url );
	    		intent.putExtras(b);
	    		m_activity.startActivity(intent);
    		}
    	}
	}
}