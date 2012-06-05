package com.ericmas001.emc.android;

import java.net.URLEncoder;
import java.util.HashMap;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import com.ericmas001.emc.android.TvScheduleDailyActivity.ScheduleEntry;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.Typeface;
import android.net.Uri;
import android.os.Bundle;
import android.view.Gravity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.BaseExpandableListAdapter;
import android.widget.EditText;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class WatchSerieTvShowActivity extends Activity {
	WatchSeriesMenu ws_menu;
	 ImageView imgShow;
	 TextView lblShow;
		ProgressDialog dialog;

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
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
		ws_menu = new WatchSeriesMenu(this);
        setContentView(R.layout.ws_show);
        imgShow=(ImageView)this.findViewById(R.id.ws_show_logo);
        lblShow=(TextView)this.findViewById(R.id.ws_show_title);
		Bundle b = getIntent().getExtras();
		String key = b.getString("key");
		dialog = new ProgressDialog(this);
		dialog.setCancelable(false);
		dialog.setMessage("Loading TvShow ...");
		dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
		
		dialog.show();
		ContactWebservice.CallWS(this, "onPostExecute", "http://emc.ericmas001.com/WatchSeries/GetShow/"+ key);
    }

	public void onPostExecute(String result, Exception exception) {
		if (result != null) {
			JSONObject json;
			try {
				json = new JSONObject(result);
				lblShow.setText(json.getString("ShowTitle"));
				
		        ExpandableListAdapter mAdapter;
		        ExpandableListView epView = (ExpandableListView) findViewById(R.id.ws_show_episodes);
		        mAdapter = new EpisodeListAdapter(json.getJSONArray("Seasons"));
		        epView.setAdapter(mAdapter);
		        
				ImageFromURL.LoadBitmap(this, "onPostExecuteLogo", json.getString("Logo").replace(" ", "%20"));
			} catch (JSONException e) {
				Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
			}
		} else
			Toast.makeText(this, exception.toString(),
					Toast.LENGTH_LONG).show();
		dialog.cancel();
	}

	public void onPostExecuteLogo(Bitmap result, Exception exception) {
		if (result != null) {
			imgShow.setImageBitmap(result);
		}
	}
	
	/**
     * A simple adapter which maintains an ArrayList of photo resource Ids. Each
     * photo is displayed as an image. This adapter supports clearing the list
     * of photos and adding a new photo.
     * 
     */
    public class EpisodeListAdapter extends BaseExpandableListAdapter {
    	private String[] groups;
    	private String[][] children;
    	public EpisodeListAdapter(JSONArray array) throws JSONException
    	{
    		groups = new String[array.length()];
    		children = new String[array.length()][];
    		for( int i = 0; i < array.length(); ++i)
    		{
    			JSONObject season = array.getJSONObject(i);
    			groups[i] = "Season " + season.getInt("SeasonNo") + " ( "+season.getInt("NbEpisodes")+" episodes)";
    			JSONArray episodes = season.getJSONArray("Episodes");
        		children[i] = new String[episodes.length()];
        		for( int j = 0; j < episodes.length(); ++j)
        		{
        			JSONObject episode = episodes.getJSONObject(j);
        			children[i][j] = season.getInt("SeasonNo") + "x" + episode.getInt("EpisodeNo") + " - "+ episode.getString("EpisodeTitle");
        		}
    		}
    	}
    	
    // Sample data set. children[i] contains the children (String[]) for
    // groups[i].
    //private String[] groups = { "Parent1", "Parent2",
    //    "Parent3" };
    //private String[][] children = { { "Child1" , "Child2" }, { "Child3" , "Child4" }, { "Child5" } };

    public Object getChild(int groupPosition, int childPosition) {
        return children[groupPosition][childPosition];
    }

    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    public int getChildrenCount(int groupPosition) {
        int i = 0;
        try {
        i = children[groupPosition].length;

        } catch (Exception e) {
        }

        return i;
    }

    public TextView getGenericView() {
        // Layout parameters for the ExpandableListView
        AbsListView.LayoutParams lp = new AbsListView.LayoutParams(
            ViewGroup.LayoutParams.FILL_PARENT, 64);

        TextView textView = new TextView(WatchSerieTvShowActivity.this);
        textView.setLayoutParams(lp);
        // Center the text vertically
        textView.setGravity(Gravity.CENTER_VERTICAL | Gravity.LEFT);
        // Set the text starting position
        textView.setPadding(60, 0, 0, 0);
        textView.setTypeface(Typeface.DEFAULT_BOLD);
        return textView;
    }

    public View getChildView(int groupPosition, int childPosition,
        boolean isLastChild, View convertView, ViewGroup parent) {
        TextView textView = getGenericView();
        textView.setTypeface(Typeface.DEFAULT);
        textView.setPadding(30, 0, 0, 0);
        textView.setText(getChild(groupPosition, childPosition).toString());
        return textView;
    }

    public Object getGroup(int groupPosition) {
        return groups[groupPosition];
    }

    public int getGroupCount() {
        return groups.length;
    }

    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    public View getGroupView(int groupPosition, boolean isExpanded,
        View convertView, ViewGroup parent) {
        TextView textView = getGenericView();
        textView.setText(getGroup(groupPosition).toString());
        return textView;
    }

    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

    public boolean hasStableIds() {
        return true;
    }

    }
}