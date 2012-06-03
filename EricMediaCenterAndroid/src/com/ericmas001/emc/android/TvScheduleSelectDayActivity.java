package com.ericmas001.emc.android;

import java.util.HashMap;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

public class TvScheduleSelectDayActivity extends ListActivity {
	public Map<String, String> availables;
	ProgressDialog dialog;

	public void onCreate(Bundle icicle) {
		super.onCreate(icicle);
		String[] values = new String[0];
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_1, values);
		setListAdapter(adapter);
		dialog = new ProgressDialog(TvScheduleSelectDayActivity.this);
		dialog.setCancelable(false);
		dialog.setMessage("Getting Weekdays ...");
		dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
		dialog.show();
		ContactWebservice.CallWS(this, "onPostExecute", "http://emc.ericmas001.com/TvSchedule/AvailableSchedule");
	}
	@Override
	protected void onListItemClick(ListView l, View v, int position, long id) {

		
		final TvScheduleSelectDayActivity currentActivity = this;
		Intent intent = new Intent();
		String item = (String) getListAdapter().getItem(position);
		intent.setClass(currentActivity, TvScheduleDailyActivity.class);
		Bundle b = new Bundle();
		b.putString("key", availables.get(item));
		b.putString("title", item);
		intent.putExtras(b);
		if (intent != null)
			startActivity(intent);

	}
	public void onPostExecute(String result, Exception exception) {
		if (result != null) {
			JSONArray json;
			try {
				json = new JSONArray(result);
				availables = new HashMap<String, String>();
				String[] values = new String[json.length()];
				for (int i = 0; i < json.length(); ++i) {
					JSONObject o = json.getJSONObject(i);
					String id = o.getString("Key");
					String label = o.getString("Value");
					values[i] = label;
					availables.put(label, id);
				}

				ArrayAdapter<String> adapter = new ArrayAdapter<String>(
						TvScheduleSelectDayActivity.this,
						android.R.layout.simple_list_item_1, values);
				setListAdapter(adapter);
			} catch (JSONException e) {
				Toast.makeText(TvScheduleSelectDayActivity.this, e.toString(),
						Toast.LENGTH_LONG).show();
			}
		} else
			Toast.makeText(TvScheduleSelectDayActivity.this,
					exception.toString(), Toast.LENGTH_LONG).show();
		dialog.cancel();
	}
}