package com.emc.watchseries;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import com.emc.R;
import com.emc.R.id;
import com.emc.R.layout;
import com.emc.util.ContactWebservice;
import com.emc.util.EMCExpandableListAdapter;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnChildClickListener;
import android.widget.TextView;
import android.widget.Toast;

public class WatchSerieEpisodeActivity extends Activity implements
		OnChildClickListener {
	WatchSeriesMenu ws_menu;
	TextView lblShow;
	TextView lblEpisode;
	TextView lblDesc;
	ProgressDialog dialog;
	private String[][] childrenN;

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
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
		setContentView(R.layout.ws_episode);
		lblShow = (TextView) this.findViewById(R.id.ws_ep_title);
		lblEpisode = (TextView) this.findViewById(R.id.ws_ep_subtitle);
		lblDesc = (TextView) this.findViewById(R.id.ws_ep_desc);
		Bundle b = getIntent().getExtras();
		String key = b.getString("key");
		dialog = new ProgressDialog(this);
		dialog.setCancelable(false);
		dialog.setMessage("Loading Episode ...");
		dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);

		dialog.show();
		ContactWebservice.CallWS(this, "onPostExecute",
				"http://emc.ericmas001.com/WatchSeries/GetEpisode/" + key);
	}

	public void onPostExecute(String result, Exception exception) {
		if (result != null) {
			JSONObject json;
			try {
				json = new JSONObject(result);
				lblDesc.setText(json.getString("Description"));
				lblShow.setText(json.getString("ShowTitle"));
				lblEpisode.setText(json.getInt("SeasonNo") + "x" + json.getInt("EpisodeNo") + " - " + json.getString("EpisodeTitle"));
						
						
				ExpandableListAdapter mAdapter;
				ExpandableListView epView = (ExpandableListView) findViewById(R.id.ws_ep_links);
				epView.setOnChildClickListener(this);
				JSONArray array = json.getJSONArray("Links");
				String[] groups = new String[array.length()];
				String[][] children = new String[array.length()][];
				childrenN = new String[array.length()][];
				for (int i = 0; i < array.length(); ++i) {
					JSONObject website = array.getJSONObject(i);
					groups[i] = website.getString("Name");
					JSONArray ids = website.getJSONArray("LinkIDs");
					children[i] = new String[ids.length()];
					childrenN[i] = new String[ids.length()];
					for (int j = 0; j < ids.length(); ++j) {
						children[i][j] = "Link #" + (j+1);
						childrenN[i][j] = ids.getString(j);
					}
				}
				mAdapter = new EMCExpandableListAdapter(this, groups, children);
				epView.setAdapter(mAdapter);
			} catch (JSONException e) {
				Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
			}
		} else
			Toast.makeText(this, exception.toString(), Toast.LENGTH_LONG)
					.show();
		dialog.cancel();
	}

	public boolean onChildClick(ExpandableListView parent, View v,
			int groupPosition, int childPosition, long id) {
		//Toast.makeText(this, childrenN[groupPosition][childPosition],
		//		Toast.LENGTH_LONG).show();
		dialog = new ProgressDialog(this);
		dialog.setCancelable(false);
		dialog.setMessage("Loading Episode ...");
		dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);

		dialog.show();
		ContactWebservice.CallWS(this, "onPostExecuteLink",
				"http://emc.ericmas001.com/WatchSeries/GetURL/" + childrenN[groupPosition][childPosition]);
		return true;
	}

	public void onPostExecuteLink(String result, Exception exception) {
		if (result != null) {
			JSONObject json;
			try {
				json = new JSONObject(result);
				String url = json.getString("url");
				Intent i = new Intent(Intent.ACTION_VIEW);
				i.setData(Uri.parse(url));
				startActivity(i);
			} catch (JSONException e) {
				Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
			}
		} else
			Toast.makeText(this, exception.toString(), Toast.LENGTH_LONG)
					.show();
		dialog.cancel();
	}
}