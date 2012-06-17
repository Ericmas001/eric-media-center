package com.emc.tvschedule;

import java.util.HashMap;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.app.ProgressDialog;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.Toast;

import com.emc.R;
import com.emc.test.MyListAdapter;
import com.emc.util.ContactWebservice;

public class TVSDailyActivity extends Activity
{
    class ScheduleEntry
    {
        public String Url;
        public String ShowName;
        public String ShowTitle;
        public int Season;
        public int Episode;
    }

    public Map<String, ScheduleEntry> shows;
    ProgressDialog dialog;

    private String[] list1 = {};
    private String[] list2 = {};

    @Override
    public void onCreate(Bundle b0)
    {
        super.onCreate(b0);
        setContentView(R.layout.about);
        Bundle b = getIntent().getExtras();
        String key = b.getString("key");
        String title = b.getString("title");
        setTitle(title);
        ListView lv = (ListView) findViewById(R.id.lvResult);
        MyListAdapter listAdapter = new MyListAdapter(this, list1, list2);
        lv.setAdapter(listAdapter);
        dialog = new ProgressDialog(TVSDailyActivity.this);
        dialog.setCancelable(false);
        dialog.setMessage("Loading Schedule ...");
        dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
        dialog.show();
        ContactWebservice.CallWS(this, "onPostExecute", "http://emc.ericmas001.com/TvSchedule/GetSchedule/" + key);
    }

    public void onPostExecute(String result, Exception exception)
    {
        if (result != null)
        {
            JSONArray json;
            try
            {
                json = new JSONArray(result);
                shows = new HashMap<String, TVSDailyActivity.ScheduleEntry>();
                list1 = new String[json.length()];
                list2 = new String[json.length()];
                for (int i = 0; i < json.length(); ++i)
                {
                    JSONObject o = json.getJSONObject(i);
                    ScheduleEntry entry = new ScheduleEntry();
                    entry.Url = o.getString("Url");
                    entry.ShowName = o.getString("ShowName");
                    entry.ShowTitle = o.getString("ShowTitle");
                    entry.Season = o.getInt("Season");
                    entry.Episode = o.getInt("Episode");
                    shows.put(entry.ShowName, entry);
                    list1[i] = entry.ShowName;
                    list2[i] = entry.ShowTitle + " (" + entry.Season + "x" + entry.Episode + ")";
                }

                ListView lv = (ListView) findViewById(R.id.lvResult);
                MyListAdapter listAdapter = new MyListAdapter(this, list1, list2);
                lv.setAdapter(listAdapter);
            }
            catch (JSONException e)
            {
                Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
            }
        }
        else
            Toast.makeText(TVSDailyActivity.this, exception.toString(), Toast.LENGTH_LONG).show();
        dialog.cancel();
    }

}